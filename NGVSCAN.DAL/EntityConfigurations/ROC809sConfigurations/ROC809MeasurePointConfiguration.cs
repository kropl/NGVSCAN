using NGVSCAN.CORE.Entities;
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
            Property(p => p.Type).IsRequired();
            Property(p => p.LogicalNumber).IsRequired();
            Property(p => p.ParameterNumber).IsRequired();
            Property(p => p.HistSegment).IsRequired();
            ToTable("ROC809MeasurePoints");
        }
    }
}
