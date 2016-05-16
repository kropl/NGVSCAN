using NGVSCAN.CORE.Entities.Common;
using System;
using System.Collections.Generic;

namespace NGVSCAN.CORE.Entities
{
    /// <summary>
    /// Описание сущности "Установка"
    /// </summary>
    public class Field : IEntity
    {
        #region Конструктор и поля

        public Field()
        {
            // Инициализация коллекции вычислителей
            Estimators = new HashSet<Estimator>();
        }

        #endregion

        #region Общие свойства

        /// <summary>
        /// Идентификатор (первичный ключ) установки
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Дата и время создания (добавления) установки
        /// </summary>
        public DateTime DateCreated { get; set; }

        /// <summary>
        /// Дата и время изменения (модификации) установки
        /// </summary>
        public DateTime DateModified { get; set; }

        /// <summary>
        /// Признак удаления установки
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// Дата и время удаления установки
        /// </summary>
        public DateTime? DateDeleted { get; set; }

        #endregion

        #region Свойства

        /// <summary>
        /// Название установки (аббревиатура)
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Описание установки (полное название)
        /// </summary>
        public string Description { get; set; }

        #endregion

        #region Навигационные свойства

        /// <summary>
        /// Коллекция вычислителей установки
        /// </summary>
        public virtual ICollection<Estimator> Estimators { get; set; }

        #endregion
    }
}
