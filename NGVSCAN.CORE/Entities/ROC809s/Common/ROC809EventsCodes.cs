namespace NGVSCAN.CORE.Entities.ROC809s.Common
{
    /// <summary>
    /// Описание сущности "Дополнительные коды типов событий вычислителей ROC809"
    /// </summary>
    public class ROC809EventsCodes
    {
        /// <summary>
        /// Дополнительный код типа события
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// Описание дополнительного кода типа события
        /// </summary>
        public string Description { get; set; }
    }
}
