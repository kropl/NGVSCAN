using NGVSCAN.CORE.Entities.ROC809s;
using NGVSCAN.DAL.EntityConfigurations.Common;

namespace NGVSCAN.DAL.EntityConfigurations.ROC809sConfigurations
{
    /// <summary>
    /// Конфигурация сущности "Точка измерения вычислителя ROC809"
    /// </summary>
    public class ROC809MeasurePointConfiguration : EntityConfiguration<ROC809MeasurePoint>
    {
        /// <summary>
        /// Конфигурация сущности "Точка измерения вычислителя ROC809"
        /// </summary>
        public ROC809MeasurePointConfiguration()
        {
            Property(p => p.Number).IsRequired();
            Property(p => p.HistSegment).IsRequired();
            HasMany(p => p.MinuteData).WithRequired(p => p.MeasurePoint);
            HasMany(p => p.PeriodicData).WithRequired(p => p.MeasurePoint);
            HasMany(p => p.DailyData).WithRequired(m => m.MeasurePoint);
            ToTable("ROC809MeasurePoints");
        }
    }
}
