using NGVSCAN.CORE.Entities.Floutecs.Common;
using NGVSCAN.DAL.EntityConfigurations.Common;

namespace NGVSCAN.DAL.EntityConfigurations.FloutecsConfigurations.Common
{
    /// <summary>
    /// Конфигурация типов датчиков вычислителей ФЛОУТЭК
    /// </summary>
    public class FloutecSensorsTypesConfiguration : CatalogConfiguration<FloutecSensorsTypes>
    {
        /// <summary>
        /// Конфигурация типов датчиков вычислителей ФЛОУТЭК
        /// </summary>
        public FloutecSensorsTypesConfiguration()
        {
            ToTable("FloutecSensorsTypes");
        }
    }
}
