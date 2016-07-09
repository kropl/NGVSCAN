using NGVSCAN.CORE.Entities.Common;
using System;

namespace NGVSCAN.CORE.Entities.ROC809s
{
    /// <summary>
    /// Описание сущности "Данные аварий вычислителя ROC809"
    /// </summary>
    public class ROC809AlarmData : IEntity
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

        #endregion

        #region Свойства

        /// <summary>
        /// Тип аварии
        /// </summary>
        public int Type { get; set; }

        /// <summary>
        /// Дата и время аварии
        /// </summary>
        public DateTime Time { get; set; }

        /// <summary>
        /// Флаг посылки отчёта по исключению
        /// </summary>
        public bool SRBX { get; set; }

        /// <summary>
        /// Флаг состояния аварии (1 - установлена)
        /// </summary>
        public bool Condition { get; set; }

        /// <summary>
        /// Type
        /// </summary>
        public int? T { get; set; }

        /// <summary>
        /// Location
        /// </summary>
        public int? L { get; set; }

        /// <summary>
        /// Parameter
        /// </summary>
        public int? P { get; set; }

        /// <summary>
        /// Значение
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// Описание
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Дополнительный код типа аварии
        /// </summary>
        public int? Code { get; set; }

        /// <summary>
        /// Номер записи в таблице последовательности функций
        /// </summary>
        public int? FST { get; set; }

        #endregion

        #region Навигационные свойства

        /// <summary>
        /// Идентификатор (первичный ключ) выичлсителя ROC809 
        /// </summary>
        public int ROC809Id { get; set; }

        /// <summary>
        /// Вычислитель ROC809
        /// </summary>
        public virtual ROC809 ROC809 { get; set; }

        #endregion
    }
}
