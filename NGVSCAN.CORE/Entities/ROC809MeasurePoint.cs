namespace NGVSCAN.CORE.Entities
{
    /// <summary>
    /// Описание сущности "Точка измерения вычислителя ROC809"
    /// </summary>
    public class ROC809MeasurePoint : MeasureLine
    {
        #region Конструктор и поля

        #endregion

        #region Свойства

        /// <summary>
        /// Номер точки измерения
        /// </summary>
        public int Number { get; set; }

        /// <summary>
        /// Тип точки измерения
        /// </summary>
        public int Type { get; set; }

        /// <summary>
        /// Логический номер точки измерения
        /// </summary>
        public int LogicalNumber { get; set; }

        /// <summary>
        /// Номер параметра точки измерения
        /// </summary>
        public int ParameterNumber { get; set; }

        /// <summary>
        /// Исторический сегмент точки измерения
        /// </summary>
        public int HistSegment { get; set; }

        #endregion

        #region Навигационные свойства

        #endregion
    }
}
