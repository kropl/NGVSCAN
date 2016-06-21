using NGVSCAN.CORE.Entities.Common;

namespace NGVSCAN.CORE.Entities.Floutecs.Common
{
    /// <summary>
    /// Описание сущности "Типы параметров вычислителей ФЛОУТЭК"
    /// </summary>
    public class FloutecParamsTypes : ICatalog
    {
        /// <summary>
        /// Код параметра
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// Аббревиатура параметра
        /// </summary>
        public string Param { get; set; }

        /// <summary>
        /// Описание параметра
        /// </summary>
        public string Description { get; set; }
    }
}
