using NGVSCAN.CORE.Enums;
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

        #endregion
    }
}
