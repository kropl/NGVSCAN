using NGVSCAN.CORE.Entities.Floutecs;
using NGVSCAN.DAL.EntityConfigurations.Common;

namespace NGVSCAN.DAL.EntityConfigurations.FloutecsConfigurations
{
    /// <summary>
    /// Конфигурация сущности "Мгновенные данные вычислителя ФЛОУТЭК"
    /// </summary>
    public class FloutecInstantDataConfiguration : EntityConfiguration<FloutecInstantData>
    {
        /// <summary>
        /// Конфигурация сущности "Мгновенные данные вычислителя ФЛОУТЭК"
        /// </summary>
        public FloutecInstantDataConfiguration()
        {
            Property(i => i.N_FLONIT).IsRequired();
            Property(i => i.DAT).IsRequired().HasColumnType("datetime2");
            Property(i => i.ABSP).IsRequired();
            Property(i => i.ALARMRY).IsRequired();
            Property(i => i.ALARMSY).IsRequired();
            Property(i => i.ALLSPEND).IsRequired();
            Property(i => i.CURRSPEND).IsRequired();
            Property(i => i.DAYSPEND).IsRequired();
            Property(i => i.DLITAS).IsRequired();
            Property(i => i.DLITBAS).IsRequired();
            Property(i => i.DLITMAS).IsRequired();
            Property(i => i.GASVIZ).IsRequired();
            Property(i => i.GAZPLOTNNU).IsRequired();
            Property(i => i.GAZPLOTNRU).IsRequired();
            Property(i => i.LASTMONTHSPEND).IsRequired();
            Property(i => i.MONTHSPEND).IsRequired();
            Property(i => i.PALARMRY).IsRequired();
            Property(i => i.PALARMSY).IsRequired();
            Property(i => i.PD).IsRequired().HasMaxLength(1);
            Property(i => i.PDLITAS).IsRequired();
            Property(i => i.PDLITBAS).IsRequired();
            Property(i => i.PDLITMAS).IsRequired();
            Property(i => i.PERPRES).IsRequired();
            Property(i => i.PP).IsRequired().HasMaxLength(1);
            Property(i => i.PQHOUR).IsRequired();
            Property(i => i.PT).IsRequired().HasMaxLength(1);
            Property(i => i.QHOUR).IsRequired();
            Property(i => i.SQROOT).IsRequired();
            Property(i => i.STPRES).IsRequired();
            Property(i => i.TEMP).IsRequired();
            Property(i => i.YESTSPEND).IsRequired();
            Property(i => i.PRITUPL).IsRequired();
            Property(i => i.REZ).IsRequired();
            ToTable("FloutecInstantData");
        }
    }
}
