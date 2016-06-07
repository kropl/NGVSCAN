using NGVSCAN.CORE.Entities;
using NGVSCAN.DAL.Extensions;
using NGVSCAN.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace NGVSCAN.EXEC.Common
{
    /// <summary>
    /// Класс для выполнения опроса вычислителей
    /// </summary>
    public static class Scanner
    {
        /// <summary>
        /// Запуск опроса вычислителей на выполнение
        /// </summary>
        public static void Process(LogListView log, List<int> scanning)
        {
            // Контекст синхронизации задач с потоком интерфейса пользователя
            TaskScheduler uiSyncContext = TaskScheduler.FromCurrentSynchronizationContext();

            // Запуск задачи определения ниток для опроса
            Task.Factory.StartNew(() => GetLinesForScanning(), TaskCreationOptions.LongRunning)
                // Запуск задачи после завершения предыдущей задачи
                .ContinueWith((mainTaskResult) => 
                {
                    // Если предыдущая задача завершилась с исключением, то ...
                    if (mainTaskResult.Exception != null)
                    {
                        // Логирование сообщения об ошибке
                        LogException(log, "Ошибка чтения списка вычислителей", mainTaskResult.Exception);

                        return null;
                    }
                    // Если предыдущая задача завершилась успешно, то ...
                    else
                    {
                        // Возврат результата выполнения предыдущей задачи (списка ниток для опроса)
                        return mainTaskResult.Result;
                    }
                }, uiSyncContext)
                    // Запуск задачи опроса ниток
                    .ContinueWith((mainTaskResult) => 
                    {
                        // Если предыдущая задача завершилась успешно, то ...
                        if (mainTaskResult != null)
                        {
                            // Для каждой нитки из списка ниток для опроса
                            foreach (FloutecMeasureLine line in mainTaskResult.Result)
                            {
                                // Определение параметров нитки (адрес вычислителя, уникальный идентификатор)
                                int address = ((Floutec)line.Estimator).Address;
                                int n_flonit = address * 10 + line.Number;

                                // Если список уже опрашиваемых ниток не содержит текущей нитки, то ...
                                if (!scanning.Contains(n_flonit))
                                {
                                    // Опрос нитки
                                    ProcessLine(line, uiSyncContext, log, scanning);
                                }
                            }
                        }
                    });
        }

        // Метод опроса нитки
        private static void ProcessLine(FloutecMeasureLine line, TaskScheduler uiSyncContext, LogListView log, List<int> scanning)
        {
            // Если дата последнего опроса нитки не определена ИЛИ период ожидания опроса нитки истёк, то ...
            if (!line.DateHourlyDataLastScanned.HasValue ||
                line.DateHourlyDataLastScanned.Value.AddMinutes(line.HourlyDataScanPeriod) <= DateTime.Now)
            {
                // Определение параметров нитки (адрес вычислителя, уникальный идентификатор)
                int address = ((Floutec)line.Estimator).Address;
                int n_flonit = address * 10 + line.Number;

                // Добавление текущей нитки в список уже опрашиваемых
                scanning.Add(n_flonit);

                // Запуск задачи получения данных для нитки
                Task.Factory.StartNew(() => GetLineData(line), TaskCreationOptions.LongRunning)
                    // Запуск задачи после завершения предыдущей задачи
                    .ContinueWith((getDataResult) => 
                    {
                        // Если предыдущая задача завершилась успешно, то ...
                        if (getDataResult.Exception == null)
                        {
                            // Логирование успешного завершения задачи
                            Logger.Log(log, "Опрос данных нитки №" + line.Number + " вычислителя с адресом " + address + " выполнен успешно", LogType.Success);

                            // Возврат результатов выполнения задачи (часовых данных нитки)
                            return getDataResult.Result;
                        }
                        // Если предыдущая задача завершилась с исключением
                        else
                        {
                            // Логирование сообщения об ошибке
                            LogException(log, "Опрос данных нитки №" + line.Number + " вычислителя с адресом " + address + " выполнен с ошибками", getDataResult.Exception);

                            // Возврат исключения в следующую задачу
                            throw getDataResult.Exception;
                        }
                    }, uiSyncContext)
                        // Запуск задачи сохранения данных ниток
                        .ContinueWith((getDataResult) => 
                        {
                            // Если предыдущая задача завершилась успешно, то ...
                            if (getDataResult.Exception == null)
                            {
                                // Сохранение данных ниток
                                SaveLineData(line, getDataResult.Result);                               
                            }
                            // Если предыдущая задача завершилась с исключением, то ...
                            else
                            {
                                // Возврат исключения в следующую задачу
                                throw getDataResult.Exception;
                            }
                        })
                            // Запуск задачи после завершения предыдущей задачи (сохранения данных)
                            .ContinueWith((insertDataResult) =>
                            {
                                // Если предыдущая задача завершилась успешно, то ...
                                if (insertDataResult.Exception == null)
                                {
                                    // Логирование сообщения об ошибке
                                    Logger.Log(log, "Сохранение данных нитки №" + line.Number + " вычислителя с адресом " + address + " выполнено успешно", LogType.Success);
                                }
                                // Если предыдущая задача завершилась с исключением, то ...
                                else
                                {
                                    // Логирование сообщения об ошибке
                                    LogException(log, "Сохранение данных нитки №" + line.Number + " вычислителя с адресом " + address + " выполнено с ошибками", insertDataResult.Exception);
                                }

                                // Удаления нитки из списка опрашиваемых ниток
                                scanning.Remove(n_flonit);
                            }, uiSyncContext);
            }
        }

        private static void SaveLineData(FloutecMeasureLine line, LineData data)
        {
            if (data.HourlyData.Count > 0)
            {
                data.HourlyData.ForEach((d) =>
                {
                    d.DateCreated = DateTime.Now;
                    d.DateModified = DateTime.Now;
                    d.FloutecMeasureLineId = line.Id;
                });

                try
                {
                    using (SqlRepository<FloutecHourlyData> repo = new SqlRepository<FloutecHourlyData>())
                    {
                        repo.Insert(data.HourlyData);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            if (data.IdentData != null)
            {
                data.IdentData.DateCreated = DateTime.Now;
                data.IdentData.DateModified = DateTime.Now;
                data.IdentData.FloutecMeasureLineId = line.Id;

                try
                {
                    using (SqlRepository<FloutecIdentData> repo = new SqlRepository<FloutecIdentData>())
                    {
                        repo.Insert(data.IdentData);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            try
            {
                using (SqlRepository<FloutecMeasureLine> repo = new SqlRepository<FloutecMeasureLine>())
                {
                    var exLine = repo.Get(line.Id);

                    exLine.DateHourlyDataLastScanned = DateTime.Now;
                    repo.Update(exLine);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static LineData GetLineData(FloutecMeasureLine line)
        {
            int address = ((Floutec)line.Estimator).Address;

            LineData lineData = new LineData();

            try
            {
                using (DbfRepository repo = new DbfRepository(Settings.DbfTablesPath))
                {
                    if (line.HourlyData.Count == 0)
                        lineData.HourlyData = repo.GetAllHourlyData(address, line.Number);
                    else
                        lineData.HourlyData = repo.GetHourlyData(address, line.Number, line.HourlyData.OrderBy(o => o.DAT).Last().DAT, DateTime.Now);

                    if (line.IdentData.Count == 0)
                        lineData.IdentData = repo.GetIdentData(address, line.Number);
                    else
                    {
                        FloutecIdentData identData = repo.GetIdentData(address, line.Number);

                        if (!line.IdentData.OrderBy(o => o.DateCreated).Last().IsEqual(identData))
                            lineData.IdentData = identData;
                        else
                            lineData.IdentData = null;
                    }

                    return lineData;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static List<FloutecMeasureLine> GetLinesForScanning()
        {
            try
            {
                using (SqlRepository<FloutecMeasureLine> repo = new SqlRepository<FloutecMeasureLine>())
                {
                    return repo.GetAll()
                    .Include(l => l.HourlyData)
                    .Include(l => l.IdentData)
                    .Include(l => l.Estimator)
                    .Where(l => !l.IsDeleted && !l.Estimator.IsDeleted)
                    .ToList();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        private static void LogException(LogListView log, string message, AggregateException exception)
        {
            Logger.Log(log, message, LogType.Error);
            Logger.Log(log, exception.Message, LogType.Error);
            foreach (var item in exception.InnerExceptions)
            {
                Logger.Log(log, item.Message, LogType.Error);
            }
        }
    }

    class LineData
    {
        public List<FloutecHourlyData> HourlyData { get; set; }

        public FloutecIdentData IdentData { get; set; }
    }
}
