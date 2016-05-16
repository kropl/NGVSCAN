using NGVSCAN.CORE.Entities;
using NGVSCAN.DAL.EntityConfigurations.Common;

namespace NGVSCAN.DAL.EntityConfigurations
{
    /// <summary>
    /// Конфигурация сущности "Точка измерения вычислителя ROC809"
    /// </summary>
    public class ROC809MeasurePointConfiguration : EntityConfiguration<ROC809MeasurePoint>
    {
        /// <summary>
        /// Конструктор по умолчанию конфигурации точки измерения
        /// </summary>
        public ROC809MeasurePointConfiguration()
        {
            // Свойство Number точки измерения - обязательно (не допускает значений NULL)
            Property(p => p.Number).IsRequired();

            // Свойство Type точки измерения - обязательно (не допускает значений NULL)
            Property(p => p.Type).IsRequired();

            // Свойство LogicalNumber точки измерения - обязательно (не допускает значений NULL)
            Property(p => p.LogicalNumber).IsRequired();

            // Свойство ParameterNumber точки измерения - обязательно (не допускает значений NULL)
            Property(p => p.ParameterNumber).IsRequired();

            // Свойство HistSegment точки измерения - обязательно (не допускает значений NULL)
            Property(p => p.HistSegment).IsRequired();

            /*
                Кофигурация имени таблицы для точек измерения вычислителей ROC809:
                таким образом задаётся полиморфное отношение между абстрактной сущностью "Линия измерения" 
                и её конкретной реализацией "Точка измерения вычислителей ROC809" - ТРТ (Table per Type)
            */
            ToTable("ROC809MeasurePoints");
        }
    }
}
