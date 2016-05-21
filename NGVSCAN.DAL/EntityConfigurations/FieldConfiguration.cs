using NGVSCAN.CORE.Entities;
using NGVSCAN.DAL.EntityConfigurations.Common;

namespace NGVSCAN.DAL.EntityConfigurations
{
    /// <summary>
    /// Конфигурация сущности "Установка"
    /// </summary>
    public class FieldConfiguration : EntityConfiguration<Field>
    {
        /// <summary>
        /// Конструктор по умолчанию конфигурации установок
        /// </summary>
        public FieldConfiguration()
        {
            // Свойство Name установки - обязательно (не допускает значений NULL), 
            // максимальная длина строки - 25 символов
            Property(f => f.Name).IsRequired().HasMaxLength(25);

            // Свойство Description установки - обязательно (не допускает значений NULL), 
            // максимальная длина строки - 200 символов
            Property(f => f.Description).IsRequired().HasMaxLength(200);

            // Установка имеет отношение один-ко-многим с вычислителями
            HasMany(f => f.Estimators).WithRequired(e => e.Field);
        }
    }
}
