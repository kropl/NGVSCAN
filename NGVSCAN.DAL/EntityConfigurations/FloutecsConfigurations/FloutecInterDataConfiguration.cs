using NGVSCAN.CORE.Entities.Floutecs;
using NGVSCAN.DAL.EntityConfigurations.Common;

namespace NGVSCAN.DAL.EntityConfigurations.FloutecsConfigurations
{
    /// <summary>
    /// Конфигурация сущности "Данные вмешательств вычислителя ФЛОУТЭК"
    /// </summary>
    public class FloutecInterDataConfiguration : EntityConfiguration<FloutecInterData>
    {
        /// <summary>
        /// Конфигурация сущности "Данные вмешательств вычислителя ФЛОУТЭК"
        /// </summary>
        public FloutecInterDataConfiguration()
        {
            Property(i => i.N_FLONIT).IsRequired();
            Property(i => i.DAT).IsRequired().HasColumnType("datetime2");
            Property(i => i.CH_PAR).IsRequired();
            Property(i => i.T_PARAM).IsOptional();
            Property(i => i.VAL_OLD).IsRequired();
            Property(i => i.VAL_NEW).IsRequired();
            ToTable("FloutecInterData");
        }
    }
}
