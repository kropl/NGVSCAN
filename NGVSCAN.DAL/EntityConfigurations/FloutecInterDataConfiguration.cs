using NGVSCAN.CORE.Entities;
using NGVSCAN.DAL.EntityConfigurations.Common;

namespace NGVSCAN.DAL.EntityConfigurations
{
    public class FloutecInterDataConfiguration : EntityConfiguration<FloutecInterData>
    {
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
