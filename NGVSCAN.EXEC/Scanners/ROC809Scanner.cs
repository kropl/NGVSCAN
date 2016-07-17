using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using NGVSCAN.CORE.Entities.ROC809s;
using NGVSCAN.DAL.Repositories;
using NGVSCAN.DAL.ROC809Connection;
using NGVSCAN.EXEC.Common;
using NGVSCAN.EXEC.Controls;

namespace NGVSCAN.EXEC.Scanners
{
    public class ROC809Scanner
    {
        #region Конструктор и поля

        private IDictionary<string, bool> _scanningState;
        private static string _sqlConnection;
        private LogListView _log;
        private TaskScheduler _uiSyncContext;

        public ROC809Scanner(LogListView log)
        {
            _log = log;
            _scanningState = new Dictionary<string, bool>();
            _uiSyncContext = TaskScheduler.FromCurrentSynchronizationContext();
        }

        #endregion

        public void Process(int fieldId, string sqlConnection)
        {
            _sqlConnection = sqlConnection;

            Task<List<ROC809MeasurePoint>> mainTask = Task.Factory.StartNew(() =>
            {
                return GetPointsForScanning(fieldId);
            },
            TaskCreationOptions.LongRunning);

            Task<List<ROC809MeasurePoint>> logMainTaskResultTask = mainTask.ContinueWith((result) => 
            {
                if (result.Exception != null)
                {
                    LogException(_log, "Ошибка построения списка вычислителей ROC809", result.Exception, LogType.ROC);
                    return null;
                }
                else
                    return result.Result;
            },
            _uiSyncContext);

            Task processPointsTask = logMainTaskResultTask.ContinueWith((result) =>
            {
                if (result.Result != null)
                    result.Result.ForEach((p) => ProcessPoint(p));
            },
            TaskContinuationOptions.LongRunning);
        }

        private List<ROC809MeasurePoint> GetPointsForScanning(int fieldId)
        {
            try
            {
                List<ROC809MeasurePoint> points;

                using (SqlRepository<ROC809MeasurePoint> repo = new SqlRepository<ROC809MeasurePoint>(_sqlConnection))
                {
                    points = repo.GetAll()
                        .Where(p => !p.IsDeleted && !p.Estimator.IsDeleted && p.Estimator.FieldId == fieldId)
                        .Include(p => p.Estimator)
                        .ToList();

                    InitScanningState(points);
                }

                return points;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void InitScanningState(List<ROC809MeasurePoint> points)
        {
            if (points != null && points.Any())
            {
                points.ForEach((p) =>
                {
                    string address = ((ROC809)p.Estimator).Address;
                    string ident = address + "_" + p.Number + "_" + p.HistSegment;

                    if (!_scanningState.ContainsKey(ident))
                    {
                        _scanningState.Add(ident, false);
                        _scanningState.Add(ident + "_minute", false);
                        _scanningState.Add(ident + "_periodic", false);
                        _scanningState.Add(ident + "_daily", false);
                        _scanningState.Add(ident + "_event", false);
                        _scanningState.Add(ident + "_alarm", false);
                    }
                });
            }
        }

        private void ProcessPoint(ROC809MeasurePoint point)
        {
            string address = ((ROC809)point.Estimator).Address;
            string ident = address + "_" + point.Number + "_" + point.HistSegment;

            bool timeToMinuteData = !point.DateMinuteDataLastScanned.HasValue || point.DateMinuteDataLastScanned.Value.AddMinutes(point.MinuteDataScanPeriod) <= DateTime.Now;
            bool timeToPeriodicData = !point.DatePeriodicDataLastScanned.HasValue || point.DatePeriodicDataLastScanned.Value.AddMinutes(point.PeriodicDataScanPeriod) <= DateTime.Now;
            bool timeToDailyData = !point.DateDailyDataLastScanned.HasValue || point.DateDailyDataLastScanned.Value.AddMinutes(point.DailyDataScanPeriod) <= DateTime.Now;

            if ((timeToMinuteData && !_scanningState[ident + "_minute"]) ||
                (timeToPeriodicData && !_scanningState[ident + "_periodic"]) ||
                (timeToDailyData && !_scanningState[ident + "_daily"]))
            {
                Task processPointTask = Task.Factory.StartNew(() =>
                {
                    #region Задачи для ROC809EventData

                    if (!_scanningState[ident + "_event"])
                    {
                        Task<List<ROC809EventData>> getEventDataTask = Task.Factory.StartNew(() =>
                        {
                            _scanningState[ident + "_event"] = true;
                            return GetEventData(point);
                        },
                        TaskCreationOptions.LongRunning);

                        Task<List<ROC809EventData>> logGetEventDataResultTask = getEventDataTask.ContinueWith((result) =>
                        {
                            if (result.Exception != null)
                            {
                                LogException(_log, "Ошибка опроса данных событий вычислителя ROC809 с адресом " + address, result.Exception, LogType.ROC);
                                throw result.Exception;
                            }
                            else
                                return result.Result;
                        },
                        _uiSyncContext);

                        Task<int> saveEventDataTask = logGetEventDataResultTask.ContinueWith((result) =>
                        {
                            if (result.Exception == null)
                                return SaveEventData(point, result.Result);
                            else
                                return -1;
                        },
                        TaskContinuationOptions.LongRunning);

                        Task logSaveEventDataTask = saveEventDataTask.ContinueWith((result) =>
                        {
                            if (result.Exception != null)
                                LogException(_log, "Ошибка сохранения данных событий вычислителя ROC809 с адресом " + address, result.Exception, LogType.ROC);
                            else if (result.Result == 0)
                                Logger.Log(_log, new LogEntry { Message = "Опрос данных событий вычислителя ROC809 с адресом " + address + " выполнен успешно. Новые данные отсутствуют", Status = LogStatus.Success, Type = LogType.ROC, Timestamp = DateTime.Now });
                            else if (result.Result > 0)
                                Logger.Log(_log, new LogEntry { Message = "Опрос данных событий вычислителя ROC809 с адресом " + address + " выполнен успешно. Добавлено данных: " + result.Result, Status = LogStatus.Success, Type = LogType.ROC, Timestamp = DateTime.Now });

                            _scanningState[ident + "_event"] = false;
                        },
                        _uiSyncContext);
                    }

                    #endregion

                    #region Задачи для ROC809AlarmData

                    if (!_scanningState[ident + "_alarm"])
                    {
                        Task<List<ROC809AlarmData>> getAlarmDataTask = Task.Factory.StartNew(() =>
                        {
                            _scanningState[ident + "_alarm"] = true;
                            return GetAlarmData(point);
                        },
                        TaskCreationOptions.LongRunning);

                        Task<List<ROC809AlarmData>> logGetAlarmDataResultTask = getAlarmDataTask.ContinueWith((result) =>
                        {
                            if (result.Exception != null)
                            {
                                LogException(_log, "Ошибка опроса данных аварий вычислителя ROC809 с адресом " + address, result.Exception, LogType.ROC);
                                throw result.Exception;
                            }
                            else
                                return result.Result;
                        },
                        _uiSyncContext);

                        Task<int> saveAlarmDataTask = logGetAlarmDataResultTask.ContinueWith((result) =>
                        {
                            if (result.Exception == null)
                                return SaveAlarmData(point, result.Result);
                            else
                                return -1;
                        },
                        TaskContinuationOptions.LongRunning);

                        Task logSaveAlarmDataTask = saveAlarmDataTask.ContinueWith((result) =>
                        {
                            if (result.Exception != null)
                                LogException(_log, "Ошибка сохранения данных аварий вычислителя ROC809 с адресом " + address, result.Exception, LogType.ROC);
                            else if (result.Result == 0)
                                Logger.Log(_log, new LogEntry { Message = "Опрос данных аварий вычислителя ROC809 с адресом " + address + " выполнен успешно. Новые данные отсутствуют", Status = LogStatus.Success, Type = LogType.ROC, Timestamp = DateTime.Now });
                            else if (result.Result > 0)
                                Logger.Log(_log, new LogEntry { Message = "Опрос данных аварий вычислителя ROC809 с адресом " + address + " выполнен успешно. Добавлено данных: " + result.Result, Status = LogStatus.Success, Type = LogType.ROC, Timestamp = DateTime.Now });

                            _scanningState[ident + "_alarm"] = false;
                        },
                        _uiSyncContext);
                    }

                    #endregion
                },
                TaskCreationOptions.LongRunning);

                Task getDataTask = processPointTask.ContinueWith((result) =>
                {
                    #region Задачи для ROC809MinuteData

                    if (timeToMinuteData && !_scanningState[ident + "_minute"])
                    {
                        Task<List<ROC809MinuteData>> getMinuteDataTask = Task.Factory.StartNew(() =>
                        {
                            _scanningState[ident + "_minute"] = true;
                            return GetMinuteData(point);
                        },
                        TaskCreationOptions.LongRunning);

                        Task<List<ROC809MinuteData>> logGetMinuteDataTask = getMinuteDataTask.ContinueWith((res) =>
                        {
                            if (res.Exception != null)
                            {
                                LogException(_log, "Ошибка опроса минутных данных точки №" + point.Number + " в историческом сегменте №" + point.HistSegment + " вычислителя ROC809 с адресом " + address, res.Exception, LogType.ROC);
                                throw res.Exception;
                            }
                            else
                                return res.Result;
                        },
                        _uiSyncContext);

                        Task<int> saveMinuteDataTask = logGetMinuteDataTask.ContinueWith((res) =>
                        {
                            if (res.Exception == null)
                            {
                                int r = SaveMinuteData(point, res.Result);
                                UpdateMinuteDataLastScanned(point);
                                return r;
                            }
                            else
                                return -1;
                        },
                        TaskContinuationOptions.LongRunning);

                        Task logSaveMinuteDataTask = saveMinuteDataTask.ContinueWith((res) =>
                        {
                            if (res.Exception != null)
                                LogException(_log, "Ошибка сохранения минутных данных точки №" + point.Number + " в историческом сегменте №" + point.HistSegment + " вычислителя ROC809 с адресом " + address, res.Exception, LogType.ROC);
                            else if (res.Result == 0)
                                Logger.Log(_log, new LogEntry { Message = "Опрос минутных данных точки №" + point.Number + " в историческом сегменте №" + point.HistSegment + " вычислителя ROC809 с адресом " + address + " выполнен успешно. Новые данные отсутствуют", Status = LogStatus.Warning, Type = LogType.ROC, Timestamp = DateTime.Now });
                            else if (res.Result > 0)
                                Logger.Log(_log, new LogEntry { Message = "Опрос минутных данных точки №" + point.Number + " в историческом сегменте №" + point.HistSegment + " вычислителя ROC809 с адресом " + address + " выполнен успешно. Добавлено данных: " + res.Result, Status = LogStatus.Success, Type = LogType.ROC, Timestamp = DateTime.Now });

                            _scanningState[ident + "_minute"] = false;
                        },
                        _uiSyncContext);
                    }

                    #endregion

                    #region Задачи для ROC809PeriodicData

                    if (timeToPeriodicData && !_scanningState[ident + "_periodic"])
                    {
                        Task<List<ROC809PeriodicData>> getPeriodicDataTask = Task.Factory.StartNew(() =>
                        {
                            _scanningState[ident + "_periodic"] = true;
                            return GetPeriodicData(point);
                        },
                        TaskCreationOptions.LongRunning);

                        Task<List<ROC809PeriodicData>> logGetPeriodicDataTask = getPeriodicDataTask.ContinueWith((res) =>
                        {
                            if (res.Exception != null)
                            {
                                LogException(_log, "Ошибка опроса периодических данных точки №" + point.Number + " в историческом сегменте №" + point.HistSegment + " вычислителя ROC809 с адресом " + address, res.Exception, LogType.ROC);
                                throw res.Exception;
                            }
                            else
                                return res.Result;
                        },
                        _uiSyncContext);

                        Task<int> savePeriodicDataTask = logGetPeriodicDataTask.ContinueWith((res) =>
                        {
                            if (res.Exception == null)
                            {
                                int r = SavePeriodicData(point, res.Result);
                                UpdatePeriodicDataLastScanned(point);
                                return r;
                            }
                            else
                                return -1;
                        },
                        TaskContinuationOptions.LongRunning);

                        Task logSaveMinuteDataTask = savePeriodicDataTask.ContinueWith((res) =>
                        {
                            if (res.Exception != null)
                                LogException(_log, "Ошибка сохранения периодических данных точки №" + point.Number + " в историческом сегменте №" + point.HistSegment + " вычислителя ROC809 с адресом " + address, res.Exception, LogType.ROC);
                            else if (res.Result == 0)
                                Logger.Log(_log, new LogEntry { Message = "Опрос периодических данных точки №" + point.Number + " в историческом сегменте №" + point.HistSegment + " вычислителя ROC809 с адресом " + address + " выполнен успешно. Новые данные отсутствуют", Status = LogStatus.Warning, Type = LogType.ROC, Timestamp = DateTime.Now });
                            else if (res.Result > 0)
                                Logger.Log(_log, new LogEntry { Message = "Опрос периодических данных точки №" + point.Number + " в историческом сегменте №" + point.HistSegment + " вычислителя ROC809 с адресом " + address + " выполнен успешно. Добавлено данных: " + res.Result, Status = LogStatus.Success, Type = LogType.ROC, Timestamp = DateTime.Now });

                            _scanningState[ident + "_periodic"] = false;
                        },
                        _uiSyncContext);
                    }

                    #endregion

                    #region Задачи для ROC809DailyData

                    if (timeToDailyData && !_scanningState[ident + "_daily"])
                    {
                        Task<List<ROC809DailyData>> getDailyDataTask = Task.Factory.StartNew(() =>
                        {
                            _scanningState[ident + "_daily"] = true;
                            return GetDailyData(point);
                        },
                        TaskCreationOptions.LongRunning);

                        Task<List<ROC809DailyData>> logGetDailyDataTask = getDailyDataTask.ContinueWith((res) =>
                        {
                            if (res.Exception != null)
                            {
                                LogException(_log, "Ошибка опроса суточных данных точки №" + point.Number + " в историческом сегменте №" + point.HistSegment + " вычислителя ROC809 с адресом " + address, res.Exception, LogType.ROC);
                                throw res.Exception;
                            }
                            else
                                return res.Result;
                        },
                        _uiSyncContext);

                        Task<int> saveDailyDataTask = logGetDailyDataTask.ContinueWith((res) =>
                        {
                            if (res.Exception == null)
                            {
                                int r = SaveDailyData(point, res.Result);
                                UpdateDailyDataLastScanned(point);
                                return r;
                            }
                            else
                                return -1;
                        },
                        TaskContinuationOptions.LongRunning);

                        Task logSaveDailyDataTask = saveDailyDataTask.ContinueWith((res) =>
                        {
                            if (res.Exception != null)
                                LogException(_log, "Ошибка сохранения суточных данных точки №" + point.Number + " в историческом сегменте №" + point.HistSegment + " вычислителя ROC809 с адресом " + address, res.Exception, LogType.ROC);
                            else if (res.Result == 0)
                                Logger.Log(_log, new LogEntry { Message = "Опрос суточных данных точки №" + point.Number + " в историческом сегменте №" + point.HistSegment + " вычислителя ROC809 с адресом " + address + " выполнен успешно. Новые данные отсутствуют", Status = LogStatus.Warning, Type = LogType.ROC, Timestamp = DateTime.Now });
                            else if (res.Result > 0)
                                Logger.Log(_log, new LogEntry { Message = "Опрос суточных данных точки №" + point.Number + " в историческом сегменте №" + point.HistSegment + " вычислителя ROC809 с адресом " + address + " выполнен успешно. Добавлено данных: " + res.Result, Status = LogStatus.Success, Type = LogType.ROC, Timestamp = DateTime.Now });

                            _scanningState[ident + "_daily"] = false;
                        },
                        _uiSyncContext);
                    }

                    #endregion
                },
                TaskContinuationOptions.LongRunning);
            }
        }

        #region Методы сохранения данных

        private int SaveEventData(ROC809MeasurePoint point, List<ROC809EventData> data)
        {
            if (data.Count > 0)
            {
                using (SqlRepository<ROC809EventData> repo = new SqlRepository<ROC809EventData>(_sqlConnection))
                {
                    ROC809EventData lastData = repo.GetAll().Where(d => d.ROC809Id == point.EstimatorId).OrderByDescending(o => o.Time).FirstOrDefault();

                    if (lastData != null)
                        data = data.Where(d => d.Time > lastData.Time).ToList();

                    data.ForEach((d) =>
                    {
                        d.DateCreated = DateTime.Now;
                        d.DateModified = DateTime.Now;
                        d.ROC809Id = point.EstimatorId;
                    });

                    repo.Insert(data);
                }

                return data.Count;
            }
            else
                return 0;
        }

        private int SaveAlarmData(ROC809MeasurePoint point, List<ROC809AlarmData> data)
        {
            if (data.Count > 0)
            {
                using (SqlRepository<ROC809AlarmData> repo = new SqlRepository<ROC809AlarmData>(_sqlConnection))
                {
                    ROC809AlarmData lastData = repo.GetAll().Where(d => d.ROC809Id == point.EstimatorId).OrderByDescending(o => o.Time).FirstOrDefault();

                    if (lastData != null)
                        data = data.Where(d => d.Time > lastData.Time).ToList();

                    data.ForEach((d) =>
                    {
                        d.DateCreated = DateTime.Now;
                        d.DateModified = DateTime.Now;
                        d.ROC809Id = point.EstimatorId;
                    });

                    repo.Insert(data);
                }

                return data.Count;
            }
            else
                return 0;
        }

        private int SaveMinuteData(ROC809MeasurePoint point, List<ROC809MinuteData> data)
        {
            if (data.Count > 0)
            {
                using (SqlRepository<ROC809MinuteData> repo = new SqlRepository<ROC809MinuteData>(_sqlConnection))
                {
                    ROC809MinuteData lastData = repo.GetAll().Where(d => d.ROC809MeasurePointId == point.Id).OrderByDescending(o => o.DatePeriod).FirstOrDefault();

                    if (lastData != null)
                        data = data.Where(d => d.DatePeriod > lastData.DatePeriod).ToList();

                    data.ForEach((d) =>
                    {
                        d.DateCreated = DateTime.Now;
                        d.DateModified = DateTime.Now;
                        d.ROC809MeasurePointId = point.Id;
                    });

                    repo.Insert(data);
                }

                return data.Count;
            }
            else
                return 0;
        }

        private void UpdateMinuteDataLastScanned(ROC809MeasurePoint point)
        {
            try
            {
                using (SqlRepository<ROC809MeasurePoint> repo = new SqlRepository<ROC809MeasurePoint>(_sqlConnection))
                {
                    ROC809MeasurePoint existingPoint = repo.Get(point.Id);
                    existingPoint.DateMinuteDataLastScanned = DateTime.Now;
                    repo.Update(existingPoint);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private int SavePeriodicData(ROC809MeasurePoint point, List<ROC809PeriodicData> data)
        {
            if (data.Count > 0)
            {
                using (SqlRepository<ROC809PeriodicData> repo = new SqlRepository<ROC809PeriodicData>(_sqlConnection))
                {
                    ROC809PeriodicData lastData = repo.GetAll().Where(d => d.ROC809MeasurePointId == point.Id).OrderByDescending(o => o.DatePeriod).FirstOrDefault();

                    if (lastData != null)
                        data = data.Where(d => d.DatePeriod > lastData.DatePeriod).ToList();

                    data.ForEach((d) =>
                    {
                        d.DateCreated = DateTime.Now;
                        d.DateModified = DateTime.Now;
                        d.ROC809MeasurePointId = point.Id;
                    });

                    repo.Insert(data);
                }

                return data.Count;
            }
            else
                return 0;
        }

        private void UpdatePeriodicDataLastScanned(ROC809MeasurePoint point)
        {
            try
            {
                using (SqlRepository<ROC809MeasurePoint> repo = new SqlRepository<ROC809MeasurePoint>(_sqlConnection))
                {
                    ROC809MeasurePoint existingPoint = repo.Get(point.Id);
                    existingPoint.DatePeriodicDataLastScanned = DateTime.Now;
                    repo.Update(existingPoint);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private int SaveDailyData(ROC809MeasurePoint point, List<ROC809DailyData> data)
        {
            if (data.Count > 0)
            {
                using (SqlRepository<ROC809DailyData> repo = new SqlRepository<ROC809DailyData>(_sqlConnection))
                {
                    ROC809DailyData lastData = repo.GetAll().Where(d => d.ROC809MeasurePointId == point.Id).OrderByDescending(o => o.DatePeriod).FirstOrDefault();

                    if (lastData != null)
                        data = data.Where(d => d.DatePeriod > lastData.DatePeriod).ToList();

                    data.ForEach((d) =>
                    {
                        d.DateCreated = DateTime.Now;
                        d.DateModified = DateTime.Now;
                        d.ROC809MeasurePointId = point.Id;
                    });

                    repo.Insert(data);
                }

                return data.Count;
            }
            else
                return 0;
        }

        private void UpdateDailyDataLastScanned(ROC809MeasurePoint point)
        {
            try
            {
                using (SqlRepository<ROC809MeasurePoint> repo = new SqlRepository<ROC809MeasurePoint>(_sqlConnection))
                {
                    ROC809MeasurePoint existingPoint = repo.Get(point.Id);
                    existingPoint.DateDailyDataLastScanned = DateTime.Now;
                    repo.Update(existingPoint);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Методы получения данных

        private List<ROC809EventData> GetEventData(ROC809MeasurePoint point)
        {
            try
            {
                ROC809DataService service = new ROC809DataService();
                return service.GetEventData(point);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private List<ROC809AlarmData> GetAlarmData(ROC809MeasurePoint point)
        {
            try
            {
                ROC809DataService service = new ROC809DataService();
                return service.GetAlarmData(point);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private List<ROC809MinuteData> GetMinuteData(ROC809MeasurePoint point)
        {
            try
            {
                ROC809DataService service = new ROC809DataService();
                List<ROC809PeriodicDataModel> data = service.GetPeriodicData(point, ROC809HistoryType.Minute);
                List<ROC809MinuteData> minuteData = new List<ROC809MinuteData>();
                data.ForEach((d) =>
                {
                    minuteData.Add(new ROC809MinuteData { DatePeriod = d.DatePeriod, Value = d.Value });
                });
                return minuteData;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private List<ROC809PeriodicData> GetPeriodicData(ROC809MeasurePoint point)
        {
            try
            {
                ROC809DataService service = new ROC809DataService();
                List<ROC809PeriodicDataModel> data = service.GetPeriodicData(point, ROC809HistoryType.Periodic);
                List<ROC809PeriodicData> periodicData = new List<ROC809PeriodicData>();
                data.ForEach((d) =>
                {
                    periodicData.Add(new ROC809PeriodicData { DatePeriod = d.DatePeriod, Value = d.Value });
                });
                return periodicData;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private List<ROC809DailyData> GetDailyData(ROC809MeasurePoint point)
        {
            try
            {
                ROC809DataService service = new ROC809DataService();
                List<ROC809PeriodicDataModel> data = service.GetPeriodicData(point, ROC809HistoryType.Daily);
                List<ROC809DailyData> periodicData = new List<ROC809DailyData>();
                data.ForEach((d) =>
                {
                    periodicData.Add(new ROC809DailyData { DatePeriod = d.DatePeriod, Value = d.Value });
                });
                return periodicData;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Вспомогательные методы

        private void LogException(LogListView log, string message, Exception exception, LogType type)
        {
            Logger.Log(log, new LogEntry { Message = message, Status = LogStatus.Error, Timestamp = DateTime.Now, Type = type });

            if (exception.InnerException != null)
                Logger.Log(log, new LogEntry { Message = exception.InnerException.Message, Status = LogStatus.Error, Type = type, Timestamp = DateTime.Now });
            else
                Logger.Log(log, new LogEntry { Message = exception.Message, Status = LogStatus.Error, Timestamp = DateTime.Now, Type = type });
        }

        #endregion
    }
}
