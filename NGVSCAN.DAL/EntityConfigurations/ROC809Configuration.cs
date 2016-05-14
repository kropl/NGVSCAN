﻿using NGVSCAN.CORE.Entities;
using NGVSCAN.DAL.EntityConfigurations.Common;

namespace NGVSCAN.DAL.EntityConfigurations
{
    public class ROC809Configuration : EntityConfiguration<ROC809>
    {
        public ROC809Configuration()
        {
            Property(r => r.Address).IsRequired().HasMaxLength(15);

            Property(r => r.Port).IsRequired();

            Property(r => r.ROCUnit).IsRequired();

            Property(r => r.ROCGroup).IsRequired();

            Property(r => r.HostUnit).IsRequired();

            Property(r => r.HostGroup).IsRequired();

            ToTable("ROC809s");
        }
    }
}
