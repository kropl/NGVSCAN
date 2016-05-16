using NGVSCAN.CORE.Entities;
using NGVSCAN.DAL.EntityConfigurations.Common;

namespace NGVSCAN.DAL.EntityConfigurations
{
    /// <summary>
    /// Конфигурация сущности "Вычислитель"
    /// </summary>
    public class EstimatorConfiguration : EntityConfiguration<Estimator>
    {
        /// <summary>
        /// Конструктор по умолчанию конфигурации вычислителей
        /// </summary>
        public EstimatorConfiguration()
        {
            // Свойство Name выичслителя - обязательно (не допускает значений NULL), 
            // максимальная длина строки - 25 символов
            Property(e => e.Name).IsRequired().HasMaxLength(25);

            // Свойство Description выичслителя - обязательно (не допускает значений NULL), 
            // максимальная длина строки - 200 символов
            Property(e => e.Description).IsRequired().HasMaxLength(200);
        }
    }
}
