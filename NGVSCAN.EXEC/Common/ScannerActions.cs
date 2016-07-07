using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using NGVSCAN.CORE.Entities;
using NGVSCAN.CORE.Entities.Floutecs;
using NGVSCAN.CORE.Entities.ROC809s;
using NGVSCAN.DAL.Extensions;
using NGVSCAN.DAL.Repositories;
using NGVSCAN.DAL.ROC809Connection;
using NGVSCAN.EXEC.Controls;

namespace NGVSCAN.EXEC.Common
{
    public partial class Scanner
    {
        #region Определение ниток вычислителей ФЛОУТЭК и точек вычислителей ROC809 для сканирования

        private List<FloutecMeasureLine> GetLinesForScanning(Field field)
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
                    .Include(l => l.Estimator.Field)
                    .Where(l => !l.IsDeleted && !l.Estimator.IsDeleted && l.Estimator.Field.Id == field.Id)
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
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private List<ROC809MeasurePoint> GetPointsForScanning(Field field)
        {
            List<ROC809MeasurePoint> points;

            try
            {
                using (SqlRepository<ROC809MeasurePoint> repo = new SqlRepository<ROC809MeasurePoint>(connection))
                {
                    points = repo.GetAll()
                        .Include(p => p.DailyData)
                        .Include(p => p.Estimator)
                        .Include(p => p.Estimator.Field)
                        .Include(p => p.MinuteData)
                        .Include(p => p.PeriodicData)
                        .Include(p => p.DailyData)
                        .Include(p => p.AlarmData)
                        .Include(p => p.EventData)
                        .Where(p => !p.IsDeleted && !p.Estimator.IsDeleted && p.Estimator.Field.Id == field.Id)
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

        #endregion

        #region Получение и сохранение данных идентификации вычислителя ФЛОУТЭК

        private FloutecIdentData GetIdentData(FloutecMeasureLine line)
        {
            int address = ((Floutec)line.Estimator).Address;
            int n_flonit = address * 10 + line.Number;

            if (!floutecsScanningState[n_flonit.ToString() + "_ident"])
            {
                floutecsScanningState[n_flonit.ToString() + "_ident"] = true;

                FloutecIdentData identData = new FloutecIdentData();
                identData.N_FLONIT = 0;

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

        #endregion

        #region Получение и сохранение часовых данных вычислителя ФЛОУТЭК

        private List<FloutecHourlyData> GetHourlyData(FloutecMeasureLine line)
        {
            int address = ((Floutec)line.Estimator).Address;
            int n_flonit = address * 10 + line.Number;
            floutecsScanningState[n_flonit.ToString() + "_hour"] = true;

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

        #endregion

        #region Получение и сохранение мгновенных данных вычислителя ФЛОУТЭК

        private FloutecInstantData GetInstantData(FloutecMeasureLine line)
        {
            int address = ((Floutec)line.Estimator).Address;
            int n_flonit = address * 10 + line.Number;
            floutecsScanningState[n_flonit.ToString() + "_inst"] = true;

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

        #endregion

        #region Получение и сохранение данных аварий вычислителя ФЛОУТЭК

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

        #endregion

        #region Получение и сохранение данных вмешательств вычислителя ФЛОУТЭК

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

        #endregion

        #region Получение и сохранение данных событий вычислителя ROC809

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

        #endregion

        #region Получение и сохранение данных аварий вычислителя ROC809

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
                    alarmData = ext.GetAlarmData(point);

                    if (alarmData.Count > 0)
                    {
                        ROC809AlarmData lastData = point.AlarmData.OrderBy(o => o.Time).LastOrDefault();

                        if (lastData != null)
                            return alarmData.Where(e => e.Time > lastData.Time).ToList();
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
                return null;
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

        #endregion

        #region Получение и сохранение минутных данных вычислителя ROC809

        private List<ROC809MinuteData> GetMinuteData(ROC809MeasurePoint point)
        {
            string address = ((ROC809)point.Estimator).Address;
            string ident = address + "_" + point.Number + "_" + point.HistSegment;
            rocsScanningState[ident + "_minute"] = true;

            dateStartMinuteDataScan = DateTime.Now;

            List<ROC809MinuteData> minuteData = new List<ROC809MinuteData>();

            try
            {
                ROC809DataService ext = new ROC809DataService();
                var result = ext.GetPeriodicData(point, ROC809HistoryType.Minute);

                if (result.Count > 0)
                {
                    ROC809MinuteData lastData = point.MinuteData.OrderBy(o => o.DatePeriod).LastOrDefault();

                    if (lastData == null)
                    {
                        foreach (var item in result)
                        {
                            minuteData.Add(new ROC809MinuteData() { DatePeriod = item.DatePeriod, Value = item.Value });
                        }
                    }
                    else
                    {
                        foreach (var item in result.Where(m => m.DatePeriod > lastData.DatePeriod))
                        {
                            minuteData.Add(new ROC809MinuteData() { DatePeriod = item.DatePeriod, Value = item.Value });
                        }
                    }
                }

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

        #endregion

        #region Получение и сохранение периодических данных вычислителя ROC809

        private List<ROC809PeriodicData> GetPeriodicData(ROC809MeasurePoint point)
        {
            string address = ((ROC809)point.Estimator).Address;
            string ident = address + "_" + point.Number + "_" + point.HistSegment;
            rocsScanningState[ident + "_periodic"] = true;

            dateStartPeriodicDataScan = DateTime.Now;

            List<ROC809PeriodicData> periodicData = new List<ROC809PeriodicData>();

            try
            {
                ROC809DataService ext = new ROC809DataService();
                var result = ext.GetPeriodicData(point, ROC809HistoryType.Periodic);

                if (result.Count > 0)
                {
                    ROC809PeriodicData lastData = point.PeriodicData.OrderBy(o => o.DatePeriod).LastOrDefault();

                    if (lastData == null)
                    {
                        foreach (var item in result)
                        {
                            periodicData.Add(new ROC809PeriodicData() { DatePeriod = item.DatePeriod, Value = item.Value });
                        }
                    }
                    else
                    {
                        foreach (var item in result.Where(m => m.DatePeriod > lastData.DatePeriod))
                        {
                            periodicData.Add(new ROC809PeriodicData() { DatePeriod = item.DatePeriod, Value = item.Value });
                        }
                    }
                }

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

        #endregion

        #region Получение и сохранение суточных данных вычислителя ROC809

        private List<ROC809DailyData> GetDailyData(ROC809MeasurePoint point)
        {
            string address = ((ROC809)point.Estimator).Address;
            string ident = address + "_" + point.Number + "_" + point.HistSegment;
            rocsScanningState[ident + "_daily"] = true;

            dateStartDailyDataScan = DateTime.Now;

            List<ROC809DailyData> dailyData = new List<ROC809DailyData>();

            try
            {
                ROC809DataService ext = new ROC809DataService();
                var result = ext.GetPeriodicData(point, ROC809HistoryType.Daily);

                if (result.Count > 0)
                {
                    ROC809DailyData lastData = point.DailyData.OrderBy(o => o.DatePeriod).LastOrDefault();

                    if (lastData == null)
                    {
                        foreach (var item in result)
                        {
                            dailyData.Add(new ROC809DailyData() { DatePeriod = item.DatePeriod, Value = item.Value });
                        }
                    }
                    else
                    {
                        foreach (var item in result.Where(m => m.DatePeriod > lastData.DatePeriod))
                        {
                            dailyData.Add(new ROC809DailyData() { DatePeriod = item.DatePeriod, Value = item.Value });
                        }
                    }
                }

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

        #endregion

        #region Вспомогательные методы

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
