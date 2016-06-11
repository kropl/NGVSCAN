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

            // Свойство HourlyDataScanPeriod линии измерения - обязательно (не допускает значений NULL)
            Property(m => m.HourlyDataScanPeriod).IsRequired();

            // Свойство DateHourlyDataLastScanned сущности - не обязательно (допускает значения NULL), 
            // в базе данных имеет тип данных datetime2
            Property(m => m.DateHourlyDataLastScanned).IsOptional().HasColumnType("datetime2");

            // Свойство SensorType линии измерения - обязательно (не допускает значений NULL)
            Property(m => m.SensorType).IsRequired();

            // Линия измерения имеет отношение один-ко-многим с часовыми данными
            HasMany(m => m.HourlyData).WithRequired(m => m.MeasureLine);

            // Линия измерения имеет отношение один-ко-многим с данными идентификации
            HasMany(m => m.IdentData).WithRequired(m => m.MeasureLine);

            // Линия измерения имеет отношение один-ко-многим с мгновенными данными
            HasMany(m => m.InstantData).WithRequired(m => m.MeasureLine);

            // Линия измерения имеет отношение один-ко-многим с данными аварий
            HasMany(m => m.AlarmData).WithRequired(m => m.MeasureLine);

            /*
                Кофигурация имени таблицы для линий измерения вычислителей ФЛОУТЭК:
                таким образом задаётся полиморфное отношение между абстрактной сущностью "Линия измерения" 
                и её конкретной реализацией "Линия измерения вычислителей ФЛОУТЭК" - ТРТ (Table per Type)
            */
            ToTable("FloutecMeasureLines");
        }
    }
}
