using NGVSCAN.CORE.Entities;
using NGVSCAN.DAL.EntityConfigurations.Common;

namespace NGVSCAN.DAL.EntityConfigurations
{
    public class FloutecConfiguration : EntityConfiguration<Floutec>
    {
        public FloutecConfiguration()
        {
            Property(f => f.Address).IsRequired();

            ToTable("Floutecs");
        }
    }
}
