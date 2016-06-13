using NGVSCAN.CORE.Enums;
using System;
using System.Collections.Generic;

namespace NGVSCAN.CORE.Entities
{
    /// <summary>
    /// Описание сущности "Линия измерения вычислителя ФЛОУТЭК"
    /// </summary>
    public class FloutecMeasureLine : MeasureLine
    {
        #region Конструктор и поля

        public FloutecMeasureLine()
        {
            // Инициализация коллекции часовых данных
            HourlyData = new HashSet<FloutecHourlyData>();

            // Инициализация коллекции данных идентификации
            IdentData = new HashSet<FloutecIdentData>();

            // Инициализация коллекции мгновенных данных
            InstantData = new HashSet<FloutecInstantData>();

            // Инициализация коллекции данных аварий
            AlarmData = new HashSet<FloutecAlarmData>();

            // Инициализация коллекции данных вмешательств
            InterData = new HashSet<FloutecInterData>();
        }

        #endregion

        #region Свойства

        /// <summary>
        /// Порядковый номер линии
        /// </summary>
        public int Number { get; set; }

        /// <summary>
        /// Тип датчика: <see cref="SensorTypeEnum"/>
        /// </summary>
        public SensorTypeEnum SensorType { get; set; }

        /// <summary>
        /// Период опроса часовых данных, минут
        /// </summary>
        public int HourlyDataScanPeriod { get; set; }

        /// <summary>
        /// Дата и время последнего опроса часовых данных
        /// </summary>
        public DateTime? DateHourlyDataLastScanned { get; set; }

        /// <summary>
        /// Период опроса мгновенных данных, минут
        /// </summary>
        public int InstantDataScanPeriod { get; set; }

        /// <summary>
        /// Дата и время последнего опроса мгновенных данных
        /// </summary>
        public DateTime? DateInstantDataLastScanned { get; set; }

        #endregion

        #region Навигационные свойства

        /// <summary>
        /// Коллекция часовых данных 
        /// </summary>
        public virtual ICollection<FloutecHourlyData> HourlyData { get; set; }

        /// <summary>
        /// Коллекция данных идентификации 
        /// </summary>
        public virtual ICollection<FloutecIdentData> IdentData { get; set; }

        /// <summary>
        /// Коллекция мгновенных данных 
        /// </summary>
        public virtual ICollection<FloutecInstantData> InstantData { get; set; }

        /// <summary>
        /// Коллекция данных аварий 
        /// </summary>
        public virtual ICollection<FloutecAlarmData> AlarmData { get; set; }

        /// <summary>
        /// Коллекция данных вмешательств 
        /// </summary>
        public virtual ICollection<FloutecInterData> InterData { get; set; }

        #endregion
    }
}
