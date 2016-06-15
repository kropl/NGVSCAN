﻿using NGVSCAN.CORE.Entities.Common;
using NGVSCAN.CORE.Entities.ROC809s.Common;
using System;

namespace NGVSCAN.CORE.Entities.ROC809s
{
    /// <summary>
    /// Описание сущности "Суточные данные вычислителя ROC809"
    /// </summary>
    public class ROC809DailyData : IEntity, IROC809PeriodicData
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

        /// <summary>
        /// Период накопления (усреднения) суточных данных
        /// </summary>
        public DateTime DatePeriod { get; set; }

        /// <summary>
        /// Накопленное (усреднённое) значение
        /// </summary>
        public double Value { get; set; }

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