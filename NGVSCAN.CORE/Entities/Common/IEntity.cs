using System;

namespace NGVSCAN.CORE.Entities.Common
{
    public interface IEntity
    {
        int Id { get; set; }

        DateTime DateCreated { get; set; }

        DateTime DateModified { get; set; }

        bool IsDeleted { get; set; }

        DateTime? DateDeleted { get; set; }
    }
}
