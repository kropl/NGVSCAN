using NGVSCAN.CORE.Entities.Floutecs;
using NGVSCAN.DAL.EntityConfigurations.Common;

namespace NGVSCAN.DAL.EntityConfigurations.FloutecsConfigurations
{
    /// <summary>
    /// Конфигурация сущности "Линия измерения вычислителя ФЛОУТЭК"
    /// </summary>
    public class FloutecMeasureLineConfiguration : EntityConfiguration<FloutecMeasureLine>
    {
        /// <summary>
        /// Конфигурация сущности "Линия измерения вычислителя ФЛОУТЭК"
        /// </summary>
        public FloutecMeasureLineConfiguration()
        {
            Property(m => m.Number).IsRequired();
            Property(m => m.HourlyDataScanPeriod).IsRequired();
            Property(m => m.DateHourlyDataLastScanned).IsOptional().HasColumnType("datetime2");
            Property(m => m.SensorType).IsRequired();
            HasMany(m => m.HourlyData).WithRequired(m => m.MeasureLine);
            HasMany(m => m.IdentData).WithRequired(m => m.MeasureLine);
            HasMany(m => m.InstantData).WithRequired(m => m.MeasureLine);
            HasMany(m => m.AlarmData).WithRequired(m => m.MeasureLine);
            HasMany(m => m.InterData).WithRequired(m => m.MeasureLine);
            ToTable("FloutecMeasureLines");
        }
    }
}
