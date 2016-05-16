using NGVSCAN.CORE.Entities.Common;
using System;

namespace NGVSCAN.CORE.Entities
{
    /// <summary>
    /// Описание сущности "Линия (нитка, точка ...) измерения" (абстрактный)
    /// </summary>
    public abstract class MeasureLine : IEntity
    {
        #region Общие свойства

        /// <summary>
        /// Идентификатор (первичный ключ) линии измерения
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Дата и время создания (добавления) линии измерения
        /// </summary>
        public DateTime DateCreated { get; set; }

        /// <summary>
        /// Дата и время изменения (модификации) линии измерения
        /// </summary>
        public DateTime DateModified { get; set; }

        /// <summary>
        /// Признак удаления линии измерения
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// Дата и время удаления линии измерения
        /// </summary>
        public DateTime? DateDeleted { get; set; }

        #endregion

        #region Свойства

        /// <summary>
        /// Название линии измерения
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Описание (назначения) линии измерения
        /// </summary>
        public string Description { get; set; }

        #endregion

        #region Навигационные свойства

        /// <summary>
        /// Идентификатор (первичный ключ) вычислителя
        /// </summary>
        public int EstimatorId { get; set; }

        /// <summary>
        /// Вычислитель
        /// </summary>
        public virtual Estimator Estimator { get; set; }

        #endregion
    }
}
