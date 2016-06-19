using NGVSCAN.CORE.Entities.ROC809s;
using NGVSCAN.DAL.EntityConfigurations.Common;

namespace NGVSCAN.DAL.EntityConfigurations.ROC809sConfigurations
{
    /// <summary>
    /// Конфигурация сущности "Минутные данные вычислителя ROC809"
    /// </summary>
    public class ROC809MinuteDataConfiguration : EntityConfiguration<ROC809MinuteData>
    {
        /// <summary>
        /// Конфигурация сущности "Минутные данные вычислителя ROC809"
        /// </summary>
        public ROC809MinuteDataConfiguration()
        {
            Property(m => m.Value).IsRequired();
            Property(m => m.DatePeriod).IsRequired().HasColumnType("datetime2");
            ToTable("ROC809MinuteData");
        }
    }
}
