using NGVSCAN.CORE.Entities.Common;
using System;

namespace NGVSCAN.CORE.Entities
{
    /// <summary>
    /// Описание сущности "Часовые данные вычислителя ФЛОУТЭК"
    /// </summary>
    public class FloutecHourlyData : IEntity, IFloutecData
    {
        #region Конструктор и поля

        public FloutecHourlyData()
        {
            // Инициализация свойства N_FLONIT
            N_FLONIT = MeasureLine.Number + ((Floutec)MeasureLine.Estimator).Address * 10;
        }

        #endregion

        #region Общие свойства

        /// <summary>
        /// Идентификатор (первичный ключ) часовых данных
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Дата и время создания (добавления) часовых данных
        /// </summary>
        public DateTime DateCreated { get; set; }

        /// <summary>
        /// Дата и время изменения (модификации) часовых данных
        /// </summary>
        public DateTime DateModified { get; set; }

        /// <summary>
        /// Признак удаления часовых данных
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// Дата и время удаления часовых данных
        /// </summary>
        public DateTime? DateDeleted { get; set; }

        /// <summary>
        /// Адрес вычислителя * 10 + номер нитки измерения
        /// </summary>
        public int N_FLONIT { get; private set; }

        #endregion

        #region Свойства



        #endregion

        #region Навигационные свойства

        /// <summary>
        /// Идентификатор (первичный ключ) линии измерения 
        /// </summary>
        public int FloutecMeasureLineId { get; set; }

        /// <summary>
        /// Линия измерения
        /// </summary>
        public virtual FloutecMeasureLine MeasureLine { get; set; }

        #endregion
    }
}
