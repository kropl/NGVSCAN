using NGVSCAN.CORE.Entities.ROC809s.Common;
using NGVSCAN.DAL.EntityConfigurations.Common;

namespace NGVSCAN.DAL.EntityConfigurations.ROC809sConfigurations.Common
{
    /// <summary>
    /// Конфигурация типов событий вычислителей ROC809
    /// </summary>
    public class ROC809EventsTypesConfiguration : CatalogConfiguration<ROC809EventsTypes>
    {
        /// <summary>
        /// Конфигурация типов событий вычислителей ROC809
        /// </summary>
        public ROC809EventsTypesConfiguration()
        {
            ToTable("ROC809EventsTypes");
        }
    }
}
