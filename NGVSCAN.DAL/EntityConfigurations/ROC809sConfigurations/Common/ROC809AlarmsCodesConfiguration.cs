using NGVSCAN.CORE.Entities.ROC809s.Common;
using NGVSCAN.DAL.EntityConfigurations.Common;

namespace NGVSCAN.DAL.EntityConfigurations.ROC809sConfigurations.Common
{
    /// <summary>
    /// Конфигурация дополинтельных кодов типов аварий вычислителей ROC809
    /// </summary>
    public class ROC809AlarmsCodesConfiguration : CatalogConfiguration<ROC809AlarmsCodes>
    {
        /// <summary>
        /// Конфигурация дополинтельных кодов типов аварий вычислителей ROC809
        /// </summary>
        public ROC809AlarmsCodesConfiguration()
        {
            ToTable("ROC809AlarmsCodes");
        }
    }
}
