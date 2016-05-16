using NGVSCAN.CORE.Entities.Common;
using System;

namespace NGVSCAN.CORE.Entities
{
    /// <summary>
    /// Описание сущности "Вычислитель" (абстрактный)
    /// </summary>
    public abstract class Estimator : IEntity
    {
        #region Общие свойства

        /// <summary>
        /// Идентификатор (первичный ключ) вычислителя
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Дата и время создания (добавления) вычислителя
        /// </summary>
        public DateTime DateCreated { get; set; }

        /// <summary>
        /// Дата и время изменения (модификации) вычислителя
        /// </summary>
        public DateTime DateModified { get; set; }

        /// <summary>
        /// Признак удаления вычислителя
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// Дата и время удаления вычислителя
        /// </summary>
        public DateTime? DateDeleted { get; set; }

        #endregion

        #region Свойства

        /// <summary>
        /// Название вычислителя
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Описание (назначения) вычислителя
        /// </summary>
        public string Description { get; set; }

        #endregion

        #region Навигационные свойства

        /// <summary>
        /// Идентификатор (первичный ключ) установки вычислителя
        /// </summary>
        public int FieldId { get; set; }

        /// <summary>
        /// Установка вычислителя
        /// </summary>
        public virtual Field Field { get; set; }

        #endregion
    }
}
