using NGVSCAN.CORE.Entities;
using NGVSCAN.DAL.EntityConfigurations.Common;

namespace NGVSCAN.DAL.EntityConfigurations
{
    public class FloutecIdentDataConfiguration : EntityConfiguration<FloutecIdentData>
    {
        public FloutecIdentDataConfiguration()
        {
            // Свойство N_FLONIT данных идентификации - обязательно (не допускает значений NULL)
            Property(i => i.N_FLONIT).IsRequired();

            // Свойство KONTRH данных идентификации - обязательно (не допускает значений NULL)
            Property(i => i.KONTRH).IsRequired();

            // Свойство NO2 данных идентификации - обязательно (не допускает значений NULL)
            Property(i => i.NO2).IsRequired();

            // Свойство OTBOR данных идентификации - обязательно (не допускает значений NULL)
            Property(i => i.OTBOR).IsRequired();

            // Свойство ACP данных идентификации - обязательно (не допускает значений NULL)
            Property(i => i.ACP).IsRequired();

            // Свойство ACS данных идентификации - обязательно (не допускает значений NULL)
            Property(i => i.ACS).IsRequired();

            // Свойство SHER данных идентификации - обязательно (не допускает значений NULL)
            Property(i => i.SHER).IsRequired();

            // Свойство VERXP данных идентификации - обязательно (не допускает значений NULL)
            Property(i => i.VERXP).IsRequired();

            // Свойство PLOTN данных идентификации - обязательно (не допускает значений NULL)
            Property(i => i.PLOTN).IsRequired();

            // Свойство DTRUB данных идентификации - обязательно (не допускает значений NULL)
            Property(i => i.DTRUB).IsRequired();

            // Свойство OTSECH данных идентификации - обязательно (не допускает значений NULL)
            Property(i => i.OTSECH).IsRequired();

            // Свойство BCP данных идентификации - обязательно (не допускает значений NULL)
            Property(i => i.BCP).IsRequired();

            // Свойство BCS данных идентификации - обязательно (не допускает значений NULL)
            Property(i => i.BCS).IsRequired();

            // Свойство VERXDP данных идентификации - обязательно (не допускает значений NULL)
            Property(i => i.VERXDP).IsRequired();

            // Свойство NIZT данных идентификации - обязательно (не допускает значений NULL)
            Property(i => i.NIZT).IsRequired();

            // Свойство CO2 данных идентификации - обязательно (не допускает значений NULL)
            Property(i => i.CO2).IsRequired();

            // Свойство DSU данных идентификации - обязательно (не допускает значений NULL)
            Property(i => i.DSU).IsRequired();

            // Свойство CCP данных идентификации - обязательно (не допускает значений NULL)
            Property(i => i.CCP).IsRequired();

            // Свойство CCS данных идентификации - обязательно (не допускает значений NULL)
            Property(i => i.CCS).IsRequired();

            // Свойство NIZP данных идентификации - обязательно (не допускает значений NULL)
            Property(i => i.NIZP).IsRequired();

            // Свойство VERXT данных идентификации - обязательно (не допускает значений NULL)
            Property(i => i.VERXT).IsRequired();

            // Свойство KONDENS данных идентификации - обязательно (не допускает значений NULL)
            Property(i => i.KONDENS).IsRequired();

            // Свойство KALIBSCH данных идентификации - обязательно (не допускает значений NULL)
            Property(i => i.KALIBSCH).IsRequired();

            // Свойство MINRSCH данных идентификации - обязательно (не допускает значений NULL)
            Property(i => i.MINRSCH).IsRequired();

            // Свойство MAXRSCH данных идентификации - обязательно (не допускает значений NULL)
            Property(i => i.MAXRSCH).IsRequired();

            // Задание названия таблицы
            ToTable("FloutecIdentData");
        }
    }
}
