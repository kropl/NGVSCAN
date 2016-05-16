using NGVSCAN.CORE.Entities;
using NGVSCAN.DAL.EntityConfigurations.Common;

namespace NGVSCAN.DAL.EntityConfigurations
{
    /// <summary>
    /// Конфигурация сущности "Вычислитель ФЛОУТЭК"
    /// </summary>
    public class FloutecConfiguration : EntityConfiguration<Floutec>
    {
        /// <summary>
        /// Конструктор по умолчанию конфигурации вычислителей ФЛОУТЭК
        /// </summary>
        public FloutecConfiguration()
        {
            // Свойство Address выичслителя - обязательно (не допускает значений NULL)
            Property(f => f.Address).IsRequired();

            /*
                Кофигурация имени таблицы для вычислителей ФЛОУТЭК:
                таким образом задаётся полиморфное отношение между абстрактной сущностью "Вычислитель" 
                и её конкретной реализацией "Вычислитель ФЛОУТЭК" - ТРТ (Table per Type)
            */
            ToTable("Floutecs");
        }
    }
}
