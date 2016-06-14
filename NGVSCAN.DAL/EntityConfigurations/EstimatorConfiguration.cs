using NGVSCAN.CORE.Entities;
using NGVSCAN.DAL.EntityConfigurations.Common;

namespace NGVSCAN.DAL.EntityConfigurations
{
    /// <summary>
    /// Конфигурация сущности "Вычислитель"
    /// </summary>
    public class EstimatorConfiguration : EntityConfiguration<Estimator>
    {
        /// <summary>
        /// Конфигурация сущности "Вычислитель"
        /// </summary>
        public EstimatorConfiguration()
        {
            Property(e => e.Name).IsRequired().HasMaxLength(25);
            Property(e => e.Description).IsRequired().HasMaxLength(200);
            HasMany(e => e.MeasureLines).WithRequired(m => m.Estimator);
        }
    }
}
