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

            // Комбинация свойств FieldId, Address и Name вычислителя должна быть уникальной
            Property(f => f.FieldId).HasUniqueIndex("IX_Floutec", 0);
            Property(f => f.Address).HasUniqueIndex("IX_Floutec", 1);
            Property(f => f.Name).HasUniqueIndex("IX_Floutec", 2);

            /*
                Кофигурация имени таблицы для вычислителей ФЛОУТЭК:
                таким образом задаётся полиморфное отношение между абстрактной сущностью "Вычислитель" 
                и её конкретной реализацией "Вычислитель ФЛОУТЭК" - ТРТ (Table per Type)
            */
            ToTable("Floutecs");
        }
    }
}
