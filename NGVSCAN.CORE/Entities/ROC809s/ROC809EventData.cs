using NGVSCAN.CORE.Entities.Common;
using System;

namespace NGVSCAN.CORE.Entities.ROC809s
{
    /// <summary>
    /// Описание сущности "Суточные данные вычислителя ROC809"
    /// </summary>
    public class ROC809EventData : IEntity
    {
        #region Общие свойства

        /// <summary>
        /// Идентификатор (первичный ключ) суточных данных
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Дата и время создания (добавления) суточных данных
        /// </summary>
        public DateTime DateCreated { get; set; }

        /// <summary>
        /// Дата и время изменения (модификации) суточных данных
        /// </summary>
        public DateTime DateModified { get; set; }

        /// <summary>
        /// Признак удаления суточных данных
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// Дата и время удаления суточных данных
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
        public int? OperatorId { get; set; }

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
        /// Идентификатор (первичный ключ) точки измерения 
        /// </summary>
        public int ROC809MeasurePointId { get; set; }

        /// <summary>
        /// Точка измерения
        /// </summary>
        public virtual ROC809MeasurePoint MeasurePoint { get; set; }

        #endregion
    }
}
