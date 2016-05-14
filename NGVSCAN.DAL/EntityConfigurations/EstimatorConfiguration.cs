using NGVSCAN.CORE.Entities;
using NGVSCAN.DAL.EntityConfigurations.Common;

namespace NGVSCAN.DAL.EntityConfigurations
{
    public class EstimatorConfiguration : EntityConfiguration<Estimator>
    {
        public EstimatorConfiguration()
        {
            Property(e => e.Name).IsRequired().HasMaxLength(25);

            Property(e => e.Description).IsRequired().HasMaxLength(200);
        }
    }
}
