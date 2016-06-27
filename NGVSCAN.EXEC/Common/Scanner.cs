using NGVSCAN.CORE.Entities.Floutecs;
using NGVSCAN.CORE.Entities.ROC809s;
using NGVSCAN.DAL.Extensions;
using NGVSCAN.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using NGVSCAN.DAL.ROC809Connection;
using NGVSCAN.EXEC.Controls;

namespace NGVSCAN.EXEC.Common
{
    /// <summary>
    /// Класс для выполнения опроса вычислителей
    /// </summary>
    public class Scanner
    {
        #region Конструктор и поля

        // Переменные для отслеживания состояния опроса ниток и точек
        private Dictionary<string, bool> floutecsScanningState;
        private Dictionary<string, bool> rocsScanningState;

        // Переменные для хранения времени начала опроса данных вычислителей ФЛОУТЭК
        private DateTime dateStartHourlyDataScan;
        private DateTime dateStartInstantDataScan;
        private DateTime dateStartMinuteDataScan;
        private DateTime dateStartPeriodicDataScan;
        private DateTime dateStartDailyDataScan;

        // Соединение с БД SQL
        private string connection;

        /// <summary>
        /// Класс для выполнения опроса вычислителей
        /// </summary>
        public Scanner(string connection)
        {
            // Инициализация соединения
            this.connection = connection;
        }

        #endregion

        #region Определение списков ниток и точек для опроса

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
                        LogException(log, "Ошибка построения списка вычислителей ФЛОУТЭК", mainTaskResult.Exception, LogType.Floutec);

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

            // Запуск задачи определения точек для опроса
            Task.Factory.StartNew(() => GetPointsForScanning(), TaskCreationOptions.LongRunning)
                // Запуск задачи после завершения предыдущей задачи
                .ContinueWith((mainTaskResult) =>
                {
                    // Если предыдущая задача завершилась с исключением, то ...
                    if (mainTaskResult.Exception != null)
                    {
                        // Логирование сообщения об ошибке
                        LogException(log, "Ошибка построения списка вычислителей ROC809", mainTaskResult.Exception, LogType.ROC);

                        return null;
                    }
                    // Если предыдущая задача завершилась успешно, то ...
                    else
                    {
                        // Возврат результата выполнения предыдущей задачи (списка точек для опроса)
                        return mainTaskResult.Result;
                    }
                }, uiSyncContext)
                    // Запуск задачи опроса точек
                    .ContinueWith((mainTaskResult) =>
                    {
                        // Если предыдущая задача завершилась успешно, то ...
                        if (mainTaskResult != null)
                        {
                            // Для каждой точки из списка точек для опроса
                            foreach (ROC809MeasurePoint point in mainTaskResult.Result)
                            {
                                // Опрос точки
                                ProcessPoint(point, uiSyncContext, log);
                            }
                        }
                    });
        }

        #endregion

        #region Опрос ниток и точек

        // Метод опроса нитки
        private void ProcessLine(FloutecMeasureLine line, TaskScheduler uiSyncContext, LogListView log)
        {
            int address = ((Floutec)line.Estimator).Address;
            int n_flonit = address * 10 + line.Number;

            bool timeToHourlyData = !line.DateHourlyDataLastScanned.HasValue || line.DateHourlyDataLastScanned.Value.AddMinutes(line.HourlyDataScanPeriod) <= DateTime.Now;
            bool timeToInstantData = !line.DateInstantDataLastScanned.HasValue || line.DateInstantDataLastScanned.Value.AddMinutes(line.InstantDataScanPeriod) <= DateTime.Now;

            if ((timeToHourlyData && !floutecsScanningState[n_flonit.ToString() + "_hour"]) || (timeToInstantData && !floutecsScanningState[n_flonit.ToString() + "_inst"]))
            {
                #region Опрос и сохранение данных идентификации

                Task.Factory.StartNew(() => GetIdentData(line), TaskCreationOptions.LongRunning)
                    .ContinueWith((getIdentDataResult) =>
                    {
                        if (getIdentDataResult.Exception != null)
                        {
                            LogException(log, "Ошибка опроса данных идентификации нитки №" + line.Number + " вычислителя ФЛОУТЭК с адресом " + address, getIdentDataResult.Exception, LogType.Floutec);
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
                                    LogException(log, "Ошибка сохранения данных идентификации нитки №" + line.Number + " вычислителя ФЛОУТЭК с адресом " + address, saveIdentDataResult.Exception, LogType.ROC);
                                else if (saveIdentDataResult.Result)
                                    Logger.Log(log, new LogEntry { Message = "Опрос данных идентификации нитки №" + line.Number + " вычислителя ФЛОУТЭК с адресом " + address + " выполнен успешно", Status = LogStatus.Success, Type = LogType.Floutec, Timestamp = DateTime.Now });

                                floutecsScanningState[n_flonit.ToString() + "_ident"] = false;
                            },
                            uiSyncContext)

                #endregion

                #region Опрос и сохранение данных аварий

                                .ContinueWith((saveIdentDataLogResult) =>
                                {
                                    return GetAlarmData(line);
                                },
                                TaskContinuationOptions.LongRunning)
                                    .ContinueWith((getAlarmDataResult) =>
                                    {
                                        if (getAlarmDataResult.Exception != null)
                                        {
                                            LogException(log, "Ошибка опроса данных аварий нитки №" + line.Number + " вычислителя ФЛОУТЭК с адресом " + address, getAlarmDataResult.Exception, LogType.Floutec);
                                            throw getAlarmDataResult.Exception;
                                        }
                                        else
                                            return getAlarmDataResult.Result;
                                    },
                                    uiSyncContext)
                                        .ContinueWith((getAlarmDataLogResult) =>
                                        {
                                            if (getAlarmDataLogResult.Exception == null)
                                            {
                                                SaveAlarmData(line, getAlarmDataLogResult.Result);
                                                return true;
                                            }
                                            else
                                                return false;
                                        },
                                        TaskContinuationOptions.LongRunning)
                                            .ContinueWith((saveAlarmDataResult) =>
                                            {
                                                if (saveAlarmDataResult.Exception != null)
                                                    LogException(log, "Ошибка сохранения данных аварий нитки №" + line.Number + " вычислителя ФЛОУТЭК с адресом " + address, saveAlarmDataResult.Exception, LogType.Floutec);
                                                else if (saveAlarmDataResult.Result)
                                                    Logger.Log(log, new LogEntry { Message = "Опрос данных аварий нитки №" + line.Number + " вычислителя ФЛОУТЭК с адресом " + address + " выполнен успешно", Status = LogStatus.Success, Type = LogType.Floutec, Timestamp = DateTime.Now });

                                                floutecsScanningState[n_flonit.ToString() + "_alarm"] = false;
                                            }, 
                                            uiSyncContext)

                #endregion

                #region Опрос и сохранение данных вмешательств

                                                .ContinueWith((saveAlarmDataLogResult) =>
                                                {
                                                    return GetInterData(line);
                                                },
                                                TaskContinuationOptions.LongRunning)
                                                    .ContinueWith((getInterDataResult) =>
                                                    {
                                                        if (getInterDataResult.Exception != null)
                                                        {
                                                            LogException(log, "Ошибка опроса данных вмешательств нитки №" + line.Number + " вычислителя ФЛОУТЭК с адресом " + address, getInterDataResult.Exception, LogType.Floutec);
                                                            throw getInterDataResult.Exception;
                                                        }
                                                        else
                                                            return getInterDataResult.Result;
                                                    },
                                                    uiSyncContext)
                                                        .ContinueWith((getInterDataLogResult) =>
                                                        {
                                                            if (getInterDataLogResult.Exception == null)
                                                            {
                                                                SaveInterData(line, getInterDataLogResult.Result);
                                                                return true;
                                                            }
                                                            else
                                                                return false;
                                                        },
                                                        TaskContinuationOptions.LongRunning)
                                                            .ContinueWith((saveInterDataResult) =>
                                                            {
                                                                if (saveInterDataResult.Exception != null)
                                                                    LogException(log, "Ошибка сохранения данных вмешательств нитки №" + line.Number + " вычислителя ФЛОУТЭК с адресом " + address, saveInterDataResult.Exception, LogType.Floutec);
                                                                else if (saveInterDataResult.Result)
                                                                    Logger.Log(log, new LogEntry { Message = "Опрос данных вмешательств нитки №" + line.Number + " вычислителя ФЛОУТЭК с адресом " + address + " выполнен успешно", Status = LogStatus.Success, Type = LogType.Floutec, Timestamp = DateTime.Now });

                                                                floutecsScanningState[n_flonit.ToString() + "_inter"] = false;
                                                            },
                                                            uiSyncContext)

                #endregion

                #region Опрос и сохранение часовых данных

                                                                .ContinueWith((saveAlarmDataLogResult) =>
                                                                {
                                                                    if (timeToHourlyData && !floutecsScanningState[n_flonit.ToString() + "_hour"])
                                                                    {
                                                                        Task.Factory.StartNew(() => GetHourlyData(line), TaskCreationOptions.LongRunning)
                                                                            .ContinueWith((getHourlyDataResult) =>
                                                                            {
                                                                                if (getHourlyDataResult.Exception != null)
                                                                                {
                                                                                    LogException(log, "Ошибка опроса часовых данных нитки №" + line.Number + " вычислителя ФЛОУТЭК с адресом " + address, getHourlyDataResult.Exception, LogType.Floutec);
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
                                                                                            LogException(log, "Ошибка сохранения часовых данных нитки №" + line.Number + " вычислителя ФЛОУТЭК с адресом " + address, saveHourlyDataResult.Exception, LogType.Floutec);
                                                                                        else if (saveHourlyDataResult.Result)
                                                                                            Logger.Log(log, new LogEntry { Message = "Опрос часовых данных нитки №" + line.Number + " вычислителя ФЛОУТЭК с адресом " + address + " выполнен успешно", Status = LogStatus.Success, Type = LogType.Floutec, Timestamp = DateTime.Now });

                                                                                        floutecsScanningState[n_flonit.ToString() + "_hour"] = false;
                                                                                    },
                                                                                    uiSyncContext);
                                                                    }

                                                                    #endregion

                #region Опрос и сохранение мгновенных данных

                                                                    if (timeToInstantData && !floutecsScanningState[n_flonit.ToString() + "_inst"])
                                                                    {
                                                                        Task.Factory.StartNew(() => GetInstantData(line), TaskCreationOptions.LongRunning)
                                                                            .ContinueWith((getInstantDataResult) =>
                                                                            {
                                                                                if (getInstantDataResult.Exception != null)
                                                                                {
                                                                                    LogException(log, "Ошибка опроса мгновенных данных нитки №" + line.Number + " вычислителя ФЛОУТЭК с адресом " + address, getInstantDataResult.Exception, LogType.Floutec);
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
                                                                                            LogException(log, "Ошибка сохранения мгновенных данных нитки №" + line.Number + " вычислителя ФЛОУТЭК с адресом " + address, saveInstantDataResult.Exception, LogType.Floutec);
                                                                                        else if (saveInstantDataResult.Result)
                                                                                            Logger.Log(log, new LogEntry { Message = "Опрос мгновенных данных нитки №" + line.Number + " вычислителя ФЛОУТЭК с адресом " + address + " выполнен успешно", Status = LogStatus.Success, Type = LogType.Floutec, Timestamp = DateTime.Now });

                                                                                        floutecsScanningState[n_flonit.ToString() + "_inst"] = false;
                                                                                    },
                                                                                    uiSyncContext); ;
                                                                    }
                                                                },
                                                                TaskContinuationOptions.LongRunning);

                #endregion
            }
        }

        private void ProcessPoint(ROC809MeasurePoint point, TaskScheduler uiSyncContext, LogListView log)
        {
            string address = ((ROC809)point.Estimator).Address;
            string ident = address + "_" + point.Number + "_" + point.HistSegment;

            bool timeToMinuteData = !point.DateMinuteDataLastScanned.HasValue || point.DateMinuteDataLastScanned.Value.AddMinutes(point.MinuteDataScanPeriod) <= DateTime.Now;
            bool timeToPeriodicData = !point.DatePeriodicDataLastScanned.HasValue || point.DatePeriodicDataLastScanned.Value.AddMinutes(point.PeriodicDataScanPeriod) <= DateTime.Now;
            bool timeToDailyData = !point.DateDailyDataLastScanned.HasValue || point.DateDailyDataLastScanned.Value.AddMinutes(point.DailyDataScanPeriod) <= DateTime.Now;

            if ((timeToMinuteData && !rocsScanningState[ident + "_minute"]) || (timeToPeriodicData && !rocsScanningState[ident + "_periodic"]) || (timeToDailyData && !rocsScanningState[ident + "_daily"]))
            {
                #region Опрос и сохранение данных событий

                Task.Factory.StartNew(() => GetEventData(point), TaskCreationOptions.LongRunning)
                    .ContinueWith((getEventDataResult) =>
                    {
                        if (getEventDataResult.Exception != null)
                        {
                            LogException(log, "Ошибка опроса данных событий точки №" + point.Number + " в историческом сегменте №" + point.HistSegment + " вычислителя ROC809 с адресом " + address, getEventDataResult.Exception, LogType.ROC);
                            throw getEventDataResult.Exception;
                        }
                        else
                            return getEventDataResult.Result;
                    },
                    uiSyncContext)
                        .ContinueWith((getEventDataLogResult) =>
                        {
                            if (getEventDataLogResult.Exception == null)
                            {
                                if (getEventDataLogResult.Result == null)
                                    return 0;
                                else if (getEventDataLogResult.Result.Count == 0)
                                    return 1;
                                else
                                {
                                    SaveEventData(point, getEventDataLogResult.Result);
                                    return 2;
                                }
                            }
                            else
                                return -1;
                        },
                        TaskContinuationOptions.LongRunning)
                            .ContinueWith((saveEventDataResult) =>
                            {
                                if (saveEventDataResult.Exception != null)
                                {
                                    LogException(log, "Ошибка сохранения данных событий точки №" + point.Number + " в историческом сегменте №" + point.HistSegment + " вычислителя ROC809 с адресом " + address, saveEventDataResult.Exception, LogType.ROC);
                                    rocsScanningState[ident + "_event"] = false;
                                }
                                else if (saveEventDataResult.Result == 2)
                                    Logger.Log(log, new LogEntry { Message = "Опрос данных событий точки №" + point.Number + " в историческом сегменте №" + point.HistSegment + " вычислителя ROC809 с адресом " + address + " выполнен успешно", Status = LogStatus.Success, Type = LogType.ROC, Timestamp = DateTime.Now });

                                if (saveEventDataResult.Result != 0)
                                    rocsScanningState[ident + "_event"] = false;
                            },
                            uiSyncContext)

                #endregion

                #region Опрос и сохранение данных аварий

                                .ContinueWith((saveEventDataLogResult) =>
                                {
                                    return GetAlarmData(point);
                                },
                                TaskContinuationOptions.LongRunning)
                                    .ContinueWith((getAlarmDataResult) =>
                                    {
                                        if (getAlarmDataResult.Exception != null)
                                        {
                                            LogException(log, "Ошибка опроса данных аварий точки №" + point.Number + " в историческом сегменте №" + point.HistSegment + " вычислителя ROC809 с адресом " + address, getAlarmDataResult.Exception, LogType.ROC);
                                            throw getAlarmDataResult.Exception;
                                        }
                                        else
                                            return getAlarmDataResult.Result;
                                    },
                                    uiSyncContext)
                                        .ContinueWith((getAlarmDataLogResult) =>
                                        {
                                            if (getAlarmDataLogResult.Exception == null)
                                            {
                                                if (getAlarmDataLogResult.Result.Count > 0)
                                                {
                                                    SaveAlarmData(point, getAlarmDataLogResult.Result);
                                                    return 1;
                                                }
                                                else
                                                    return 0;
                                            }
                                            else
                                                return -1;
                                        },
                                        TaskContinuationOptions.LongRunning)
                                            .ContinueWith((saveAlarmDataResult) =>
                                            {
                                                if (saveAlarmDataResult.Exception != null)
                                                    LogException(log, "Ошибка сохранения данных аварий точки №" + point.Number + " в историческом сегменте №" + point.HistSegment + " вычислителя ROC809 с адресом " + address, saveAlarmDataResult.Exception, LogType.ROC);
                                                else if (saveAlarmDataResult.Result == 1)
                                                    Logger.Log(log, new LogEntry { Message = "Опрос данных аварий точки №" + point.Number + " в историческом сегменте №" + point.HistSegment + " вычислителя ROC809 с адресом " + address + " выполнен успешно", Status = LogStatus.Success, Type = LogType.ROC, Timestamp = DateTime.Now });

                                                rocsScanningState[ident + "_alarm"] = false;
                                            },
                                            uiSyncContext)

                #endregion

                #region Опрос и сохранение минутных даных

                                .ContinueWith((saveAlarmDataLogResult) =>
                                {
                                    if (timeToMinuteData && !rocsScanningState[ident + "_minute"])
                                    {
                                        Task.Factory.StartNew(() => GetMinuteData(point), TaskCreationOptions.LongRunning)
                                            .ContinueWith((getMinuteDataResult) =>
                                            {
                                                if (getMinuteDataResult.Exception != null)
                                                {
                                                    LogException(log, "Ошибка опроса минутных данных точки №" + point.Number + " в историческом сегменте №" + point.HistSegment + " вычислителя ROC809 с адресом " + address, getMinuteDataResult.Exception, LogType.ROC);
                                                    throw getMinuteDataResult.Exception;
                                                }
                                                else
                                                    return getMinuteDataResult.Result;
                                            },
                                            uiSyncContext)
                                                .ContinueWith((getMinuteDataLogResult) =>
                                                {
                                                    if (getMinuteDataLogResult.Exception == null)
                                                    {
                                                        SaveMinuteData(point, getMinuteDataLogResult.Result);
                                                        return true;
                                                    }
                                                    else
                                                        return false;
                                                },
                                                TaskContinuationOptions.LongRunning)
                                                    .ContinueWith((saveMinuteDataResult) =>
                                                    {
                                                        if (saveMinuteDataResult.Exception != null)
                                                            LogException(log, "Ошибка сохранения минутных данных точки №" + point.Number + " в историческом сегменте №" + point.HistSegment + " вычислителя ROC809 с адресом " + address, saveMinuteDataResult.Exception, LogType.ROC);
                                                        else if (saveMinuteDataResult.Result)
                                                            Logger.Log(log, new LogEntry { Message = "Опрос минутных данных точки №" + point.Number + " в историческом сегменте №" + point.HistSegment + " вычислителя ROC809 с адресом " + address, Status = LogStatus.Success, Type = LogType.ROC, Timestamp = DateTime.Now });

                                                        rocsScanningState[ident + "_minute"] = false;
                                                    },
                                                    uiSyncContext);
                                    }

                                    #endregion

                #region Опрос и сохранение периодических данных

                                    if (timeToPeriodicData && !rocsScanningState[ident + "_periodic"])
                                    {
                                        Task.Factory.StartNew(() => GetPeriodicData(point), TaskCreationOptions.LongRunning)
                                            .ContinueWith((getPeriodicDataResult) =>
                                            {
                                                if (getPeriodicDataResult.Exception != null)
                                                {
                                                    LogException(log, "Ошибка опроса периодических данных точки №" + point.Number + " в историческом сегменте №" + point.HistSegment + " вычислителя ROC809 с адресом " + address, getPeriodicDataResult.Exception, LogType.ROC);
                                                    throw getPeriodicDataResult.Exception;
                                                }
                                                else
                                                    return getPeriodicDataResult.Result;
                                            },
                                            uiSyncContext)
                                                .ContinueWith((getPeriodicDataLogResult) =>
                                                {
                                                    if (getPeriodicDataLogResult.Exception == null)
                                                    {
                                                        SavePeriodicData(point, getPeriodicDataLogResult.Result);
                                                        return true;
                                                    }
                                                    else
                                                        return false;
                                                },
                                                TaskContinuationOptions.LongRunning)
                                                    .ContinueWith((savePeriodicDataResult) =>
                                                    {
                                                        if (savePeriodicDataResult.Exception != null)
                                                            LogException(log, "Ошибка сохранения периодических данных точки №" + point.Number + " в историческом сегменте №" + point.HistSegment + " вычислителя ROC809 с адресом " + address, savePeriodicDataResult.Exception, LogType.ROC);
                                                        else if (savePeriodicDataResult.Result)
                                                            Logger.Log(log, new LogEntry { Message = "Опрос периодических данных точки №" + point.Number + " в историческом сегменте №" + point.HistSegment + " вычислителя ROC809 с адресом " + address, Status = LogStatus.Success, Type = LogType.ROC, Timestamp = DateTime.Now });

                                                        rocsScanningState[ident + "_periodic"] = false;
                                                    },
                                                    uiSyncContext);
                                    }

                                    #endregion

                #region Опрос и сохранение суточных данных

                                    if (timeToDailyData && !rocsScanningState[ident + "_daily"])
                                    {
                                        Task.Factory.StartNew(() => GetDailyData(point), TaskCreationOptions.LongRunning)
                                            .ContinueWith((getDailyDataResult) =>
                                            {
                                                if (getDailyDataResult.Exception != null)
                                                {
                                                    LogException(log, "Ошибка опроса суточных данных точки №" + point.Number + " в историческом сегменте №" + point.HistSegment + " вычислителя ROC809 с адресом " + address, getDailyDataResult.Exception, LogType.ROC);
                                                    throw getDailyDataResult.Exception;
                                                }
                                                else
                                                    return getDailyDataResult.Result;
                                            },
                                            uiSyncContext)
                                                .ContinueWith((getDailyDataLogResult) =>
                                                {
                                                    if (getDailyDataLogResult.Exception == null)
                                                    {
                                                        SaveDailyData(point, getDailyDataLogResult.Result);
                                                        return true;
                                                    }
                                                    else
                                                        return false;
                                                },
                                                TaskContinuationOptions.LongRunning)
                                                    .ContinueWith((saveDailyDataResult) =>
                                                    {
                                                        if (saveDailyDataResult.Exception != null)
                                                            LogException(log, "Ошибка сохранения суточных данных точки №" + point.Number + " в историческом сегменте №" + point.HistSegment + " вычислителя ROC809 с адресом " + address, saveDailyDataResult.Exception, LogType.ROC);
                                                        else if (saveDailyDataResult.Result)
                                                            Logger.Log(log, new LogEntry { Message = "Опрос суточных данных точки №" + point.Number + " в историческом сегменте №" + point.HistSegment + " вычислителя ROC809 с адресом " + address, Status = LogStatus.Success, Type = LogType.ROC, Timestamp = DateTime.Now });

                                                        rocsScanningState[ident + "_daily"] = false;
                                                    },
                                                    uiSyncContext);
                                    }
                                },
                                TaskContinuationOptions.LongRunning);

                #endregion
            }
        }

        #endregion

        #region Вспомогательные методы

        private FloutecIdentData GetIdentData(FloutecMeasureLine line)
        {
            int address = ((Floutec)line.Estimator).Address;
            int n_flonit = address * 10 + line.Number;

            if (!floutecsScanningState[n_flonit.ToString() + "_ident"])
            {
#if DEBUG
                Debug.WriteLine("Опрос данных идентификации нитки №" + line.Number + " вычислителя с адресом " + address);
#endif
                floutecsScanningState[n_flonit.ToString() + "_ident"] = true;

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
                using (SqlRepository<FloutecIdentData> repo = new SqlRepository<FloutecIdentData>(connection))
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
                    using (SqlRepository<FloutecHourlyData> repo = new SqlRepository<FloutecHourlyData>(connection))
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
                using (SqlRepository<FloutecMeasureLine> repo = new SqlRepository<FloutecMeasureLine>(connection))
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
                    using (SqlRepository<FloutecInstantData> repo = new SqlRepository<FloutecInstantData>(connection))
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
                using (SqlRepository<FloutecMeasureLine> repo = new SqlRepository<FloutecMeasureLine>(connection))
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

        private List<FloutecAlarmData> GetAlarmData(FloutecMeasureLine line)
        {
            int address = ((Floutec)line.Estimator).Address;
            int n_flonit = address * 10 + line.Number;

            if (!floutecsScanningState[n_flonit.ToString() + "_alarm"])
            {
                floutecsScanningState[n_flonit.ToString() + "_alarm"] = true;

                List<FloutecAlarmData> alarmData = new List<FloutecAlarmData>();

                try
                {
                    using (DbfRepository repo = new DbfRepository(Settings.DbfTablesPath))
                    {
                        if (line.AlarmData.Count == 0)
                            alarmData = repo.GetAllAlarmData(address, line.Number);
                        else
                            alarmData = repo.GetAlarmData(address, line.Number, line.AlarmData.OrderBy(o => o.DAT).Last().DAT, DateTime.Now);

                        return alarmData;
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                return null;
            }
        }

        private void SaveAlarmData(FloutecMeasureLine line, List<FloutecAlarmData> data)
        {
            if (data.Count > 0)
            {
                data.ForEach((a) =>
                {
                    a.DateCreated = DateTime.Now;
                    a.DateModified = DateTime.Now;
                    a.FloutecMeasureLineId = line.Id;
                });

                try
                {
                    using (SqlRepository<FloutecAlarmData> repo = new SqlRepository<FloutecAlarmData>(connection))
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

        private List<FloutecInterData> GetInterData(FloutecMeasureLine line)
        {
            int address = ((Floutec)line.Estimator).Address;
            int n_flonit = address * 10 + line.Number;

            if (!floutecsScanningState[n_flonit.ToString() + "_inter"])
            {
                floutecsScanningState[n_flonit.ToString() + "_inter"] = true;

                List<FloutecInterData> interData = new List<FloutecInterData>();

                try
                {
                    using (DbfRepository repo = new DbfRepository(Settings.DbfTablesPath))
                    {
                        if (line.InterData.Count == 0)
                            interData = repo.GetAllInterData(address, line.Number);
                        else
                            interData = repo.GetInterData(address, line.Number, line.InterData.OrderBy(o => o.DAT).Last().DAT, DateTime.Now);

                        return interData;
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                return null;
            }
        }

        private void SaveInterData(FloutecMeasureLine line, List<FloutecInterData> data)
        {
            if (data.Count > 0)
            {
                data.ForEach((i) =>
                {
                    i.DateCreated = DateTime.Now;
                    i.DateModified = DateTime.Now;
                    i.FloutecMeasureLineId = line.Id;
                });

                try
                {
                    using (SqlRepository<FloutecInterData> repo = new SqlRepository<FloutecInterData>(connection))
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

        private List<FloutecMeasureLine> GetLinesForScanning()
        {
            List<FloutecMeasureLine> lines;

            try
            {
                using (SqlRepository<FloutecMeasureLine> repo = new SqlRepository<FloutecMeasureLine>(connection))
                {
                    lines = repo.GetAll()
                    .Include(l => l.HourlyData)
                    .Include(l => l.IdentData)
                    .Include(l => l.InstantData)
                    .Include(l => l.AlarmData)
                    .Include(l => l.InterData)
                    .Include(l => l.Estimator)
                    .Where(l => !l.IsDeleted && !l.Estimator.IsDeleted)
                    .ToList();

                    if (floutecsScanningState == null)
                    {
                        floutecsScanningState = new Dictionary<string, bool>();

                        lines.ForEach((l) =>
                        {
                            int address = ((Floutec)l.Estimator).Address;
                            int n_flonit = address * 10 + l.Number;

                            floutecsScanningState.Add(n_flonit.ToString() + "_ident", false);
                            floutecsScanningState.Add(n_flonit.ToString() + "_alarm", false);
                            floutecsScanningState.Add(n_flonit.ToString() + "_inter", false);
                            floutecsScanningState.Add(n_flonit.ToString() + "_inst", false);
                            floutecsScanningState.Add(n_flonit.ToString() + "_hour", false);
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

        private List<ROC809MeasurePoint> GetPointsForScanning()
        {
            List<ROC809MeasurePoint> points;

            try
            {
                using (SqlRepository<ROC809MeasurePoint> repo = new SqlRepository<ROC809MeasurePoint>(connection))
                {
                    points = repo.GetAll()
                        .Include(p => p.DailyData)
                        .Include(p => p.Estimator)
                        .Include(p => p.MinuteData)
                        .Include(p => p.PeriodicData)
                        .Include(p => p.DailyData)
                        .Include(p => p.AlarmData)
                        .Include(p => p.EventData)
                        .Where(p => !p.IsDeleted && !p.Estimator.IsDeleted)
                        .ToList();

                    if (rocsScanningState == null)
                    {
                        rocsScanningState = new Dictionary<string, bool>();

                        points.ForEach((p) =>
                        {
                            string address = ((ROC809)p.Estimator).Address;
                            string ident = address + "_" + p.Number + "_" + p.HistSegment;

                            rocsScanningState.Add(ident + "_minute", false);
                            rocsScanningState.Add(ident + "_periodic", false);
                            rocsScanningState.Add(ident + "_daily", false);
                            rocsScanningState.Add(ident + "_event", false);
                            rocsScanningState.Add(ident + "_alarm", false);
                        });
                    }
                    return points;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private List<ROC809EventData> GetEventData(ROC809MeasurePoint point)
        {
            string address = ((ROC809)point.Estimator).Address;
            string ident = address + "_" + point.Number + "_" + point.HistSegment;

            List<ROC809EventData> eventData = new List<ROC809EventData>();

            if (!rocsScanningState[ident + "_event"])
            {
                rocsScanningState[ident + "_event"] = true;

                try
                {
                    ROC809DataService ext = new ROC809DataService();
                    eventData = ext.GetEventData(point);

                    if (eventData.Count > 0)
                    {
                        ROC809EventData lastData = point.EventData.OrderBy(o => o.Time).LastOrDefault();

                        if (lastData != null)
                            return eventData.Where(e => e.Time > lastData.Time).ToList();                        
                    }

                    return eventData;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                return null;
            }
        }

        private List<ROC809AlarmData> GetAlarmData(ROC809MeasurePoint point)
        {
            string address = ((ROC809)point.Estimator).Address;
            string ident = address + "_" + point.Number + "_" + point.HistSegment;

            List<ROC809AlarmData> alarmData = new List<ROC809AlarmData>();

            if (!rocsScanningState[ident + "_alarm"])
            {
                rocsScanningState[ident + "_alarm"] = true;

                try
                {
                    ROC809DataService ext = new ROC809DataService();
                    //alarmData = ext.GetAlarmData(point);

                    if (alarmData.Count > 0)
                    {
                        DateTime? lastData = point.AlarmData.OrderBy(o => o.Time).LastOrDefault().Time;

                        if (lastData.HasValue)
                            return alarmData.Where(e => e.Time > lastData.Value).ToList();
                    }

                    return alarmData;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                return alarmData;
            }
        }

        private void SaveEventData(ROC809MeasurePoint point, List<ROC809EventData> data)
        {
            if (data.Count > 0)
            {
                data.ForEach((d) =>
                {
                    d.DateCreated = DateTime.Now;
                    d.DateModified = DateTime.Now;
                    d.ROC809MeasurePointId = point.Id;
                });

                try
                {
                    using (SqlRepository<ROC809EventData> repo = new SqlRepository<ROC809EventData>(connection))
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

        private void SaveAlarmData(ROC809MeasurePoint point, List<ROC809AlarmData> data)
        {
            if (data.Count > 0)
            {
                data.ForEach((d) =>
                {
                    d.DateCreated = DateTime.Now;
                    d.DateModified = DateTime.Now;
                    d.ROC809MeasurePointId = point.Id;
                });

                try
                {
                    using (SqlRepository<ROC809AlarmData> repo = new SqlRepository<ROC809AlarmData>(connection))
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

        private List<ROC809MinuteData> GetMinuteData(ROC809MeasurePoint point)
        {
            dateStartMinuteDataScan = DateTime.Now;

            List<ROC809MinuteData> minuteData = new List<ROC809MinuteData>();

            try
            {
                //ROC809Extensions ext = new ROC809Extensions();
                //var result = ext.GetPeriodicData(point, ROC809HistoryType.Minute);

                //if (result.Count > 0)
                //{
                //    DateTime? lastData = point.MinuteData.OrderBy(o => o.DatePeriod).LastOrDefault().DatePeriod;

                //    if (!lastData.HasValue)
                //    {
                //        foreach (var item in result)
                //        {
                //            minuteData.Add(new ROC809MinuteData() { DatePeriod = item.DatePeriod, Value = item.Value });
                //        }
                //    }
                //    else
                //    {
                //        foreach (var item in result.Where(m => m.DatePeriod > lastData.Value))
                //        {
                //            minuteData.Add(new ROC809MinuteData() { DatePeriod = item.DatePeriod, Value = item.Value });
                //        }
                //    }
                //}

                return minuteData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void SaveMinuteData(ROC809MeasurePoint point, List<ROC809MinuteData> data)
        {
            if (data.Count > 0)
            {
                data.ForEach((d) =>
                {
                    d.DateCreated = DateTime.Now;
                    d.DateModified = DateTime.Now;
                    d.ROC809MeasurePointId = point.Id;
                });

                try
                {
                    using (SqlRepository<ROC809MinuteData> repo = new SqlRepository<ROC809MinuteData>(connection))
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
                using (SqlRepository<ROC809MeasurePoint> repo = new SqlRepository<ROC809MeasurePoint>(connection))
                {
                    ROC809MeasurePoint existingPoint = repo.Get(point.Id);
                    existingPoint.DateMinuteDataLastScanned = dateStartMinuteDataScan;
                    repo.Update(existingPoint);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private List<ROC809PeriodicData> GetPeriodicData(ROC809MeasurePoint point)
        {
            dateStartPeriodicDataScan = DateTime.Now;

            List<ROC809PeriodicData> periodicData = new List<ROC809PeriodicData>();

            try
            {
                //ROC809Extensions ext = new ROC809Extensions();
                //var result = ext.GetPeriodicData(point, ROC809HistoryType.Periodic);

                //if (result.Count > 0)
                //{
                //    DateTime? lastData = point.PeriodicData.OrderBy(o => o.DatePeriod).LastOrDefault().DatePeriod;

                //    if (!lastData.HasValue)
                //    {
                //        foreach (var item in result)
                //        {
                //            periodicData.Add(new ROC809PeriodicData() { DatePeriod = item.DatePeriod, Value = item.Value });
                //        }
                //    }
                //    else
                //    {
                //        foreach (var item in result.Where(m => m.DatePeriod > lastData.Value))
                //        {
                //            periodicData.Add(new ROC809PeriodicData() { DatePeriod = item.DatePeriod, Value = item.Value });
                //        }
                //    }
                //}

                return periodicData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void SavePeriodicData(ROC809MeasurePoint point, List<ROC809PeriodicData> data)
        {
            if (data.Count > 0)
            {
                data.ForEach((d) =>
                {
                    d.DateCreated = DateTime.Now;
                    d.DateModified = DateTime.Now;
                    d.ROC809MeasurePointId = point.Id;
                });

                try
                {
                    using (SqlRepository<ROC809PeriodicData> repo = new SqlRepository<ROC809PeriodicData>(connection))
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
                using (SqlRepository<ROC809MeasurePoint> repo = new SqlRepository<ROC809MeasurePoint>(connection))
                {
                    ROC809MeasurePoint existingPoint = repo.Get(point.Id);
                    existingPoint.DatePeriodicDataLastScanned = dateStartPeriodicDataScan;
                    repo.Update(existingPoint);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private List<ROC809DailyData> GetDailyData(ROC809MeasurePoint point)
        {
            dateStartDailyDataScan = DateTime.Now;

            List<ROC809DailyData> dailyData = new List<ROC809DailyData>();

            try
            {
                //ROC809Extensions ext = new ROC809Extensions();
                //var result = ext.GetPeriodicData(point, ROC809HistoryType.Daily);

                //if (result.Count > 0)
                //{
                //    DateTime? lastData = point.DailyData.OrderBy(o => o.DatePeriod).LastOrDefault().DatePeriod;

                //    if (!lastData.HasValue)
                //    {
                //        foreach (var item in result)
                //        {
                //            dailyData.Add(new ROC809DailyData() { DatePeriod = item.DatePeriod, Value = item.Value });
                //        }
                //    }
                //    else
                //    {
                //        foreach (var item in result.Where(m => m.DatePeriod > lastData.Value))
                //        {
                //            dailyData.Add(new ROC809DailyData() { DatePeriod = item.DatePeriod, Value = item.Value });
                //        }
                //    }
                //}

                return dailyData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void SaveDailyData(ROC809MeasurePoint point, List<ROC809DailyData> data)
        {
            if (data.Count > 0)
            {
                data.ForEach((d) =>
                {
                    d.DateCreated = DateTime.Now;
                    d.DateModified = DateTime.Now;
                    d.ROC809MeasurePointId = point.Id;
                });

                try
                {
                    using (SqlRepository<ROC809DailyData> repo = new SqlRepository<ROC809DailyData>(connection))
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
                using (SqlRepository<ROC809MeasurePoint> repo = new SqlRepository<ROC809MeasurePoint>(connection))
                {
                    ROC809MeasurePoint existingPoint = repo.Get(point.Id);
                    existingPoint.DateDailyDataLastScanned = dateStartDailyDataScan;
                    repo.Update(existingPoint);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void LogException(LogListView log, string message, AggregateException exception, LogType type)
        {
            Logger.Log(log, new LogEntry { Message = message, Status = LogStatus.Error, Timestamp = DateTime.Now, Type = type });
            Logger.Log(log, new LogEntry { Message = exception.Message, Status = LogStatus.Error, Timestamp = DateTime.Now, Type = type });
            foreach (var item in exception.InnerExceptions)
            {
                Logger.Log(log, new LogEntry { Message = item.Message, Status = LogStatus.Error, Type = type, Timestamp = DateTime.Now });
            }
        }

        #endregion
    }
}
