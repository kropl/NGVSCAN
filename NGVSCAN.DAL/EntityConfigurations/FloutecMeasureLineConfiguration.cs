using NGVSCAN.CORE.Entities;
using NGVSCAN.DAL.EntityConfigurations.Common;

namespace NGVSCAN.DAL.EntityConfigurations
{
    /// <summary>
    /// Конфигурация сущности "Линия измерения вычислителя ФЛОУТЭК"
    /// </summary>
    public class FloutecMeasureLineConfiguration : EntityConfiguration<FloutecMeasureLine>
    {
        /// <summary>
        /// Конструктор по умолчанию конфигурации линии измерения
        /// </summary>
        public FloutecMeasureLineConfiguration()
        {
            // Свойство Number линии измерения - обязательно (не допускает значений NULL)
            Property(m => m.Number).IsRequired();

            // Линия измерения имеет отношение один-ко-многим с часовыми данными
            HasMany(m => m.HourlyData).WithRequired(m => m.MeasureLine);

            /*
                Кофигурация имени таблицы для линий измерения вычислителей ФЛОУТЭК:
                таким образом задаётся полиморфное отношение между абстрактной сущностью "Линия измерения" 
                и её конкретной реализацией "Линия измерения вычислителей ФЛОУТЭК" - ТРТ (Table per Type)
            */
            ToTable("FloutecMeasureLines");
        }
    }
}
