using NGVSCAN.CORE.Entities.Common;

namespace NGVSCAN.CORE.Entities.ROC809s.Common
{
    /// <summary>
    /// Описание сущности "Дополнительные коды типов аварий вычислителей ROC809"
    /// </summary>
    public class ROC809AlarmsCodes : ICatalog
    {
        /// <summary>
        /// Дополнительный код типа аварии
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// Описание дополнительного кода типа аварии
        /// </summary>
        public string Description { get; set; }
    }
}
