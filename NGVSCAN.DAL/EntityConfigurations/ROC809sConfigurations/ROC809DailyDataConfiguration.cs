using NGVSCAN.CORE.Entities.ROC809s;
using NGVSCAN.DAL.EntityConfigurations.Common;

namespace NGVSCAN.DAL.EntityConfigurations.ROC809sConfigurations
{
    /// <summary>
    /// Конфигурация сущности "Суточные данные вычислителя ROC809"
    /// </summary>
    public class ROC809DailyDataConfiguration : EntityConfiguration<ROC809DailyData>
    {
        /// <summary>
        /// Конфигурация сущности "Суточные данные вычислителя ROC809"
        /// </summary>
        public ROC809DailyDataConfiguration()
        {
            Property(d => d.Value).IsRequired();
            Property(d => d.DatePeriod).IsRequired().HasColumnType("datetime2");
            ToTable("ROC809DailyData");
        }
    }
}
