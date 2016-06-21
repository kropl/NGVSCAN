using NGVSCAN.CORE.Entities.Common;

namespace NGVSCAN.CORE.Entities.Floutecs.Common
{
    /// <summary>
    /// Список типов сенсоров для вычислителей ФЛОУТЭК
    /// </summary>
    public class FloutecSensorsTypes : ICatalog
    {
        /// <summary>
        /// Код сенсора
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// Название сенсора
        /// </summary>
        public string Description { get; set; }
    }
}
