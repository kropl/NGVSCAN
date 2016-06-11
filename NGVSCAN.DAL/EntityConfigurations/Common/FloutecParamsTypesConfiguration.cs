using NGVSCAN.CORE.Entities.Common;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace NGVSCAN.DAL.EntityConfigurations.Common
{
    public class FloutecParamsTypesConfiguration : EntityTypeConfiguration<FloutecParamsTypes>
    {
        public FloutecParamsTypesConfiguration()
        {
            HasKey(p => p.Code);
            Property(p => p.Code).IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(p => p.Param).IsRequired().HasMaxLength(25);
            Property(p => p.Description).IsRequired().HasMaxLength(100);
            ToTable("FloutecParamsTypes");
        }
    }
}
