using NGVSCAN.CORE.Entities.Floutecs.Common;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace NGVSCAN.DAL.EntityConfigurations.FloutecsConfigurations.Common
{
    /// <summary>
    /// Конфигурация типов параметров вычислителей ФЛОУТЭК
    /// </summary>
    public class FloutecParamsTypesConfiguration : EntityTypeConfiguration<FloutecParamsTypes>
    {
        /// <summary>
        /// Конфигурация типов параметров вычислителей ФЛОУТЭК
        /// </summary>
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
