using NGVSCAN.CORE.Entities.Floutecs.Common;
using NGVSCAN.DAL.EntityConfigurations.Common;

namespace NGVSCAN.DAL.EntityConfigurations.FloutecsConfigurations.Common
{
    /// <summary>
    /// Конфигурация типов аварий вычислителей ФЛОУТЭК
    /// </summary>
    public class FloutecAlarmsTypesConfiguration : CatalogConfiguration<FloutecAlarmsTypes>
    {
        /// <summary>
        /// Конфигурация типов аварий вычислителей ФЛОУТЭК
        /// </summary>
        public FloutecAlarmsTypesConfiguration()
        {
            Property(p => p.Description_45).IsRequired().HasMaxLength(400);
            ToTable("FloutecAlarmsTypes");
        }
    }
}
