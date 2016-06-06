using NGVSCAN.CORE.Entities;
using NGVSCAN.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
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

            Task.Factory.StartNew(() => GetLinesForScanning(), TaskCreationOptions.LongRunning)
                .ContinueWith((mainTaskResult) => 
                {
                    if (mainTaskResult.Exception != null)
                    {
                        LogException(log, "Ошибка чтения списка вычислителей", mainTaskResult.Exception);

                        return null;
                    }
                    else
                        return mainTaskResult.Result;
                }, uiSyncContext)
                .ContinueWith((mainTaskResult) => 
                {
                    if (mainTaskResult != null)
                    {
                        foreach (FloutecMeasureLine line in mainTaskResult.Result)
                        {
                            int address = ((Floutec)line.Estimator).Address;
                            int n_flonit = address * 10 + line.Number;

                            if (!scanning.Contains(n_flonit))
                            {
                                scanning.Add(n_flonit);

                                ProcessLine(line, uiSyncContext, log);

                                scanning.Remove(n_flonit);
                            }
                        }
                    }
                });
        }

        private static void ProcessLine(FloutecMeasureLine line, TaskScheduler uiSyncContext, LogListView log)
        {
            if (!line.DateHourlyDataLastScanned.HasValue ||
                line.DateHourlyDataLastScanned.Value.AddMinutes(line.HourlyDataScanPeriod) <= DateTime.Now)
            {
                int address = ((Floutec)line.Estimator).Address;

                Task.Factory.StartNew(() => GetHourlyData(line), TaskCreationOptions.LongRunning)
                    .ContinueWith((getDataResult) => 
                    {
                        if (getDataResult.Exception == null)
                        {
                            Logger.Log(log, "Опрос часовых данных нитки №" + line.Number + " вычислителя с адресом " + address + " выполнен успешно", LogType.Success);
                            return getDataResult.Result;
                        }
                        else
                        {
                            LogException(log, "Опрос часовых данных нитки №" + line.Number + " вычислителя с адресом " + address + " выполнен с ошибками", getDataResult.Exception);

                            return null;
                        }
                    }, uiSyncContext)
                        .ContinueWith((getDataResult) => 
                        {
                            if (getDataResult != null)
                            {
                                SaveHourlyData(line, getDataResult.Result);                               
                            }
                        })
                            .ContinueWith((insertDataResult) =>
                            {
                                if (insertDataResult.Exception == null)
                                {
                                    Logger.Log(log, "Сохранение часовых данных нитки №" + line.Number + " вычислителя с адресом " + address + " выполнен успешно", LogType.Success);
                                }
                                else
                                {
                                    LogException(log, "Сохранение часовых данных нитки №" + line.Number + " вычислителя с адресом " + address + " выполнен с ошибками", insertDataResult.Exception);
                                }
                            }, uiSyncContext);
            }
        }

        private static void SaveHourlyData(FloutecMeasureLine line, List<FloutecHourlyData> data)
        {
            if (data.Count > 0)
            {
                data.ForEach((d) =>
                {
                    d.DateCreated = DateTime.Now;
                    d.DateModified = DateTime.Now;
                    d.FloutecMeasureLineId = line.Id;
                });

                try
                {
                    using (SqlRepository<FloutecHourlyData> repo = new SqlRepository<FloutecHourlyData>())
                    {
                        repo.Insert(data);
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

        private static List<FloutecHourlyData> GetHourlyData(FloutecMeasureLine line)
        {
            int address = ((Floutec)line.Estimator).Address;

            try
            {
                using (DbfRepository repo = new DbfRepository(Settings.DbfTablesPath))
                {
                    if (line.HourlyData.Count == 0)
                        return repo.GetAllHourlyData(address, line.Number);
                    else
                        return repo.GetHourlyData(address, line.Number, line.HourlyData.Last().DateCreated, DateTime.Now);
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
}
