﻿using System.Collections.Generic;

namespace NGVSCAN.CORE.Entities.ROC809s
{
    /// <summary>
    /// Описание сущности "Точка измерения вычислителя ROC809"
    /// </summary>
    public class ROC809MeasurePoint : MeasureLine
    {
        #region Конструктор и поля

        public ROC809MeasurePoint()
        {
            // Инициализация коллекции минутных данных
            MinuteData = new HashSet<ROC809MinuteData>();

            // Инициализация коллекции периодических данных
            PeriodicData = new HashSet<ROC809PeriodicData>();

            // Инициализация коллекции суточных данных
            DailyData = new HashSet<ROC809DailyData>();
        }

        #endregion

        #region Свойства

        /// <summary>
        /// Номер точки измерения
        /// </summary>
        public int Number { get; set; }

        /// <summary>
        /// Исторический сегмент точки измерения
        /// </summary>
        public int HistSegment { get; set; }

        #endregion

        #region Навигационные свойства

        /// <summary>
        /// Коллекция минутных данных 
        /// </summary>
        public virtual ICollection<ROC809MinuteData> MinuteData { get; set; }

        /// <summary>
        /// Коллекция периодических данных 
        /// </summary>
        public virtual ICollection<ROC809PeriodicData> PeriodicData { get; set; }

        /// <summary>
        /// Коллекция суточных данных 
        /// </summary>
        public virtual ICollection<ROC809DailyData> DailyData { get; set; }

        #endregion
    }
}