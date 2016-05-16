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
            // Свойство Name вычислителя - обязательно (не допускает значений NULL), 
            // максимальная длина строки - 25 символов
            Property(e => e.Name).IsRequired().HasMaxLength(25);

            // Свойство Description вычислителя - обязательно (не допускает значений NULL), 
            // максимальная длина строки - 200 символов
            Property(e => e.Description).IsRequired().HasMaxLength(200);

            // Вычислитель имеет отношение один-ко-многим с линиями измерения
            HasMany(e => e.MeasureLines).WithRequired(m => m.Estimator);
        }
    }
}
