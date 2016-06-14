using NGVSCAN.CORE.Entities;
using NGVSCAN.DAL.EntityConfigurations.Common;

namespace NGVSCAN.DAL.EntityConfigurations
{
    /// <summary>
    /// Конфигурация сущности "Линия измерения"
    /// </summary>
    public class MeasureLineConfiguration : EntityConfiguration<MeasureLine>
    {
        /// <summary>
        /// Конфигурация сущности "Линия измерения"
        /// </summary>
        public MeasureLineConfiguration()
        {
            Property(m => m.Name).IsRequired().HasMaxLength(25);
            Property(m => m.Description).IsRequired().HasMaxLength(200);
        }
    }
}
