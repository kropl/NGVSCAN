using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using NGVSCAN.CORE.Entities.Floutecs;
using NGVSCAN.DAL.Extensions;
using NGVSCAN.DAL.Repositories;
using NGVSCAN.EXEC.Common;
using NGVSCAN.EXEC.Controls;

namespace NGVSCAN.EXEC.Scanners
{
    public class FloutecScanner
    {
        #region Конструктор и поля

        private Dictionary<string, bool> _scanningState;
        private static string _sqlConnection;
        private static string _dbfConnection;
        private LogListView _log;
        private TaskScheduler _uiSyncContext;

        public FloutecScanner(LogListView log)
        {
            _log = log;
            _scanningState = new Dictionary<string, bool>();
            _uiSyncContext = TaskScheduler.FromCurrentSynchronizationContext();
        }

        #endregion

        public void Process(int fieldId, string sqlConnection, string dbfConnection)
        {
            _sqlConnection = sqlConnection;
            _dbfConnection = dbfConnection;

            Task<List<FloutecMeasureLine>> mainTask = Task.Factory.StartNew(() => 
            {
                return GetLinesForScanning(fieldId);
            }, 
            TaskCreationOptions.LongRunning);

            Task<List<FloutecMeasureLine>> logMainTaskResultTask = mainTask.ContinueWith((result) => 
            {
                if (result.Exception != null)
                {
                    LogException(_log, "Ошибка построения списка вычислителей ФЛОУТЭК", result.Exception, LogType.Floutec);
                    return null;
                }
                else
                    return result.Result;
            }, 
            _uiSyncContext);

            Task processLinesTask = logMainTaskResultTask.ContinueWith((result) =>
            {
                if (result.Result != null)
                    result.Result.ForEach((l) => ProcessLine(l));
            },
            TaskContinuationOptions.LongRunning);
        }

        private List<FloutecMeasureLine> GetLinesForScanning(int fieldId)
        {
            try
            {
                List<FloutecMeasureLine> lines;

                using (SqlRepository<FloutecMeasureLine> repo = new SqlRepository<FloutecMeasureLine>(_sqlConnection))
                {
                    lines = repo.GetAll()
                        .Where(l => !l.IsDeleted && !l.Estimator.IsDeleted && l.Estimator.FieldId == fieldId)
                        .Include(l => l.Estimator)
                        .ToList();

                    InitScanningState(lines);
                }

                return lines;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void InitScanningState(List<FloutecMeasureLine> lines)
        {
            if (lines != null && lines.Any())
            {
                lines.ForEach((l) =>
                {
                    int address = ((Floutec)l.Estimator).Address;
                    string n_flonit = (address * 10 + l.Number).ToString();

                    if (!_scanningState.ContainsKey(n_flonit))
                    {
                        _scanningState.Add(n_flonit, false);
                        _scanningState.Add(n_flonit + "_ident", false);
                        _scanningState.Add(n_flonit + "_alarm", false);
                        _scanningState.Add(n_flonit + "_inter", false);
                        _scanningState.Add(n_flonit + "_inst", false);
                        _scanningState.Add(n_flonit + "_hour", false);
                    }
                });                   
            }
        }

        private void ProcessLine(FloutecMeasureLine line)
        {
            int address = ((Floutec)line.Estimator).Address;
            string n_flonit = (address * 10 + line.Number).ToString();

            bool timeToHourlyData = !line.DateHourlyDataLastScanned.HasValue || line.DateHourlyDataLastScanned.Value.AddMinutes(line.HourlyDataScanPeriod) <= DateTime.Now;
            bool timeToInstData = !line.DateInstantDataLastScanned.HasValue || line.DateInstantDataLastScanned.Value.AddMinutes(line.InstantDataScanPeriod) <= DateTime.Now;

            if ((timeToHourlyData && !_scanningState[n_flonit + "_hour"]) || 
                (timeToInstData && !_scanningState[n_flonit + "_inst"]))
            {                                
                Task mainTask = Task.Factory.StartNew(() =>
                {
                    #region Задачи для FloutecIdentData

                    if (!_scanningState[n_flonit + "_ident"])
                    {
                        
                        Task<FloutecIdentData> getIdentDataTask = Task.Factory.StartNew(() =>
                        {
                            _scanningState[n_flonit + "_ident"] = true;
                            return GetIdentData(line, address);
                        },
                        TaskCreationOptions.LongRunning);

                        Task<FloutecIdentData> logGetIdentDataResultTask = getIdentDataTask.ContinueWith((result) =>
                        {
                            if (result.Exception != null)
                            {
                                LogException(_log, "Ошибка опроса данных идентификации нитки №" + line.Number + " вычислителя ФЛОУТЭК с адресом " + address, result.Exception, LogType.Floutec);
                                throw result.Exception;
                            }
                            else
                                return result.Result;
                        },
                        _uiSyncContext);

                        Task<int> saveIdentDataTask = logGetIdentDataResultTask.ContinueWith((result) =>
                        {
                            if (result.Exception == null)
                            {
                                if (result.Result == null)
                                    return -2;
                                else
                                {
                                    return SaveIdentData(line, result.Result);
                                }
                            }
                            else
                                return -1;
                        },
                        TaskContinuationOptions.LongRunning);

                        Task logSaveIdentDataTask = saveIdentDataTask.ContinueWith((result) =>
                        {
                            if (result.Exception != null)
                                LogException(_log, "Ошибка сохранения данных идентификации нитки №" + line.Number + " вычислителя ФЛОУТЭК с адресом " + address, result.Exception, LogType.Floutec);
                            else if (result.Result == -2)
                                Logger.Log(_log, new LogEntry { Message = "Данные идентификации нитки №" + line.Number + " вычислителя ФЛОУТЭК с адресом " + address + " отсутствуют", Status = LogStatus.Warning, Type = LogType.Floutec, Timestamp = DateTime.Now });
                            else if (result.Result == 0)
                                Logger.Log(_log, new LogEntry { Message = "Опрос данных идентификации нитки №" + line.Number + " вычислителя ФЛОУТЭК с адресом " + address + " выполнен успешно. Изменения отсутствуют", Status = LogStatus.Success, Type = LogType.Floutec, Timestamp = DateTime.Now });
                            else if (result.Result == 1)
                                Logger.Log(_log, new LogEntry { Message = "Опрос данных идентификации нитки №" + line.Number + " вычислителя ФЛОУТЭК с адресом " + address + " выполнен успешно", Status = LogStatus.Success, Type = LogType.Floutec, Timestamp = DateTime.Now });

                            _scanningState[n_flonit + "_ident"] = false;
                        },
                        _uiSyncContext);                      
                    }

                    #endregion

                    #region Задачи для FloutecInterData

                    if (!_scanningState[n_flonit + "_inter"])
                    {                      
                        Task<List<FloutecInterData>> getInterDataTask = Task.Factory.StartNew(() =>
                        {
                            _scanningState[n_flonit + "_inter"] = true;
                            return GetInterData(line, address);
                        },
                        TaskCreationOptions.LongRunning);

                        Task<List<FloutecInterData>> logGetInterDataTask = getInterDataTask.ContinueWith((result) =>
                        {
                            if (result.Exception != null)
                            {
                                LogException(_log, "Ошибка опроса данных вмешательств нитки №" + line.Number + " вычислителя ФЛОУТЭК с адресом " + address, result.Exception, LogType.Floutec);
                                throw result.Exception;
                            }
                            else
                                return result.Result;
                        },
                        _uiSyncContext);

                        Task<int> saveInterDataTask = logGetInterDataTask.ContinueWith((result) =>
                        {
                            if (result.Exception == null)
                            {
                                if (result.Result == null)
                                    return -2;
                                else
                                {
                                    return SaveInterData(line, result.Result);
                                }
                            }
                            else
                                return -1;
                        },
                        TaskContinuationOptions.LongRunning);

                        Task logSaveInterDataTask = saveInterDataTask.ContinueWith((result) =>
                        {
                            if (result.Exception != null)
                                LogException(_log, "Ошибка сохранения данных вмешательств нитки №" + line.Number + " вычислителя ФЛОУТЭК с адресом " + address, result.Exception, LogType.Floutec);
                            else if (result.Result == -2)
                                Logger.Log(_log, new LogEntry { Message = "Данные вмешательств нитки №" + line.Number + " вычислителя ФЛОУТЭК с адресом " + address + " отсутствуют", Status = LogStatus.Warning, Type = LogType.Floutec, Timestamp = DateTime.Now });
                            else if (result.Result == 0)
                                Logger.Log(_log, new LogEntry { Message = "Опрос данных вмешательств нитки №" + line.Number + " вычислителя ФЛОУТЭК с адресом " + address + " выполнен успешно. Новые данные отсутствуют", Status = LogStatus.Success, Type = LogType.Floutec, Timestamp = DateTime.Now });
                            else if (result.Result > 0)
                                Logger.Log(_log, new LogEntry { Message = "Опрос данных вмешательств нитки №" + line.Number + " вычислителя ФЛОУТЭК с адресом " + address + " выполнен успешно. Добавлено данных: " + result.Result, Status = LogStatus.Success, Type = LogType.Floutec, Timestamp = DateTime.Now });

                            _scanningState[n_flonit + "_inter"] = false;
                        },
                        _uiSyncContext);                     
                    }

                    #endregion

                    #region Задачи для FloutecAlarmData

                    if (!_scanningState[n_flonit + "_alarm"])
                    {                        
                        Task<List<FloutecAlarmData>> getAlarmDataTask = Task.Factory.StartNew(() =>
                        {
                            _scanningState[n_flonit + "_alarm"] = true;
                            return GetAlarmData(line, address);
                        },
                        TaskCreationOptions.LongRunning);

                        Task<List<FloutecAlarmData>> logGetAlarmDataTask = getAlarmDataTask.ContinueWith((result) =>
                        {
                            if (result.Exception != null)
                            {
                                LogException(_log, "Ошибка опроса данных аварий нитки №" + line.Number + " вычислителя ФЛОУТЭК с адресом " + address, result.Exception, LogType.Floutec);
                                throw result.Exception;
                            }
                            else
                                return result.Result;
                        },
                        _uiSyncContext);

                        Task<int> saveAlarmDataTask = logGetAlarmDataTask.ContinueWith((result) =>
                        {
                            if (result.Exception == null)
                            {
                                if (result.Result == null)
                                    return -2;
                                else
                                {
                                    return SaveAlarmData(line, result.Result);
                                }
                            }
                            else
                                return -1;
                        },
                        TaskContinuationOptions.LongRunning);

                        Task logSaveAlarmDataTask = saveAlarmDataTask.ContinueWith((result) =>
                        {
                            if (result.Exception != null)
                                LogException(_log, "Ошибка сохранения данных аварий нитки №" + line.Number + " вычислителя ФЛОУТЭК с адресом " + address, result.Exception, LogType.Floutec);
                            else if (result.Result == -2)
                                Logger.Log(_log, new LogEntry { Message = "Данные аварий нитки №" + line.Number + " вычислителя ФЛОУТЭК с адресом " + address + " отсутствуют", Status = LogStatus.Warning, Type = LogType.Floutec, Timestamp = DateTime.Now });
                            else if (result.Result == 0)
                                Logger.Log(_log, new LogEntry { Message = "Опрос данных аварий нитки №" + line.Number + " вычислителя ФЛОУТЭК с адресом " + address + " выполнен успешно. Новые данные отсутствуют", Status = LogStatus.Success, Type = LogType.Floutec, Timestamp = DateTime.Now });
                            else if (result.Result > 0)
                                Logger.Log(_log, new LogEntry { Message = "Опрос данных аварий нитки №" + line.Number + " вычислителя ФЛОУТЭК с адресом " + address + " выполнен успешно. Добавлено данных: " + result.Result, Status = LogStatus.Success, Type = LogType.Floutec, Timestamp = DateTime.Now });

                            _scanningState[n_flonit + "_alarm"] = false;
                        },
                        _uiSyncContext);                       
                    }

                    #endregion
                },
                TaskCreationOptions.LongRunning);                         

                Task getPeriodicData = mainTask.ContinueWith((result) =>
                {
                    #region Задачи для FloutecHourlyData

                    if (timeToHourlyData && !_scanningState[n_flonit + "_hour"])
                    {
                        Task<List<FloutecHourlyData>> getHourlyDataTask = Task.Factory.StartNew(() =>
                        {
                            _scanningState[n_flonit + "_hour"] = true;
                            return GetHourlyData(line, address);
                        },
                        TaskCreationOptions.LongRunning);

                        Task<List<FloutecHourlyData>> logGetHourlyDataTask = getHourlyDataTask.ContinueWith((res) =>
                        {
                            if (res.Exception != null)
                            {
                                LogException(_log, "Ошибка опроса часовых данных нитки №" + line.Number + " вычислителя ФЛОУТЭК с адресом " + address, res.Exception, LogType.Floutec);
                                throw res.Exception;
                            }
                            else
                                return res.Result;
                        },
                        _uiSyncContext);

                        Task<int> saveHourlyDataTask = logGetHourlyDataTask.ContinueWith((res) =>
                        {
                            if (res.Exception == null)
                            {
                                if (res.Result == null)
                                {
                                    UpdateHourlyDataLastScanned(line);
                                    return -2;
                                }
                                else
                                {
                                    int r = SaveHourlyData(line, res.Result);
                                    UpdateHourlyDataLastScanned(line);
                                    return r;
                                }
                            }
                            else
                                return -1;
                        },
                        TaskContinuationOptions.LongRunning);

                        Task logSaveHourlyDataTask = saveHourlyDataTask.ContinueWith((res) =>
                        {
                            if (res.Exception != null)
                                LogException(_log, "Ошибка сохранения часовых данных нитки №" + line.Number + " вычислителя ФЛОУТЭК с адресом " + address, res.Exception, LogType.Floutec);
                            else if (res.Result == -2)
                                Logger.Log(_log, new LogEntry { Message = "Часовые данные нитки №" + line.Number + " вычислителя ФЛОУТЭК с адресом " + address + " отсутствуют", Status = LogStatus.Warning, Type = LogType.Floutec, Timestamp = DateTime.Now });
                            else if (res.Result == 0)
                                Logger.Log(_log, new LogEntry { Message = "Опрос часовых данных нитки №" + line.Number + " вычислителя ФЛОУТЭК с адресом " + address + " выполнен успешно. Новые данные отсутствуют", Status = LogStatus.Warning, Type = LogType.Floutec, Timestamp = DateTime.Now });
                            else if (res.Result > 0)
                                Logger.Log(_log, new LogEntry { Message = "Опрос часовых данных нитки №" + line.Number + " вычислителя ФЛОУТЭК с адресом " + address + " выполнен успешно. Добавлено данных: " + res.Result, Status = LogStatus.Success, Type = LogType.Floutec, Timestamp = DateTime.Now });

                            _scanningState[n_flonit + "_hour"] = false;
                        },
                        _uiSyncContext);
                    }

                    #endregion

                    #region Задачи для FloutecInstData

                    if (timeToInstData && !_scanningState[n_flonit + "_inst"])
                    {
                        Task<FloutecInstantData> getInstDataTask = Task.Factory.StartNew(() =>
                        {
                            _scanningState[n_flonit + "_inst"] = true;
                            return GetInstData(line, address);
                        },
                        TaskCreationOptions.LongRunning);

                        Task<FloutecInstantData> logGetInstDataTask = getInstDataTask.ContinueWith((res) =>
                        {
                            if (result.Exception != null)
                            {
                                LogException(_log, "Ошибка опроса мгновенных данных нитки №" + line.Number + " вычислителя ФЛОУТЭК с адресом " + address, res.Exception, LogType.Floutec);
                                throw result.Exception;
                            }
                            else
                                return res.Result;
                        },
                        _uiSyncContext);

                        Task<int> saveInstDataTask = logGetInstDataTask.ContinueWith((res) =>
                        {
                            if (res.Exception == null)
                            {
                                if (res.Result == null)
                                {
                                    UpdateInstDataLastScanned(line);
                                    return -2;
                                }
                                else
                                {
                                    int r = SaveInstData(line, res.Result);
                                    UpdateInstDataLastScanned(line);
                                    return r;
                                }
                            }
                            else
                                return -1;
                        },
                        TaskContinuationOptions.LongRunning);

                        Task logSaveInstDataTask = saveInstDataTask.ContinueWith((res) =>
                        {
                            if (res.Exception != null)
                                LogException(_log, "Ошибка сохранения мгновенных данных нитки №" + line.Number + " вычислителя ФЛОУТЭК с адресом " + address, res.Exception, LogType.Floutec);
                            else if (res.Result == -2)
                                Logger.Log(_log, new LogEntry { Message = "Мгновенные данные нитки №" + line.Number + " вычислителя ФЛОУТЭК с адресом " + address + " отсутствуют", Status = LogStatus.Warning, Type = LogType.Floutec, Timestamp = DateTime.Now });
                            else if (res.Result == 0)
                                Logger.Log(_log, new LogEntry { Message = "Опрос мгновенных данных нитки №" + line.Number + " вычислителя ФЛОУТЭК с адресом " + address + " выполнен успешно. Новые данные отсутствуют", Status = LogStatus.Warning, Type = LogType.Floutec, Timestamp = DateTime.Now });
                            else if (res.Result > 0)
                                Logger.Log(_log, new LogEntry { Message = "Опрос мгновенных данных нитки №" + line.Number + " вычислителя ФЛОУТЭК с адресом " + address + " выполнен успешно. Добавлено данных: " + res.Result, Status = LogStatus.Success, Type = LogType.Floutec, Timestamp = DateTime.Now });

                            _scanningState[n_flonit + "_inst"] = false;
                        },
                        _uiSyncContext);
                    }

                    #endregion
                },
                TaskContinuationOptions.LongRunning);
            }
        }

        private int SaveInstData(FloutecMeasureLine line, FloutecInstantData data)
        {
            try
            {
                using (SqlRepository<FloutecInstantData> repo = new SqlRepository<FloutecInstantData>(_sqlConnection))
                {
                    FloutecInstantData lastData = repo.GetAll().Where(d => d.FloutecMeasureLineId == line.Id).OrderByDescending(o => o.DAT).FirstOrDefault();

                    if (lastData == null || !lastData.IsEqual(data))
                    {
                        data.DateCreated = DateTime.Now;
                        data.DateModified = DateTime.Now;
                        data.FloutecMeasureLineId = line.Id;
                        repo.Insert(data);
                        return 1;
                    }
                    else
                        return 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private int SaveHourlyData(FloutecMeasureLine line, List<FloutecHourlyData> data)
        {
            try
            {
                using (SqlRepository<FloutecHourlyData> repo = new SqlRepository<FloutecHourlyData>(_sqlConnection))
                {
                    if (data.Any())
                    {
                        data.ForEach((d) =>
                        {
                            d.DateCreated = DateTime.Now;
                            d.DateModified = DateTime.Now;
                            d.FloutecMeasureLineId = line.Id;
                        });

                        repo.Insert(data);

                        return data.Count;
                    }
                    else
                        return 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void UpdateHourlyDataLastScanned(FloutecMeasureLine line)
        {
            try
            {
                using (SqlRepository<FloutecMeasureLine> repo = new SqlRepository<FloutecMeasureLine>(_sqlConnection))
                {
                    FloutecMeasureLine existingLine = repo.Get(line.Id);
                    existingLine.DateHourlyDataLastScanned = DateTime.Now;
                    repo.Update(existingLine);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void UpdateInstDataLastScanned(FloutecMeasureLine line)
        {
            try
            {
                using (SqlRepository<FloutecMeasureLine> repo = new SqlRepository<FloutecMeasureLine>(_sqlConnection))
                {
                    FloutecMeasureLine existingLine = repo.Get(line.Id);
                    existingLine.DateInstantDataLastScanned = DateTime.Now;
                    repo.Update(existingLine);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private int SaveInterData(FloutecMeasureLine line, List<FloutecInterData> data)
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
                    using (SqlRepository<FloutecInterData> repo = new SqlRepository<FloutecInterData>(_sqlConnection))
                    {
                        repo.Insert(data);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return data.Count;
            }
            else
                return 0;
        }

        private int SaveAlarmData(FloutecMeasureLine line, List<FloutecAlarmData> data)
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
                    using (SqlRepository<FloutecAlarmData> repo = new SqlRepository<FloutecAlarmData>(_sqlConnection))
                    {
                        repo.Insert(data);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return data.Count;
            }
            else
                return 0;
        }

        private int SaveIdentData(FloutecMeasureLine line, FloutecIdentData data)
        {
            try
            {
                using (SqlRepository<FloutecIdentData> repo = new SqlRepository<FloutecIdentData>(_sqlConnection))
                {
                    FloutecIdentData lastData = repo.GetAll().Where(d => d.FloutecMeasureLineId == line.Id).OrderByDescending(o => o.DateCreated).FirstOrDefault();

                    if (lastData == null || !lastData.IsEqual(data))
                    {
                        data.DateCreated = DateTime.Now;
                        data.DateModified = DateTime.Now;
                        data.FloutecMeasureLineId = line.Id;
                        repo.Insert(data);

                        return 1;
                    }
                    else
                        return 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #region Методы получения данных

        private FloutecIdentData GetIdentData(FloutecMeasureLine line, int floutecAddress)
        {
            try
            {
                using (DbfRepository repo = new DbfRepository(_dbfConnection))
                {
                    return repo.GetIdentData(floutecAddress, line.Number);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private List<FloutecAlarmData> GetAlarmData(FloutecMeasureLine line, int floutecAddress)
        {
            FloutecAlarmData lastData;

            try
            {
                using (SqlRepository<FloutecAlarmData> sqlRepo = new SqlRepository<FloutecAlarmData>(_sqlConnection))
                using (DbfRepository dbfRepo = new DbfRepository(_dbfConnection))
                {
                    lastData = sqlRepo.GetAll().Where(d => d.FloutecMeasureLineId == line.Id).OrderByDescending(o => o.DAT).FirstOrDefault();

                    if (lastData != null)
                    {
                        return dbfRepo.GetAlarmData(floutecAddress, line.Number, lastData.DAT, DateTime.Now);
                    }
                    else
                        return dbfRepo.GetAllAlarmData(floutecAddress, line.Number);
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        private List<FloutecInterData> GetInterData(FloutecMeasureLine line, int floutecAddress)
        {
            FloutecInterData lastData;

            try
            {
                using (SqlRepository<FloutecInterData> sqlRepo = new SqlRepository<FloutecInterData>(_sqlConnection))
                using (DbfRepository dbfRepo = new DbfRepository(_dbfConnection))
                {
                    lastData = sqlRepo.GetAll().Where(d => d.FloutecMeasureLineId == line.Id).OrderByDescending(o => o.DAT).FirstOrDefault();

                    if (lastData != null)
                    {
                        return dbfRepo.GetInterData(floutecAddress, line.Number, lastData.DAT, DateTime.Now);
                    }
                    else
                        return dbfRepo.GetAllInterData(floutecAddress, line.Number);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private List<FloutecHourlyData> GetHourlyData(FloutecMeasureLine line, int floutecAddress)
        {
            FloutecHourlyData lastData;

            try
            {
                using (SqlRepository<FloutecHourlyData> sqlRepo = new SqlRepository<FloutecHourlyData>(_sqlConnection))
                using (DbfRepository dbfRepo = new DbfRepository(_dbfConnection))
                {
                    lastData = sqlRepo.GetAll().Where(d => d.FloutecMeasureLineId == line.Id).OrderByDescending(o => o.DAT).FirstOrDefault();

                    if (lastData != null)
                    {
                        return dbfRepo.GetHourlyData(floutecAddress, line.Number, lastData.DAT, DateTime.Now);
                    }
                    else
                        return dbfRepo.GetAllHourlyData(floutecAddress, line.Number);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private FloutecInstantData GetInstData(FloutecMeasureLine line, int floutecAddress)
        {
            try
            {
                using (DbfRepository repo = new DbfRepository(_dbfConnection))
                {
                    return repo.GetInstantData(floutecAddress, line.Number);
                }
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
