using NGVSCAN.CORE.Entities.ROC809s;
using NGVSCAN.DAL.EntityConfigurations.Common;

namespace NGVSCAN.DAL.EntityConfigurations.ROC809sConfigurations
{
    /// <summary>
    /// Конфигурация сущности "Данные аварий вычислителя ROC809"
    /// </summary>
    public class ROC809AlarmDataConfiguration : EntityConfiguration<ROC809AlarmData>
    {
        /// <summary>
        /// Конфигурация сущности "Данные аварий вычислителя ROC809"
        /// </summary>
        public ROC809AlarmDataConfiguration()
        {
            Property(a => a.Type).IsRequired();
            Property(a => a.Time).IsRequired().HasColumnType("datetime2");
            Property(a => a.SRBX).IsRequired();
            Property(a => a.Condition).IsRequired();
            Property(a => a.T).IsOptional();
            Property(a => a.L).IsOptional();
            Property(a => a.P).IsOptional();
            Property(a => a.Value).IsRequired().HasMaxLength(10);
            Property(a => a.Description).IsRequired().HasMaxLength(20);
            Property(a => a.Code).IsOptional();
            Property(a => a.FST).IsOptional();
            ToTable("ROC809AlarmData");
        }
    }
}
