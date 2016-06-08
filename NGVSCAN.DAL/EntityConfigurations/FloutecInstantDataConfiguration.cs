using NGVSCAN.CORE.Entities;
using NGVSCAN.DAL.EntityConfigurations.Common;

namespace NGVSCAN.DAL.EntityConfigurations
{
    /// <summary>
    /// Конфигурация сущности "Мгновенные данные вычислителя ФЛОУТЭК"
    /// </summary>
    public class FloutecInstantDataConfiguration : EntityConfiguration<FloutecInstantData>
    {
        /// <summary>
        /// Конструктор по умолчанию конфигурации мгновенных данных
        /// </summary>
        public FloutecInstantDataConfiguration()
        {
            // Свойство N_FLONIT мгновенных данных - обязательно (не допускает значений NULL)
            Property(i => i.N_FLONIT).IsRequired();

            // Свойство DAT мгновенных данных - обязательно (не допускает значений NULL)
            Property(i => i.DAT).IsRequired().HasColumnType("datetime2");

            // Свойство ABSP мгновенных данных - обязательно (не допускает значений NULL)
            Property(i => i.ABSP).IsRequired();

            // Свойство ALARMRY мгновенных данных - обязательно (не допускает значений NULL)
            Property(i => i.ALARMRY).IsRequired();

            // Свойство ALARMSY мгновенных данных - обязательно (не допускает значений NULL)
            Property(i => i.ALARMSY).IsRequired();

            // Свойство ALLSPEND мгновенных данных - обязательно (не допускает значений NULL)
            Property(i => i.ALLSPEND).IsRequired();

            // Свойство CURRSPEND мгновенных данных - обязательно (не допускает значений NULL)
            Property(i => i.CURRSPEND).IsRequired();

            // Свойство DAYSPEND мгновенных данных - обязательно (не допускает значений NULL)
            Property(i => i.DAYSPEND).IsRequired();

            // Свойство DLITAS мгновенных данных - обязательно (не допускает значений NULL)
            Property(i => i.DLITAS).IsRequired();

            // Свойство DLITBAS мгновенных данных - обязательно (не допускает значений NULL)
            Property(i => i.DLITBAS).IsRequired();

            // Свойство DLITMAS мгновенных данных - обязательно (не допускает значений NULL)
            Property(i => i.DLITMAS).IsRequired();

            // Свойство GASVIZ мгновенных данных - обязательно (не допускает значений NULL)
            Property(i => i.GASVIZ).IsRequired();

            // Свойство GAZPLOTNNU мгновенных данных - обязательно (не допускает значений NULL)
            Property(i => i.GAZPLOTNNU).IsRequired();

            // Свойство GAZPLOTNRU мгновенных данных - обязательно (не допускает значений NULL)
            Property(i => i.GAZPLOTNRU).IsRequired();

            // Свойство LASTMONTHSPEND мгновенных данных - обязательно (не допускает значений NULL)
            Property(i => i.LASTMONTHSPEND).IsRequired();

            // Свойство LASTMONTHSPEND мгновенных данных - обязательно (не допускает значений NULL)
            Property(i => i.MONTHSPEND).IsRequired();

            // Свойство PALARMRY мгновенных данных - обязательно (не допускает значений NULL)
            Property(i => i.PALARMRY).IsRequired();

            // Свойство PALARMSY мгновенных данных - обязательно (не допускает значений NULL)
            Property(i => i.PALARMSY).IsRequired();

            // Свойство PD мгновенных данных - обязательно (не допускает значений NULL), 
            // максимальная длина строки - 1 символ
            Property(i => i.PD).IsRequired().HasMaxLength(1);

            // Свойство PDLITAS мгновенных данных - обязательно (не допускает значений NULL)
            Property(i => i.PDLITAS).IsRequired();

            // Свойство PDLITBAS мгновенных данных - обязательно (не допускает значений NULL)
            Property(i => i.PDLITBAS).IsRequired();

            // Свойство PDLITMAS мгновенных данных - обязательно (не допускает значений NULL)
            Property(i => i.PDLITMAS).IsRequired();

            // Свойство PERPRES мгновенных данных - обязательно (не допускает значений NULL)
            Property(i => i.PERPRES).IsRequired();

            // Свойство PP мгновенных данных - обязательно (не допускает значений NULL), 
            // максимальная длина строки - 1 символ
            Property(i => i.PP).IsRequired().HasMaxLength(1);

            // Свойство PQHOUR мгновенных данных - обязательно (не допускает значений NULL)
            Property(i => i.PQHOUR).IsRequired();

            // Свойство PT мгновенных данных - обязательно (не допускает значений NULL), 
            // максимальная длина строки - 1 символ
            Property(i => i.PT).IsRequired().HasMaxLength(1);

            // Свойство QHOUR мгновенных данных - обязательно (не допускает значений NULL)
            Property(i => i.QHOUR).IsRequired();

            // Свойство SQROOT мгновенных данных - обязательно (не допускает значений NULL)
            Property(i => i.SQROOT).IsRequired();

            // Свойство STPRES мгновенных данных - обязательно (не допускает значений NULL)
            Property(i => i.STPRES).IsRequired();

            // Свойство TEMP мгновенных данных - обязательно (не допускает значений NULL)
            Property(i => i.TEMP).IsRequired();

            // Свойство YESTSPEND мгновенных данных - обязательно (не допускает значений NULL)
            Property(i => i.YESTSPEND).IsRequired();

            // Задание названия таблицы
            ToTable("FloutecInstantData");
        }
    }
}
