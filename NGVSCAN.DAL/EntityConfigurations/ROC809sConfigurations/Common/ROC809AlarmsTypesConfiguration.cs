using NGVSCAN.CORE.Entities.ROC809s.Common;
using NGVSCAN.DAL.EntityConfigurations.Common;

namespace NGVSCAN.DAL.EntityConfigurations.ROC809sConfigurations.Common
{
    /// <summary>
    /// Конфигурация типов аварий вычислителей ROC809
    /// </summary>
    public class ROC809AlarmsTypesConfiguration : CatalogConfiguration<ROC809AlarmsTypes>
    {
        /// <summary>
        /// Конфигурация типов аварий вычислителей ROC809
        /// </summary>
        public ROC809AlarmsTypesConfiguration()
        {
            ToTable("ROC809AlarmsTypes");
        }
    }
}
