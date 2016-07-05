using NGVSCAN.CORE.Entities.Floutecs;
using NGVSCAN.CORE.Entities.ROC809s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NGVSCAN.EXEC.Controls;

namespace NGVSCAN.EXEC.Common
{
    /// <summary>
    /// Класс для выполнения опроса вычислителей
    /// </summary>
    public partial class Scanner
    {
        #region Конструктор и поля

        // Переменные для отслеживания состояния опроса ниток и точек
        private Dictionary<string, bool> floutecsScanningState;
        private Dictionary<string, bool> rocsScanningState;

        // Переменные для хранения времени начала опроса данных вычислителей
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
                                if (getIdentDataLogResult.Result == null)
                                    return 0;
                                else if (getIdentDataLogResult.Result.N_FLONIT == 0)
                                    return 1;
                                else
                                {
                                    SaveIdentData(line, getIdentDataLogResult.Result);
                                    return 2;
                                }
                            }
                            else
                                return -1;
                        },
                        TaskContinuationOptions.LongRunning)
                            .ContinueWith((saveIdentDataResult) =>
                            {
                                if (saveIdentDataResult.Exception != null)
                                {
                                    LogException(log, "Ошибка сохранения данных идентификации нитки №" + line.Number + " вычислителя ФЛОУТЭК с адресом " + address, saveIdentDataResult.Exception, LogType.ROC);
                                    floutecsScanningState[n_flonit.ToString() + "_ident"] = false;
                                }
                                else if (saveIdentDataResult.Result == 1)
                                    Logger.Log(log, new LogEntry { Message = "Данные событий нитки №" + line.Number + " вычислителя ФЛОУТЭК с адресом " + address + " отсутствуют", Status = LogStatus.Success, Type = LogType.Floutec, Timestamp = DateTime.Now });
                                else if (saveIdentDataResult.Result == 2)
                                    Logger.Log(log, new LogEntry { Message = "Опрос данных идентификации нитки №" + line.Number + " вычислителя ФЛОУТЭК с адресом " + address + " выполнен успешно", Status = LogStatus.Success, Type = LogType.Floutec, Timestamp = DateTime.Now });

                                if (saveIdentDataResult.Result != 0)
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
                                                if (getAlarmDataLogResult.Result == null)
                                                    return 0;
                                                else if (getAlarmDataLogResult.Result.Count == 0)
                                                    return 1;
                                                else
                                                {
                                                    SaveAlarmData(line, getAlarmDataLogResult.Result);
                                                    return 2;
                                                }
                                            }
                                            else
                                                return -1;
                                        },
                                        TaskContinuationOptions.LongRunning)
                                            .ContinueWith((saveAlarmDataResult) =>
                                            {
                                                if (saveAlarmDataResult.Exception != null)
                                                {
                                                    LogException(log, "Ошибка сохранения данных аварий нитки №" + line.Number + " вычислителя ФЛОУТЭК с адресом " + address, saveAlarmDataResult.Exception, LogType.ROC);
                                                    floutecsScanningState[n_flonit.ToString() + "_alarm"] = false;
                                                }
                                                else if (saveAlarmDataResult.Result == 1)
                                                    Logger.Log(log, new LogEntry { Message = "Данные аварий нитки №" + line.Number + " вычислителя ФЛОУТЭК с адресом " + address + " отсутствуют", Status = LogStatus.Success, Type = LogType.Floutec, Timestamp = DateTime.Now });
                                                else if (saveAlarmDataResult.Result == 2)
                                                    Logger.Log(log, new LogEntry { Message = "Опрос данных аварий нитки №" + line.Number + " вычислителя ФЛОУТЭК с адресом " + address + " выполнен успешно", Status = LogStatus.Success, Type = LogType.Floutec, Timestamp = DateTime.Now });

                                                if (saveAlarmDataResult.Result != 0)
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
                                                                if (getInterDataLogResult.Result == null)
                                                                    return 0;
                                                                else if (getInterDataLogResult.Result.Count == 0)
                                                                    return 1;
                                                                else
                                                                {
                                                                    SaveInterData(line, getInterDataLogResult.Result);
                                                                    return 2;
                                                                }
                                                            }
                                                            else
                                                                return -1;
                                                        },
                                                        TaskContinuationOptions.LongRunning)
                                                            .ContinueWith((saveInterDataResult) =>
                                                            {
                                                                if (saveInterDataResult.Exception != null)
                                                                {
                                                                    LogException(log, "Ошибка сохранения данных вмешательств нитки №" + line.Number + " вычислителя ФЛОУТЭК с адресом " + address, saveInterDataResult.Exception, LogType.ROC);
                                                                    floutecsScanningState[n_flonit.ToString() + "_inter"] = false;
                                                                }
                                                                else if (saveInterDataResult.Result == 1)
                                                                    Logger.Log(log, new LogEntry { Message = "Данные вмешательств нитки №" + line.Number + " вычислителя ФЛОУТЭК с адресом " + address + " отсутствуют", Status = LogStatus.Success, Type = LogType.Floutec, Timestamp = DateTime.Now });
                                                                else if (saveInterDataResult.Result == 2)
                                                                    Logger.Log(log, new LogEntry { Message = "Опрос данных вмешательств нитки №" + line.Number + " вычислителя ФЛОУТЭК с адресом " + address + " выполнен успешно", Status = LogStatus.Success, Type = LogType.Floutec, Timestamp = DateTime.Now });

                                                                if (saveInterDataResult.Result != 0)
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

                                                                                        if (getHourlyDataLogResult.Result.Count == 0)
                                                                                            return 0;
                                                                                        else
                                                                                            return 1;
                                                                                    }
                                                                                    else
                                                                                        return -1;
                                                                                },
                                                                                TaskContinuationOptions.LongRunning)
                                                                                    .ContinueWith((saveHourlyDataResult) => 
                                                                                    {
                                                                                        if (saveHourlyDataResult.Exception != null)
                                                                                            LogException(log, "Ошибка сохранения часовых данных нитки №" + line.Number + " вычислителя ФЛОУТЭК с адресом " + address, saveHourlyDataResult.Exception, LogType.Floutec);
                                                                                        else if (saveHourlyDataResult.Result == 0)
                                                                                            Logger.Log(log, new LogEntry { Message = "Часовые данные нитки №" + line.Number + " вычислителя ФЛОУТЭК с адресом " + address + " отсутствуют", Status = LogStatus.Warning, Type = LogType.Floutec, Timestamp = DateTime.Now });
                                                                                        else if (saveHourlyDataResult.Result == 1)
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

                                                                                        if (getInstantDataLogResult.Result == null)
                                                                                            return 0;
                                                                                        else 
                                                                                            return 1;
                                                                                    }
                                                                                    else
                                                                                        return -1;
                                                                                },
                                                                                TaskContinuationOptions.LongRunning)
                                                                                    .ContinueWith((saveInstantDataResult) =>
                                                                                    {
                                                                                        if (saveInstantDataResult.Exception != null)
                                                                                            LogException(log, "Ошибка сохранения мгновенных данных нитки №" + line.Number + " вычислителя ФЛОУТЭК с адресом " + address, saveInstantDataResult.Exception, LogType.Floutec);
                                                                                        else if (saveInstantDataResult.Result == 0)
                                                                                            Logger.Log(log, new LogEntry { Message = "Мгновенные данные нитки №" + line.Number + " вычислителя ФЛОУТЭК с адресом " + address + " отсутствуют", Status = LogStatus.Warning, Type = LogType.Floutec, Timestamp = DateTime.Now });
                                                                                        else if (saveInstantDataResult.Result == 1)
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
                                else if (saveEventDataResult.Result == 1)
                                    Logger.Log(log, new LogEntry { Message = "Данные событий точки №" + point.Number + " в историческом сегменте №" + point.HistSegment + " вычислителя ROC809 с адресом " + address + " отсутствуют", Status = LogStatus.Success, Type = LogType.ROC, Timestamp = DateTime.Now });
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
                                                if (getAlarmDataLogResult.Result == null)
                                                    return 0;
                                                else if (getAlarmDataLogResult.Result.Count == 0)
                                                    return 1;
                                                else
                                                {
                                                    SaveAlarmData(point, getAlarmDataLogResult.Result);
                                                    return 2;
                                                }
                                            }
                                            else
                                                return -1;
                                        },
                                        TaskContinuationOptions.LongRunning)
                                            .ContinueWith((saveAlarmDataResult) =>
                                            {
                                                if (saveAlarmDataResult.Exception != null)
                                                {
                                                    LogException(log, "Ошибка сохранения данных аварий точки №" + point.Number + " в историческом сегменте №" + point.HistSegment + " вычислителя ROC809 с адресом " + address, saveAlarmDataResult.Exception, LogType.ROC);
                                                    rocsScanningState[ident + "_alarm"] = false;
                                                }
                                                else if (saveAlarmDataResult.Result == 1)
                                                    Logger.Log(log, new LogEntry { Message = "Данные аварий точки №" + point.Number + " в историческом сегменте №" + point.HistSegment + " вычислителя ROC809 с адресом " + address + " отсутствуют", Status = LogStatus.Success, Type = LogType.ROC, Timestamp = DateTime.Now });
                                                else if (saveAlarmDataResult.Result == 2)
                                                    Logger.Log(log, new LogEntry { Message = "Опрос данных аварий точки №" + point.Number + " в историческом сегменте №" + point.HistSegment + " вычислителя ROC809 с адресом " + address + " выполнен успешно", Status = LogStatus.Success, Type = LogType.ROC, Timestamp = DateTime.Now });

                                                if (saveAlarmDataResult.Result != 0)
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

                                                        if (getMinuteDataLogResult.Result.Count == 0)
                                                            return 0;
                                                        else
                                                            return 1;
                                                    }
                                                    else
                                                        return -1;
                                                },
                                                TaskContinuationOptions.LongRunning)
                                                    .ContinueWith((saveMinuteDataResult) =>
                                                    {
                                                        if (saveMinuteDataResult.Exception != null)
                                                            LogException(log, "Ошибка сохранения минутных данных точки №" + point.Number + " в историческом сегменте №" + point.HistSegment + " вычислителя ROC809 с адресом " + address, saveMinuteDataResult.Exception, LogType.ROC);
                                                        else if (saveMinuteDataResult.Result == 0)
                                                            Logger.Log(log, new LogEntry { Message = "Минутные данные точки №" + point.Number + " в историческом сегменте №" + point.HistSegment + " вычислителя ROC809 с адресом " + address + " отсутствуют", Status = LogStatus.Warning, Type = LogType.ROC, Timestamp = DateTime.Now });
                                                        else if (saveMinuteDataResult.Result == 1)
                                                            Logger.Log(log, new LogEntry { Message = "Опрос минутных данных точки №" + point.Number + " в историческом сегменте №" + point.HistSegment + " вычислителя ROC809 с адресом " + address + " выполнен успешно", Status = LogStatus.Success, Type = LogType.ROC, Timestamp = DateTime.Now });

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

                                                        if (getPeriodicDataLogResult.Result.Count == 0)
                                                            return 0;
                                                        else
                                                            return 1;
                                                    }
                                                    else
                                                        return -1;
                                                },
                                                TaskContinuationOptions.LongRunning)
                                                    .ContinueWith((savePeriodicDataResult) =>
                                                    {
                                                        if (savePeriodicDataResult.Exception != null)
                                                            LogException(log, "Ошибка сохранения периодических данных точки №" + point.Number + " в историческом сегменте №" + point.HistSegment + " вычислителя ROC809 с адресом " + address, savePeriodicDataResult.Exception, LogType.ROC);
                                                        else if (savePeriodicDataResult.Result == 0)
                                                            Logger.Log(log, new LogEntry { Message = "Периодические данные точки №" + point.Number + " в историческом сегменте №" + point.HistSegment + " вычислителя ROC809 с адресом " + address + " отсутствуют", Status = LogStatus.Warning, Type = LogType.ROC, Timestamp = DateTime.Now });
                                                        else if (savePeriodicDataResult.Result == 1)
                                                            Logger.Log(log, new LogEntry { Message = "Опрос периодических данных точки №" + point.Number + " в историческом сегменте №" + point.HistSegment + " вычислителя ROC809 с адресом " + address + " выполнен успешно", Status = LogStatus.Success, Type = LogType.ROC, Timestamp = DateTime.Now });

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

                                                        if (getDailyDataLogResult.Result.Count == 0)
                                                            return 0;
                                                        else
                                                            return 1;
                                                    }
                                                    else
                                                        return -1;
                                                },
                                                TaskContinuationOptions.LongRunning)
                                                    .ContinueWith((saveDailyDataResult) =>
                                                    {
                                                        if (saveDailyDataResult.Exception != null)
                                                            LogException(log, "Ошибка сохранения суточных данных точки №" + point.Number + " в историческом сегменте №" + point.HistSegment + " вычислителя ROC809 с адресом " + address, saveDailyDataResult.Exception, LogType.ROC);
                                                        else if (saveDailyDataResult.Result == 0)
                                                            Logger.Log(log, new LogEntry { Message = "Суточные данные точки №" + point.Number + " в историческом сегменте №" + point.HistSegment + " вычислителя ROC809 с адресом " + address + " отсутствуют", Status = LogStatus.Warning, Type = LogType.ROC, Timestamp = DateTime.Now });
                                                        else if (saveDailyDataResult.Result == 1)
                                                            Logger.Log(log, new LogEntry { Message = "Опрос суточных данных точки №" + point.Number + " в историческом сегменте №" + point.HistSegment + " вычислителя ROC809 с адресом " + address + " выполнен успешно", Status = LogStatus.Success, Type = LogType.ROC, Timestamp = DateTime.Now });

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
    }
}
