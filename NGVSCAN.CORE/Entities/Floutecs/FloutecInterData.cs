using NGVSCAN.CORE.Entities.Common;
using NGVSCAN.CORE.Entities.Floutecs.Common;
using System;

namespace NGVSCAN.CORE.Entities.Floutecs
{
    /// <summary>
    /// Описание сущности "Данные вмешательств вычислителя ФЛОУТЭК"
    /// </summary>
    public class FloutecInterData : IEntity, IFloutecData
    {
        #region Общие свойства

        /// <summary>
        /// Идентификатор (первичный ключ) данных вмешательств
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Дата и время создания (добавления) данных вмешательств
        /// </summary>
        public DateTime DateCreated { get; set; }

        /// <summary>
        /// Дата и время изменения (модификации) данных вмешательств
        /// </summary>
        public DateTime DateModified { get; set; }

        /// <summary>
        /// Признак удаления данных вмешательств
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// Дата и время удаления данных вмешательств
        /// </summary>
        public DateTime? DateDeleted { get; set; }

        /// <summary>
        /// Адрес вычислителя * 10 + номер нитки измерения
        /// </summary>
        public int N_FLONIT { get; set; }

        #endregion

        #region Свойства

        /// <summary>
        /// Дата и время вмешательства
        /// </summary>
        public DateTime DAT { get; set; }

        /// <summary>
        /// Тип вмешательства
        /// </summary>
        public int CH_PAR { get; set; }

        /// <summary>
        /// Тип параметра
        /// </summary>
        public int? T_PARAM { get; set; }

        /// <summary>
        /// Старое значение
        /// </summary>
        public string VAL_OLD { get; set; }

        /// <summary>
        /// Новое значение
        /// </summary>
        public string VAL_NEW { get; set; }

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
