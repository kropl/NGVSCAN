using NGVSCAN.CORE.Entities.ROC809s;
using NGVSCAN.DAL.EntityConfigurations.Common;

namespace NGVSCAN.DAL.EntityConfigurations.ROC809sConfigurations
{
    /// <summary>
    /// Конфигурация сущности "Данные событий вычислителя ROC809"
    /// </summary>
    public class ROC809EventDataConfiguration : EntityConfiguration<ROC809EventData>
    {
        /// <summary>
        /// Конфигурация сущности "Данные событий вычислителя ROC809"
        /// </summary>
        public ROC809EventDataConfiguration()
        {
            Property(e => e.Type).IsRequired();
            Property(e => e.Time).IsRequired().HasColumnType("datetime2");
            Property(e => e.OperatorId).IsOptional();
            Property(e => e.T).IsOptional();
            Property(e => e.L).IsOptional();
            Property(e => e.P).IsOptional();
            Property(e => e.Value).IsRequired().HasMaxLength(10);
            Property(e => e.NewValue).IsRequired().HasMaxLength(10);
            Property(e => e.OldValue).IsRequired().HasMaxLength(10);
            Property(e => e.RawValue).IsRequired().HasMaxLength(10);
            Property(e => e.CalibratedValue).IsRequired().HasMaxLength(10);
            Property(e => e.Description).IsRequired().HasMaxLength(20);
            Property(e => e.Code).IsOptional();
            Property(e => e.FST).IsOptional();
            ToTable("ROC809EventData");
        }
    }
}
