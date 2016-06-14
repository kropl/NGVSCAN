using NGVSCAN.CORE.Entities.Floutecs;
using NGVSCAN.DAL.EntityConfigurations.Common;

namespace NGVSCAN.DAL.EntityConfigurations.FloutecsConfigurations
{
    /// <summary>
    /// Конфигурация сущности "Часовые данные вычислителя ФЛОУТЭК"
    /// </summary>
    public class FloutecHourlyDataConfiguration : EntityConfiguration<FloutecHourlyData>
    {
        /// <summary>
        /// Конфигурация сущности "Часовые данные вычислителя ФЛОУТЭК"
        /// </summary>
        public FloutecHourlyDataConfiguration()
        {
            Property(h => h.N_FLONIT).IsRequired();
            Property(h => h.DAT).IsRequired().HasColumnType("datetime2");
            Property(h => h.DAT_END).IsRequired().HasColumnType("datetime2");
            Property(h => h.RASX).IsRequired();
            Property(h => h.DAVL).IsRequired();
            Property(h => h.PD).IsRequired().HasMaxLength(1);
            Property(h => h.TEMP).IsRequired();
            Property(h => h.PT).IsRequired().HasMaxLength(1);
            Property(h => h.PEREP).IsRequired();
            Property(h => h.PP).IsRequired().HasMaxLength(1);
            Property(h => h.PLOTN).IsRequired();
            Property(h => h.PL).IsRequired().HasMaxLength(1);
            ToTable("FloutecHourlyData");
        }
    }
}
