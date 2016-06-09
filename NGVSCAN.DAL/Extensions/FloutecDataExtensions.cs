using NGVSCAN.CORE.Entities;
using NGVSCAN.CORE.Entities.Common;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Diagnostics;
using System.Globalization;

namespace NGVSCAN.DAL.Extensions
{
    /// <summary>
    /// Статический класс с методами расширения для объектов данных вычислителей ФЛОУТЭК
    /// </summary>
    public static class FloutecDataExtensions
    {
        // Форматы дат для преобразования полей DAT и DAT_END
        private static string[] datetimeFormats = { @"M/d/yyyy hh:mm:ss tt", @"dd.MM.yyyy HH:mm:ss", @"dd.MM.yyyy H:mm:ss", @"dd.MM.yyyy" };

        // Форматы дат для преобразования полей KONTRH
        private static string[] timeFormats = { @"hh:mm:ss tt", @"HH:mm:ss" };

        #region Методы расширения для FloutecIdentData

        /// <summary>
        /// Метод расширения объекта данных идентификации для получения данных из таблицы данных идентификации
        /// </summary>
        /// <param name="identData">Объект данных идентификации</param>
        /// <param name="reader"><see cref="OleDbDataReader"/></param>
        public static void FromIdentTable(this FloutecIdentData identData, OleDbDataReader reader)
        {
            identData.KONTRH = DateTime.ParseExact(GetReaderValue(reader, "KONTRH", "").Trim(), timeFormats, CultureInfo.InvariantCulture, DateTimeStyles.None).TimeOfDay;
            identData.KALIBSCH = GetReaderValue(reader, "KALIBSCH", 0.0);
            identData.MAXRSCH = GetReaderValue(reader, "MAXRSCH", 0.0);
            identData.MINRSCH = GetReaderValue(reader, "MINRSCH", 0.0);
            identData.VERXP = GetReaderValue(reader, "VERXP", 0.0);
            identData.VERXDP = GetReaderValue(reader, "VERXDP", 0.0);
            identData.KONDENS = GetReaderValue(reader, "KONDENS", 0);
            identData.NIZP = GetReaderValue(reader, "NIZP", 0.0);
            identData.VERXT = GetReaderValue(reader, "VERXT", 0.0);
            identData.NIZT = GetReaderValue(reader, "NIZT", 0.0);
        }

        /// <summary>
        /// Метод расширения объекта данных идентификации для получения данных из таблицы статических данных
        /// </summary>
        /// <param name="identData">Объект данных идентификации</param>
        /// <param name="reader"><see cref="OleDbDataReader"/></param>
        public static void FromStatTable(this FloutecIdentData identData, OleDbDataReader reader)
        {
            identData.PLOTN = GetReaderValue(reader, "PLOTN", 0.0);
            identData.CO2 = GetReaderValue(reader, "CO2", 0.0);
            identData.NO2 = GetReaderValue(reader, "NO2", 0.0);
            identData.DTRUB = GetReaderValue(reader, "DTRUB", 0.0);
            identData.DSU = GetReaderValue(reader, "DSU", 0.0);
            identData.OTSECH = GetReaderValue(reader, "OTSECH", 0.0);
            identData.OTBOR = GetReaderValue(reader, "OTBOR", 0);
            identData.ACP = GetReaderValue(reader, "ACP", 0.0);
            identData.BCP = GetReaderValue(reader, "BCP", 0.0);
            identData.CCP = GetReaderValue(reader, "CCP", 0.0);
            identData.ACS = GetReaderValue(reader, "ACS", 0.0);
            identData.BCS = GetReaderValue(reader, "BCS", 0.0);
            identData.CCS = GetReaderValue(reader, "CCS", 0.0);
        }

        /// <summary>
        /// Метод определения равенства объектов данных идентификации
        /// </summary>
        /// <param name="newData">Новые данные</param>
        /// <param name="exData">Существующие данные</param>
        /// <returns></returns>
        public static bool IsEqual(this FloutecIdentData newData, FloutecIdentData exData)
        {
            return newData != null && exData != null && newData.ACP.Equals(exData.ACP) && newData.ACS.Equals(exData.ACS) && newData.BCP.Equals(exData.BCP) && newData.BCS.Equals(exData.BCS)
                && newData.CCP.Equals(exData.CCP) && newData.CCS.Equals(exData.CCS) && newData.CO2.Equals(exData.CO2) && newData.DSU.Equals(exData.DSU)
                && newData.DTRUB.Equals(exData.DTRUB) && newData.KALIBSCH.Equals(exData.KALIBSCH) && newData.KONDENS.Equals(exData.KONDENS) && newData.KONTRH.Equals(exData.KONTRH)
                && newData.MAXRSCH.Equals(exData.MAXRSCH) && newData.MINRSCH.Equals(exData.MINRSCH) && newData.NIZP.Equals(exData.NIZP) && newData.NIZT.Equals(exData.NIZT)
                && newData.NO2.Equals(exData.NO2) && newData.OTBOR.Equals(exData.OTBOR) && newData.OTSECH.Equals(exData.OTSECH) && newData.PLOTN.Equals(exData.PLOTN)
                && newData.SHER.Equals(exData.SHER) && newData.VERXDP.Equals(exData.VERXDP) && newData.VERXP.Equals(exData.VERXP) && newData.VERXT.Equals(exData.VERXT);
        }

        #endregion

        #region Методы расширения для FloutecHourlyData

        /// <summary>
        /// Метод расширения объекта часовых данных для получения данных из таблицы часовых данных
        /// </summary>
        /// <param name="hourlyData">Коллекция объектов часовых данных</param>
        /// <param name="reader"><see cref="OleDbDataReader"/></param>
        public static void FromHourTable(this List<FloutecHourlyData> hourlyData, OleDbDataReader reader)
        {
                FloutecHourlyData data = new FloutecHourlyData();

                data.DAT = DateTime.ParseExact(GetReaderValue(reader, "DAT", "").Trim(), datetimeFormats, new CultureInfo("en-US"), DateTimeStyles.None);
                data.DAT_END = DateTime.ParseExact(GetReaderValue(reader, "DAT_END", "").Trim(), datetimeFormats, new CultureInfo("en-US"), DateTimeStyles.None);
                data.RASX = GetReaderValue(reader, "RASX", 0.0);
                data.DAVL = GetReaderValue(reader, "DAVL", 0.0);
                data.PD = GetReaderValue(reader, "PD", "");
                data.TEMP = GetReaderValue(reader, "TEMP", 0.0);
                data.PT = GetReaderValue(reader, "PT", "");
                data.PEREP = GetReaderValue(reader, "PEREP", 0.0);
                data.PP = GetReaderValue(reader, "PP", "");
                data.PLOTN = GetReaderValue(reader, "PLOTN", 0.0);
                data.PL = GetReaderValue(reader, "PL", "");

                hourlyData.Add(data);
        }

        #endregion

        #region Методы расширения для FloutecInstantData

        /// <summary>
        /// Метод расширения объекта мгновенных данных для получения данных из таблицы мгновенных данных
        /// </summary>
        /// <param name="instantData">Объект мгновенных данных</param>
        /// <param name="reader"><see cref="OleDbDataReader"/></param>
        public static void FromInstTable(this FloutecInstantData instantData, OleDbDataReader reader)
        {
            instantData.DAT = DateTime.ParseExact(GetReaderValue(reader, "DAT", "").Trim(), datetimeFormats, new CultureInfo("en-US"), DateTimeStyles.None);
            instantData.ABSP = GetReaderValue(reader, "ABSP", 0.0);
            instantData.ALARMRY = GetReaderValue(reader, "ALARMRY", 0.0);
            instantData.ALARMSY = GetReaderValue(reader, "ALARMSY", 0.0);
            instantData.ALLSPEND = GetReaderValue(reader, "ALLSPEND", 0.0);
            instantData.CURRSPEND = GetReaderValue(reader, "CURRSPEND", 0.0);
            instantData.DAYSPEND = GetReaderValue(reader, "DAYSPEND", 0);
            instantData.DLITAS = GetReaderValue(reader, "DLITAS", 0);
            instantData.DLITBAS = GetReaderValue(reader, "DLITBAS", 0);
            instantData.DLITMAS = GetReaderValue(reader, "DLITMAS", 0);
            instantData.GASVIZ = GetReaderValue(reader, "GASVIZ", 0.0);
            instantData.GAZPLOTNNU = GetReaderValue(reader, "GAZPLOTNNU", 0.0);
            instantData.GAZPLOTNRU = GetReaderValue(reader, "GAZPLOTNRU", 0.0);
            instantData.LASTMONTHSPEND = GetReaderValue(reader, "LASTMONTHSPEND", 0.0);
            instantData.MONTHSPEND = GetReaderValue(reader, "MONTHSPEND", 0.0);
            instantData.PALARMRY = GetReaderValue(reader, "PALARMRY", 0.0);
            instantData.PALARMSY = GetReaderValue(reader, "PALARMSY", 0.0);
            instantData.PD = GetReaderValue(reader, "PD", "");
            instantData.PDLITAS = GetReaderValue(reader, "PDLITAS", 0);
            instantData.PDLITBAS = GetReaderValue(reader, "PDLITBAS", 0);
            instantData.PDLITMAS = GetReaderValue(reader, "PDLITMAS", 0);
            instantData.PERPRES = GetReaderValue(reader, "PERPRES", 0.0);
            instantData.PP = GetReaderValue(reader, "PP", "");
            instantData.PQHOUR = GetReaderValue(reader, "PQHOUR", 0.0);
            instantData.PT = GetReaderValue(reader, "PT", "");
            instantData.QHOUR = GetReaderValue(reader, "QHOUR", 0.0);
            instantData.SQROOT = GetReaderValue(reader, "SQROOT", 0.0);
            instantData.STPRES = GetReaderValue(reader, "STPRES", 0.0);
            instantData.TEMP = GetReaderValue(reader, "TEMP", 0.0);
            instantData.YESTSPEND = GetReaderValue(reader, "YESTSPEND", 0.0);
        }

        /// <summary>
        /// Метод определения равенства объектов мгновенных данных
        /// </summary>
        /// <param name="newData">Новые данные</param>
        /// <param name="exData">Существующие данные</param>
        /// <returns></returns>
        public static bool IsEqual(this FloutecInstantData newData, FloutecInstantData exData)
        {
            return newData != null && exData != null && newData.DAT.Equals(exData.DAT);
        }

        #endregion

        #region Вспомогательные методы

        // Метод для получения записи с преобразованием к необходимому формату данных 
        private static T GetReaderValue<T>(OleDbDataReader reader, string ordinal, T defaultValue = default(T))
        {
            try
            {
                return (T)Convert.ChangeType(reader[ordinal], typeof(T));
            }
            catch (Exception)
            {
                return defaultValue;
            }
        }

        #endregion
    }
}
