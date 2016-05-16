using NGVSCAN.CORE.Entities;
using NGVSCAN.DAL.EntityConfigurations.Common;

namespace NGVSCAN.DAL.EntityConfigurations
{
    /// <summary>
    /// Конфигурация сущности "Линия измерения"
    /// </summary>
    public class MeasureLineConfiguration : EntityConfiguration<MeasureLine>
    {
        /// <summary>
        /// Конструктор по умолчанию конфигурации линии измерения
        /// </summary>
        public MeasureLineConfiguration()
        {
            // Свойство Name линии измерения - обязательно (не допускает значений NULL), 
            // максимальная длина строки - 25 символов
            Property(m => m.Name).IsRequired().HasMaxLength(25);

            // Свойство Description измерения - обязательно (не допускает значений NULL), 
            // максимальная длина строки - 200 символов
            Property(m => m.Description).IsRequired().HasMaxLength(200);
        }
    }
}
