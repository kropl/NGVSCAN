using NGVSCAN.CORE.Entities.Common;
using System;
using System.Collections.Generic;

namespace NGVSCAN.CORE.Entities
{
    public class Field : IEntity
    {
        #region Constructor & Fields

        public Field()
        {
            Estimators = new HashSet<Estimator>();
        }

        #endregion

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

        public virtual ICollection<Estimator> Estimators { get; set; }

        #endregion
    }
}
