using NGVSCAN.CORE.Entities.Common;

namespace NGVSCAN.CORE.Entities.ROC809s.Common
{
    /// <summary>
    /// Описание сущности "Типы аварий вычислителей ROC809"
    /// </summary>
    public class ROC809AlarmsTypes : ICatalog
    {
        /// <summary>
        /// Код аварии
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// Описание кода аварии
        /// </summary>
        public string Description { get; set; }
    }
}
