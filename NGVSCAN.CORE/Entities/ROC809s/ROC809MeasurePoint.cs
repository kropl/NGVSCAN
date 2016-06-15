namespace NGVSCAN.CORE.Entities.ROC809s
{
    /// <summary>
    /// Описание сущности "Точка измерения вычислителя ROC809"
    /// </summary>
    public class ROC809MeasurePoint : MeasureLine
    {
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

        #endregion
    }
}
