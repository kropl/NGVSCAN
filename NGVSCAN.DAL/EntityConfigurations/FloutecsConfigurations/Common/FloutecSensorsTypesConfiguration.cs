using NGVSCAN.CORE.Entities.Floutecs.Common;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace NGVSCAN.DAL.EntityConfigurations.FloutecsConfigurations.Common
{
    /// <summary>
    /// Конфигурация типов датчиков вычислителей ФЛОУТЭК
    /// </summary>
    public class FloutecSensorsTypesConfiguration : EntityTypeConfiguration<FloutecSensorsTypes>
    {
        /// <summary>
        /// Конфигурация типов датчиков вычислителей ФЛОУТЭК
        /// </summary>
        public FloutecSensorsTypesConfiguration()
        {
            HasKey(p => p.Code);
            Property(p => p.Code).IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(p => p.Name).IsRequired().HasMaxLength(25);
            ToTable("FloutecSensorsTypes");
        }
    }
}
