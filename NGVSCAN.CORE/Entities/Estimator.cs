using NGVSCAN.CORE.Entities.Common;
using System;

namespace NGVSCAN.CORE.Entities
{
    public abstract class Estimator : IEntity
    {
        #region Common Properties

        public int Id { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DateDeleted { get; set; }

        #endregion

        #region Properties

        public string Name { get; set; }

        public string Description { get; set; }

        #endregion

        #region Navigation Properties

        public int FieldId { get; set; }

        public virtual Field Field { get; set; }

        #endregion
    }
}
