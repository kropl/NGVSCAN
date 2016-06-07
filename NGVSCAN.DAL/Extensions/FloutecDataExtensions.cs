using NGVSCAN.CORE.Entities;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Diagnostics;
using System.Globalization;

namespace NGVSCAN.DAL.Extensions
{
    public static class FloutecDataExtensions
    {
        private static string[] datetimeFormats = { @"M/d/yyyy hh:mm:ss tt", @"dd.MM.yyyy HH:mm:ss", @"dd.MM.yyyy H:mm:ss", @"dd.MM.yyyy" };

        private static string[] timeFormats = { @"hh:mm:ss tt", @"HH:mm:ss" };

        #region Методы расширения для FloutecIdentData

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

        public static void FromHourTable(this List<FloutecHourlyData> hourlyData, OleDbDataReader reader)
        {
            try
            {
                hourlyData.Add(new FloutecHourlyData
                {
                    DAT = DateTime.ParseExact(GetReaderValue(reader, "DAT", "").Trim(), datetimeFormats, new CultureInfo("en-US"), DateTimeStyles.None),
                    DAT_END = DateTime.ParseExact(GetReaderValue(reader, "DAT_END", "").Trim(), datetimeFormats, new CultureInfo("en-US"), DateTimeStyles.None),
                    RASX = GetReaderValue(reader, "RASX", 0.0),
                    DAVL = GetReaderValue(reader, "DAVL", 0.0),
                    PD = GetReaderValue(reader, "PD", ""),
                    TEMP = GetReaderValue(reader, "TEMP", 0.0),
                    PT = GetReaderValue(reader, "PT", ""),
                    PEREP = GetReaderValue(reader, "PEREP", 0.0),
                    PP = GetReaderValue(reader, "PP", ""),
                    PLOTN = GetReaderValue(reader, "PLOTN", 0.0),
                    PL = GetReaderValue(reader, "PL", "")
                });
            }
            catch(Exception)
            {
                throw;
            }
        }

        #endregion

        #region Вспомогательные методы

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

        private static FloutecIdentData GetReaderValues(OleDbDataReader reader)
        {
            return new FloutecIdentData
            {

            };
        }

        #endregion
    }
}
