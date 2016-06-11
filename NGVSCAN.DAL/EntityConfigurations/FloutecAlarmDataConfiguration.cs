using NGVSCAN.CORE.Entities;
using NGVSCAN.DAL.EntityConfigurations.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NGVSCAN.DAL.EntityConfigurations
{
    public class FloutecAlarmDataConfiguration : EntityConfiguration<FloutecAlarmData>
    {
        public FloutecAlarmDataConfiguration()
        {
            Property(a => a.N_FLONIT).IsRequired();
            Property(a => a.DAT).IsRequired().HasColumnType("datetime2");
            Property(a => a.T_AVAR).IsRequired();
            Property(a => a.T_PARAM).IsRequired();
            ToTable("FloutecAlarmData");
        }
    }
}
