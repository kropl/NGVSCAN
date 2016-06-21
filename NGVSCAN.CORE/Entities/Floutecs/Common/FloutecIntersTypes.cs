using NGVSCAN.CORE.Entities.Common;

namespace NGVSCAN.CORE.Entities.Floutecs.Common
{
    /// <summary>
    /// Описание сущности "Типы вмешательств вычислителей ФЛОУТЭК"
    /// </summary>
    public class FloutecIntersTypes : ICatalog
    {
        /// <summary>
        /// Код вмешательства
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// Описание кода вмешательства для вычислителей с версией ПО до 45
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Описание кода вмешательства для вычислителей с версией ПО от 45 включительно
        /// </summary>
        public string Description_45 { get; set; }
    }
}
