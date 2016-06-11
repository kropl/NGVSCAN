using NGVSCAN.CORE.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NGVSCAN.CORE.Entities
{
    /// <summary>
    /// Описание сущности "Данные аварий вычислителя ФЛОУТЭК"
    /// </summary>
    public class FloutecAlarmData : IEntity, IFloutecData
    {
        #region Общие свойства

        /// <summary>
        /// Идентификатор (первичный ключ) данных аварий
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Дата и время создания (добавления) данных аварий
        /// </summary>
        public DateTime DateCreated { get; set; }

        /// <summary>
        /// Дата и время изменения (модификации) данных аварий
        /// </summary>
        public DateTime DateModified { get; set; }

        /// <summary>
        /// Признак удаления данных аварий
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// Дата и время удаления данных аварий
        /// </summary>
        public DateTime? DateDeleted { get; set; }

        /// <summary>
        /// Адрес вычислителя * 10 + номер нитки измерения
        /// </summary>
        public int N_FLONIT { get; set; }

        #endregion

        #region Свойства

        /// <summary>
        /// Дата и время возникновения аварийной ситуации
        /// </summary>
        public DateTime DAT { get; set; }

        /// <summary>
        /// Тип аварии
        /// </summary>
        public int T_AVAR { get; set; }

        /// <summary>
        /// Тип параметра
        /// </summary>
        public int T_PARAM { get; set; }

        /// <summary>
        /// Поле данных (объём с начала суток)
        /// </summary>
        public double VAL { get; set; }

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
