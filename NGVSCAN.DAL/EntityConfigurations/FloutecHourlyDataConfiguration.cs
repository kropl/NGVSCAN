using NGVSCAN.CORE.Entities;
using NGVSCAN.DAL.EntityConfigurations.Common;

namespace NGVSCAN.DAL.EntityConfigurations
{
    /// <summary>
    /// Конфигурация сущности "Часовые данные вычислителя ФЛОУТЭК"
    /// </summary>
    public class FloutecHourlyDataConfiguration : EntityConfiguration<FloutecHourlyData>
    {
        /// <summary>
        /// Конструктор по умолчанию конфигурации часовых данных
        /// </summary>
        public FloutecHourlyDataConfiguration()
        {
            // Свойство N_FLONIT часовых данных - обязательно (не допускает значений NULL)
            Property(h => h.N_FLONIT).IsRequired();
        }
    }
}
