using NGVSCAN.CORE.Entities.Floutecs;
using NGVSCAN.DAL.EntityConfigurations.Common;

namespace NGVSCAN.DAL.EntityConfigurations.FloutecsConfigurations
{
    /// <summary>
    /// Конфигурация сущности "Данные идентификации вычислителя ФЛОУТЭК"
    /// </summary>
    public class FloutecIdentDataConfiguration : EntityConfiguration<FloutecIdentData>
    {
        /// <summary>
        /// Конфигурация сущности "Данные идентификации вычислителя ФЛОУТЭК"
        /// </summary>
        public FloutecIdentDataConfiguration()
        {
            Property(i => i.N_FLONIT).IsRequired();
            Property(i => i.KONTRH).IsRequired();
            Property(i => i.NO2).IsRequired();
            Property(i => i.OTBOR).IsRequired();
            Property(i => i.ACP).IsRequired();
            Property(i => i.ACS).IsRequired();
            Property(i => i.SHER).IsRequired();
            Property(i => i.VERXP).IsRequired();
            Property(i => i.PLOTN).IsRequired();
            Property(i => i.DTRUB).IsRequired();
            Property(i => i.OTSECH).IsRequired();
            Property(i => i.BCP).IsRequired();
            Property(i => i.BCS).IsRequired();
            Property(i => i.VERXDP).IsRequired();
            Property(i => i.NIZT).IsRequired();
            Property(i => i.CO2).IsRequired();
            Property(i => i.DSU).IsRequired();
            Property(i => i.CCP).IsRequired();
            Property(i => i.CCS).IsRequired();
            Property(i => i.NIZP).IsRequired();
            Property(i => i.VERXT).IsRequired();
            Property(i => i.KONDENS).IsRequired();
            Property(i => i.KALIBSCH).IsRequired();
            Property(i => i.MINRSCH).IsRequired();
            Property(i => i.MAXRSCH).IsRequired();
            Property(i => i.TYPDAN).IsRequired();
            ToTable("FloutecIdentData");
        }
    }
}
