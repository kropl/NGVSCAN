using NGVSCAN.CORE.Entities;
using NGVSCAN.DAL.EntityConfigurations.Common;

namespace NGVSCAN.DAL.EntityConfigurations
{
    /// <summary>
    /// Конфигурация сущности "Вычислитель ROC809"
    /// </summary>
    public class ROC809Configuration : EntityConfiguration<ROC809>
    {
        /// <summary>
        /// Конструктор по умолчанию конфигурации вычислителей ROC809
        /// </summary>
        public ROC809Configuration()
        {
            // Свойство Address выичслителя ROC809 - обязательно (не допускает значений NULL), 
            // максимальная длина строки - 15 символов
            Property(r => r.Address).IsRequired().HasMaxLength(15);

            // Свойство Port выичслителя ROC809 - обязательно (не допускает значений NULL)
            Property(r => r.Port).IsRequired();

            // Свойство ROCUnit выичслителя ROC809 - обязательно (не допускает значений NULL)
            Property(r => r.ROCUnit).IsRequired();

            // Свойство ROCGroup выичслителя ROC809 - обязательно (не допускает значений NULL)
            Property(r => r.ROCGroup).IsRequired();

            // Свойство HostUnit выичслителя ROC809 - обязательно (не допускает значений NULL)
            Property(r => r.HostUnit).IsRequired();

            // Свойство HostGroup выичслителя ROC809 - обязательно (не допускает значений NULL)
            Property(r => r.HostGroup).IsRequired();

            /*
                Кофигурация имени таблицы для вычислителей ROC809:
                таким образом задаётся полиморфное отношение между абстрактной сущностью "Вычислитель" 
                и её конкретной реализацией "Вычислитель ROC809" - ТРТ (Table per Type)
            */
            ToTable("ROC809s");
        }
    }
}
