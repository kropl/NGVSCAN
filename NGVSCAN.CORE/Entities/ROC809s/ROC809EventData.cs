using NGVSCAN.CORE.Entities.Common;
using System;

namespace NGVSCAN.CORE.Entities.ROC809s
{
    /// <summary>
    /// Описание сущности "Данные событий вычислителя ROC809"
    /// </summary>
    public class ROC809EventData : IEntity
    {
        #region Общие свойства

        /// <summary>
        /// Идентификатор (первичный ключ) данных событий
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Дата и время создания (добавления) данных событий
        /// </summary>
        public DateTime DateCreated { get; set; }

        /// <summary>
        /// Дата и время изменения (модификации) данных событий
        /// </summary>
        public DateTime DateModified { get; set; }

        /// <summary>
        /// Признак удаления данных событий
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// Дата и время удаления данных событий
        /// </summary>
        public DateTime? DateDeleted { get; set; }

        #endregion

        #region Свойства

        /// <summary>
        /// Тип события
        /// </summary>
        public int Type { get; set; }

        /// <summary>
        /// Дата и время события
        /// </summary>
        public DateTime Time { get; set; }

        /// <summary>
        /// Идентификатор оператора
        /// </summary>
        public string OperatorId { get; set; }

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
        /// Новое значение
        /// </summary>
        public string NewValue { get; set; }

        /// <summary>
        /// Старое значение
        /// </summary>
        public string OldValue { get; set; }

        /// <summary>
        /// Некалиброванное значение
        /// </summary>
        public string RawValue { get; set; }

        /// <summary>
        /// Калиброванное значение
        /// </summary>
        public string CalibratedValue { get; set; }

        /// <summary>
        /// Описание
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Дополнительный код типа события
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
