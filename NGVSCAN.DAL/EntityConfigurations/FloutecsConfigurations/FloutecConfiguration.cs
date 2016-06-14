using NGVSCAN.CORE.Entities.Floutecs;
using NGVSCAN.DAL.EntityConfigurations.Common;

namespace NGVSCAN.DAL.EntityConfigurations.FloutecsConfigurations
{
    /// <summary>
    /// Конфигурация сущности "Вычислитель ФЛОУТЭК"
    /// </summary>
    public class FloutecConfiguration : EntityConfiguration<Floutec>
    {
        /// <summary>
        /// Конфигурация сущности "Вычислитель ФЛОУТЭК"
        /// </summary>
        public FloutecConfiguration()
        {
            Property(f => f.Address).IsRequired();
            ToTable("Floutecs");
        }
    }
}
