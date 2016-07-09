using NGVSCAN.CORE.Entities.ROC809s;
using NGVSCAN.DAL.EntityConfigurations.Common;

namespace NGVSCAN.DAL.EntityConfigurations.ROC809sConfigurations
{
    /// <summary>
    /// Конфигурация сущности "Вычислитель ROC809"
    /// </summary>
    public class ROC809Configuration : EntityConfiguration<ROC809>
    {
        /// <summary>
        /// Конфигурация сущности "Вычислитель ROC809"
        /// </summary>
        public ROC809Configuration()
        {
            Property(r => r.Address).IsRequired().HasMaxLength(15);
            Property(r => r.Port).IsRequired();
            Property(r => r.ROCUnit).IsRequired();
            Property(r => r.ROCGroup).IsRequired();
            Property(r => r.HostUnit).IsRequired();
            Property(r => r.HostGroup).IsRequired();
            HasMany(r => r.EventData).WithRequired(r => r.ROC809);
            HasMany(r => r.AlarmData).WithRequired(r => r.ROC809);
            ToTable("ROC809s");
        }
    }
}
