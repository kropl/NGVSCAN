using NGVSCAN.CORE.Entities;
using NGVSCAN.DAL.EntityConfigurations.Common;

namespace NGVSCAN.DAL.EntityConfigurations
{
    /// <summary>
    /// Конфигурация сущности "Часовые данные вычислителя ФЛОУТЭК"
    /// </summary>
    public class FloutecHourlyDataConfiguration : EntityConfiguration<FloutecHourlyData>
    {
        /// <summary>
        /// Конструктор по умолчанию конфигурации часовых данных
        /// </summary>
        public FloutecHourlyDataConfiguration()
        {
            // Свойство N_FLONIT часовых данных - обязательно (не допускает значений NULL)
            Property(h => h.N_FLONIT).IsRequired();

            // Свойство DAT часовых данных - обязательно (не допускает значений NULL)
            Property(h => h.DAT).IsRequired().HasColumnType("datetime2");

            // Свойство DAT_END часовых данных - обязательно (не допускает значений NULL)
            Property(h => h.DAT_END).IsRequired().HasColumnType("datetime2");

            // Свойство RASX часовых данных - обязательно (не допускает значений NULL)
            Property(h => h.RASX).IsRequired();

            // Свойство DAVL часовых данных - обязательно (не допускает значений NULL)
            Property(h => h.DAVL).IsRequired();

            // Свойство PD часовых данных - обязательно (не допускает значений NULL), 
            // максимальная длина строки - 1 символ
            Property(h => h.PD).IsRequired().HasMaxLength(1);

            // Свойство TEMP часовых данных - обязательно (не допускает значений NULL)
            Property(h => h.TEMP).IsRequired();

            // Свойство PT часовых данных - обязательно (не допускает значений NULL), 
            // максимальная длина строки - 1 символ
            Property(h => h.PT).IsRequired().HasMaxLength(1);

            // Свойство PEREP часовых данных - обязательно (не допускает значений NULL)
            Property(h => h.PEREP).IsRequired();

            // Свойство PP часовых данных - обязательно (не допускает значений NULL), 
            // максимальная длина строки - 1 символ
            Property(h => h.PP).IsRequired().HasMaxLength(1);

            // Свойство PLOTN часовых данных - обязательно (не допускает значений NULL)
            Property(h => h.PLOTN).IsRequired();

            // Свойство PL часовых данных - обязательно (не допускает значений NULL), 
            // максимальная длина строки - 1 символ
            Property(h => h.PL).IsRequired().HasMaxLength(1);

            // Задание названия таблицы
            ToTable("FloutecHourlyData");
        }
    }
}
