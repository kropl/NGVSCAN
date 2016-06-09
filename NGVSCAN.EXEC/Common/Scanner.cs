using NGVSCAN.CORE.Entities;
using NGVSCAN.DAL.Extensions;
using NGVSCAN.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace NGVSCAN.EXEC.Common
{
    /// <summary>
    /// Класс для выполнения опроса вычислителей
    /// </summary>
    public class Scanner
    {
        private Dictionary<string, bool> scanning;

        private DateTime dateStartHourlyDataScan;
        private DateTime dateStartInstantDataScan;

        public Scanner()
        {
        }

        /// <summary>
        /// Запуск опроса вычислителей на выполнение
        /// </summary>
        public void Process(LogListView log)
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
                                // Опрос нитки
                                ProcessLine(line, uiSyncContext, log);
                            }
                        }
                    });
        }

        // Метод опроса нитки
        private void ProcessLine(FloutecMeasureLine line, TaskScheduler uiSyncContext, LogListView log)
        {
            int address = ((Floutec)line.Estimator).Address;
            int n_flonit = address * 10 + line.Number;

            bool timeToHourlyData = !line.DateHourlyDataLastScanned.HasValue || line.DateHourlyDataLastScanned.Value.AddMinutes(line.HourlyDataScanPeriod) <= DateTime.Now;
            bool timeToInstantData = !line.DateInstantDataLastScanned.HasValue || line.DateInstantDataLastScanned.Value.AddMinutes(line.InstantDataScanPeriod) <= DateTime.Now;

            if ((timeToHourlyData && !scanning[n_flonit.ToString() + "_hour"]) || (timeToInstantData && !scanning[n_flonit.ToString() + "_inst"]))
            {
                Task.Factory.StartNew(() => GetIdentData(line), TaskCreationOptions.LongRunning)
                    .ContinueWith((getIdentDataResult) =>
                    {
                        if (getIdentDataResult.Exception != null)
                        {
                            LogException(log, "Ошибка опроса данных идентификации нитки №" + line.Number + " вычислителя ФЛОУТЭК с адресом " + address, getIdentDataResult.Exception);
                            throw getIdentDataResult.Exception;
                        }
                        else
                            return getIdentDataResult.Result;
                    },
                    uiSyncContext)
                        .ContinueWith((getIdentDataLogResult) =>
                        {
                            if (getIdentDataLogResult.Exception == null)
                            {
                                SaveIdentData(line, getIdentDataLogResult.Result);
                                return true;
                            }
                            else
                                return false;
                        },
                        TaskContinuationOptions.LongRunning)
                            .ContinueWith((saveIdentDataResult) =>
                            {
                                if (saveIdentDataResult.Exception != null)
                                    LogException(log, "Ошибка сохранения данных идентификации нитки №" + line.Number + " вычислителя ФЛОУТЭК с адресом " + address, saveIdentDataResult.Exception);
                                else if (saveIdentDataResult.Result)
                                    Logger.Log(log, "Опрос данных идентификации нитки №" + line.Number + " вычислителя ФЛОУТЭК с адресом " + address + " выполнен успешно", LogType.Success);

                                scanning[n_flonit.ToString() + "_ident"] = false;
                            },
                            uiSyncContext)
                                .ContinueWith((saveIdentDataLogResult) =>
                                {
                                    if (timeToHourlyData && !scanning[n_flonit.ToString() + "_hour"])
                                    {
                                        Task.Factory.StartNew(() => GetHourlyData(line), TaskCreationOptions.LongRunning)
                                            .ContinueWith((getHourlyDataResult) =>
                                            {
                                                if (getHourlyDataResult.Exception != null)
                                                {
                                                    LogException(log, "Ошибка опроса часовых данных нитки №" + line.Number + " вычислителя ФЛОУТЭК с адресом " + address, getHourlyDataResult.Exception);
                                                    throw getHourlyDataResult.Exception;
                                                }
                                                else
                                                    return getHourlyDataResult.Result;
                                            },
                                            uiSyncContext)
                                                .ContinueWith((getHourlyDataLogResult) => 
                                                {
                                                    if (getHourlyDataLogResult.Exception == null)
                                                    {
                                                        SaveHourlyData(line, getHourlyDataLogResult.Result);
                                                        return true;
                                                    }
                                                    else
                                                        return false;
                                                },
                                                TaskContinuationOptions.LongRunning)
                                                    .ContinueWith((saveHourlyDataResult) => 
                                                    {
                                                        if (saveHourlyDataResult.Exception != null)
                                                            LogException(log, "Ошибка сохранения часовых данных нитки №" + line.Number + " вычислителя ФЛОУТЭК с адресом " + address, saveHourlyDataResult.Exception);
                                                        else if (saveHourlyDataResult.Result)
                                                            Logger.Log(log, "Опрос часовых данных нитки №" + line.Number + " вычислителя ФЛОУТЭК с адресом " + address + " выполнен успешно", LogType.Success);

                                                        scanning[n_flonit.ToString() + "_hour"] = false;
                                                    },
                                                    uiSyncContext);
                                    }

                                    if (timeToInstantData && !scanning[n_flonit.ToString() + "_inst"])
                                    {
                                        Task.Factory.StartNew(() => GetInstantData(line), TaskCreationOptions.LongRunning)
                                            .ContinueWith((getInstantDataResult) =>
                                            {
                                                if (getInstantDataResult.Exception != null)
                                                {
                                                    LogException(log, "Ошибка опроса мгновенных данных нитки №" + line.Number + " вычислителя ФЛОУТЭК с адресом " + address, getInstantDataResult.Exception);
                                                    throw getInstantDataResult.Exception;
                                                }
                                                else
                                                    return getInstantDataResult.Result;
                                            },
                                            uiSyncContext)
                                                .ContinueWith((getInstantDataLogResult) =>
                                                {
                                                    if (getInstantDataLogResult.Exception == null)
                                                    {
                                                        SaveInstantData(line, getInstantDataLogResult.Result);
                                                        return true;
                                                    }
                                                    else
                                                        return false;
                                                },
                                                TaskContinuationOptions.LongRunning)
                                                    .ContinueWith((saveInstantDataResult) =>
                                                    {
                                                        if (saveInstantDataResult.Exception != null)
                                                            LogException(log, "Ошибка сохранения мгновенных данных нитки №" + line.Number + " вычислителя ФЛОУТЭК с адресом " + address, saveInstantDataResult.Exception);
                                                        else if (saveInstantDataResult.Result)
                                                            Logger.Log(log, "Опрос мгновенных данных нитки №" + line.Number + " вычислителя ФЛОУТЭК с адресом " + address + " выполнен успешно", LogType.Success);

                                                        scanning[n_flonit.ToString() + "_inst"] = false;
                                                    },
                                                    uiSyncContext); ;
                                    }
                                },
                                TaskContinuationOptions.LongRunning);
            }         
        }

        private FloutecIdentData GetIdentData(FloutecMeasureLine line)
        {
            int address = ((Floutec)line.Estimator).Address;
            int n_flonit = address * 10 + line.Number;

            if (!scanning[n_flonit.ToString() + "_ident"])
            {
#if DEBUG
                Debug.WriteLine("Опрос данных идентификации нитки №" + line.Number + " вычислителя с адресом " + address);
#endif
                scanning[n_flonit.ToString() + "_ident"] = true;

                FloutecIdentData identData = new FloutecIdentData();

                try
                {
                    using (DbfRepository repo = new DbfRepository(Settings.DbfTablesPath))
                    {
                        if (line.IdentData.Count == 0)
                            identData = repo.GetIdentData(address, line.Number);
                        else
                        {
                            FloutecIdentData newData = repo.GetIdentData(address, line.Number);

                            if (!line.IdentData.OrderBy(o => o.DateCreated).Last().IsEqual(newData))
                                identData = newData;
                            else
                                identData = null;
                        }

                        return identData;
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
#if DEBUG
                Debug.WriteLine("Данные идентификации нитки №" + line.Number + " вычислителя с адресом " + address + " уже опрашиваются");
#endif
                return null;
            }
        }

        private void SaveIdentData(FloutecMeasureLine line, FloutecIdentData data)
        {
            if (data != null)
            {
                data.DateCreated = DateTime.Now;
                data.DateModified = DateTime.Now;
                data.FloutecMeasureLineId = line.Id;

            try
            {
                using (SqlRepository<FloutecIdentData> repo = new SqlRepository<FloutecIdentData>())
                {
                    repo.Insert(data);
                }
            }
                catch (Exception ex)
                {
                    throw ex;
                }
            }            
        }

        private List<FloutecHourlyData> GetHourlyData(FloutecMeasureLine line)
        {
            int address = ((Floutec)line.Estimator).Address;

            dateStartHourlyDataScan = DateTime.Now;

            List<FloutecHourlyData> hourlyData = new List<FloutecHourlyData>();

            try
            {
                using (DbfRepository repo = new DbfRepository(Settings.DbfTablesPath))
                {
                    if (line.HourlyData.Count == 0)
                        hourlyData = repo.GetAllHourlyData(address, line.Number);
                    else
                        hourlyData = repo.GetHourlyData(address, line.Number, line.HourlyData.OrderBy(o => o.DAT).Last().DAT, DateTime.Now);

                    return hourlyData;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void SaveHourlyData(FloutecMeasureLine line, List<FloutecHourlyData> data)
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
                    FloutecMeasureLine existingLine = repo.Get(line.Id);
                    existingLine.DateHourlyDataLastScanned = dateStartHourlyDataScan;
                    repo.Update(existingLine);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private FloutecInstantData GetInstantData(FloutecMeasureLine line)
        {
            int address = ((Floutec)line.Estimator).Address;

            dateStartInstantDataScan = DateTime.Now;

            FloutecInstantData instantData = new FloutecInstantData();

            try
            {
                using (DbfRepository repo = new DbfRepository(Settings.DbfTablesPath))
                {
                    if (line.InstantData.Count == 0)
                        instantData = repo.GetInstantData(address, line.Number);
                    else
                    {
                        FloutecInstantData newData = repo.GetInstantData(address, line.Number);

                        if (!line.InstantData.OrderBy(o => o.DateCreated).Last().IsEqual(newData))
                            instantData = newData;
                        else
                            instantData = null;
                    }

                    return instantData;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void SaveInstantData(FloutecMeasureLine line, FloutecInstantData data)
        {
            if (data != null)
            {
                data.DateCreated = DateTime.Now;
                data.DateModified = DateTime.Now;
                data.FloutecMeasureLineId = line.Id;

                try
                {
                    using (SqlRepository<FloutecInstantData> repo = new SqlRepository<FloutecInstantData>())
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
                    FloutecMeasureLine existingLine = repo.Get(line.Id);
                    existingLine.DateInstantDataLastScanned = dateStartInstantDataScan;
                    repo.Update(existingLine);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private List<FloutecMeasureLine> GetLinesForScanning()
        {
            List<FloutecMeasureLine> lines;

            try
            {
                using (SqlRepository<FloutecMeasureLine> repo = new SqlRepository<FloutecMeasureLine>())
                {
                    lines = repo.GetAll()
                    .Include(l => l.HourlyData)
                    .Include(l => l.IdentData)
                    .Include(l => l.InstantData)
                    .Include(l => l.Estimator)
                    .Where(l => !l.IsDeleted && !l.Estimator.IsDeleted)
                    .ToList();

                    if (scanning == null)
                    {
                        scanning = new Dictionary<string, bool>();

                        lines.ForEach((l) =>
                        {
                            int address = ((Floutec)l.Estimator).Address;
                            int n_flonit = address * 10 + l.Number;

                            scanning.Add(n_flonit.ToString() + "_ident", false);
                            scanning.Add(n_flonit.ToString() + "_inst", false);
                            scanning.Add(n_flonit.ToString() + "_hour", false);
                        });
                    }

                    return lines;
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        private void LogException(LogListView log, string message, AggregateException exception)
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
