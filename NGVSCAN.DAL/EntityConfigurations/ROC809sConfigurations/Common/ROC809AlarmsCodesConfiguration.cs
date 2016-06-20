using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using NGVSCAN.CORE.Entities.ROC809s.Common;

namespace NGVSCAN.DAL.EntityConfigurations.ROC809sConfigurations.Common
{
    /// <summary>
    /// Конфигурация дополинтельных кодов типов аварий вычислителей ROC809
    /// </summary>
    public class ROC809AlarmsCodesConfiguration : EntityTypeConfiguration<ROC809AlarmsCodes>
    {
        /// <summary>
        /// Конфигурация дополинтельных кодов типов аварий вычислителей ROC809
        /// </summary>
        public ROC809AlarmsCodesConfiguration()
        {
            HasKey(p => p.Code);
            Property(p => p.Code).IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(p => p.Description).IsRequired().HasMaxLength(400);
            ToTable("ROC809AlarmsCodes");
        }
    }
}
