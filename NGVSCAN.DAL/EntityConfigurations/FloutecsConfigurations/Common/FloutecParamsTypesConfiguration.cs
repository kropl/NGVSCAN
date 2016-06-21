using NGVSCAN.CORE.Entities.Floutecs.Common;
using NGVSCAN.DAL.EntityConfigurations.Common;

namespace NGVSCAN.DAL.EntityConfigurations.FloutecsConfigurations.Common
{
    /// <summary>
    /// Конфигурация типов параметров вычислителей ФЛОУТЭК
    /// </summary>
    public class FloutecParamsTypesConfiguration : CatalogConfiguration<FloutecParamsTypes>
    {
        /// <summary>
        /// Конфигурация типов параметров вычислителей ФЛОУТЭК
        /// </summary>
        public FloutecParamsTypesConfiguration()
        {
            Property(p => p.Param).IsRequired().HasMaxLength(25);
            ToTable("FloutecParamsTypes");
        }
    }
}
