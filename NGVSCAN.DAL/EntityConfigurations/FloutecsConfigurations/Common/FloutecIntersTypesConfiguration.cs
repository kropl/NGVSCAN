using NGVSCAN.CORE.Entities.Floutecs.Common;
using NGVSCAN.DAL.EntityConfigurations.Common;

namespace NGVSCAN.DAL.EntityConfigurations.FloutecsConfigurations.Common
{
    /// <summary>
    /// Конфигурация типов вмешательств вычислителей ФЛОУТЭК
    /// </summary>
    public class FloutecIntersTypesConfiguration : CatalogConfiguration<FloutecIntersTypes>
    {
        /// <summary>
        /// Конфигурация типов вмешательств вычислителей ФЛОУТЭК
        /// </summary>
        public FloutecIntersTypesConfiguration()
        {
            Property(p => p.Description_45).IsRequired().HasMaxLength(400);
            ToTable("FloutecIntersTypes");
        }
    }
}
