using NGVSCAN.CORE.Entities.Common;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace NGVSCAN.DAL.EntityConfigurations.Common
{
    public class FloutecAlarmsTypesConfiguration : EntityTypeConfiguration<FloutecAlarmsTypes>
    {
        public FloutecAlarmsTypesConfiguration()
        {
            HasKey(p => p.Code);
            Property(p => p.Code).IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(p => p.Description).IsRequired().HasMaxLength(400);
            Property(p => p.Description_45).IsRequired().HasMaxLength(400);
            ToTable("FloutecAlarmsTypes");
        }
    }
}
