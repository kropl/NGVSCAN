using NGVSCAN.CORE.Entities.ROC809s;
using NGVSCAN.DAL.EntityConfigurations.Common;

namespace NGVSCAN.DAL.EntityConfigurations.ROC809sConfigurations
{
    /// <summary>
    /// Конфигурация сущности "Периодические данные вычислителя ROC809"
    /// </summary>
    public class ROC809PeriodicDataConfiguration : EntityConfiguration<ROC809PeriodicData>
    {
        /// <summary>
        /// Конфигурация сущности "Периодические данные вычислителя ROC809"
        /// </summary>
        public ROC809PeriodicDataConfiguration()
        {
            Property(p => p.Value).IsRequired();
            Property(p => p.DatePeriod).IsRequired().HasColumnType("datetime2");
            ToTable("ROC809PeriodicData");
        }
    }
}
