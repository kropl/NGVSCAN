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
        }

        #endregion

        #region Свойства

        /// <summary>
        /// Порядковый номер линии
        /// </summary>
        public int Number { get; set; }

        #endregion

        #region Навигационные свойства

        /// <summary>
        /// Коллекция часовых данных 
        /// </summary>
        public virtual ICollection<FloutecHourlyData> HourlyData { get; set; }

        #endregion
    }
}
