using NGVSCAN.CORE.Entities.Floutecs.Common;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace NGVSCAN.DAL.EntityConfigurations.FloutecsConfigurations.Common
{
    /// <summary>
    /// Конфигурация типов аварий вычислителей ФЛОУТЭК
    /// </summary>
    public class FloutecAlarmsTypesConfiguration : EntityTypeConfiguration<FloutecAlarmsTypes>
    {
        /// <summary>
        /// Конфигурация типов аварий вычислителей ФЛОУТЭК
        /// </summary>
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
