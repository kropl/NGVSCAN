using NGVSCAN.CORE.Entities.Floutecs;
using NGVSCAN.DAL.EntityConfigurations.Common;

namespace NGVSCAN.DAL.EntityConfigurations.FloutecsConfigurations
{
    /// <summary>
    /// Конфигурация сущности "Данные аварий вычислителя ФЛОУТЭК"
    /// </summary>
    public class FloutecAlarmDataConfiguration : EntityConfiguration<FloutecAlarmData>
    {
        /// <summary>
        /// Конфигурация сущности "Данные аварий вычислителя ФЛОУТЭК"
        /// </summary>
        public FloutecAlarmDataConfiguration()
        {
            Property(a => a.N_FLONIT).IsRequired();
            Property(a => a.DAT).IsRequired().HasColumnType("datetime2");
            Property(a => a.T_AVAR).IsRequired();
            Property(a => a.T_PARAM).IsRequired();
            ToTable("FloutecAlarmData");
        }
    }
}
