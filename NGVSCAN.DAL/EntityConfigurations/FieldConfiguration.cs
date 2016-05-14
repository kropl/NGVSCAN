using NGVSCAN.CORE.Entities;
using NGVSCAN.DAL.EntityConfigurations.Common;

namespace NGVSCAN.DAL.EntityConfigurations
{
    public class FieldConfiguration : EntityConfiguration<Field>
    {
        public FieldConfiguration()
        {
            Property(f => f.Name).IsRequired().HasMaxLength(25);

            Property(f => f.Description).IsRequired().HasMaxLength(200);

            HasMany(f => f.Estimators).WithRequired(e => e.Field);
        }
    }
}
