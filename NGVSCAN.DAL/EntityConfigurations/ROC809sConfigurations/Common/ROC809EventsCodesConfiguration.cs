using NGVSCAN.CORE.Entities.ROC809s.Common;
using NGVSCAN.DAL.EntityConfigurations.Common;

namespace NGVSCAN.DAL.EntityConfigurations.ROC809sConfigurations.Common
{
    /// <summary>
    /// Конфигурация дополинтельных кодов типов событий вычислителей ROC809
    /// </summary>
    public class ROC809EventsCodesConfiguration : CatalogConfiguration<ROC809EventsCodes>
    {
        /// <summary>
        /// Конфигурация дополинтельных кодов типов событий вычислителей ROC809
        /// </summary>
        public ROC809EventsCodesConfiguration()
        {
            ToTable("ROC809EventsCodes");
        }
    }
}
