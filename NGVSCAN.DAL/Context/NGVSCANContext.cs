using NGVSCAN.CORE.Entities;
using NGVSCAN.DAL.EntityConfigurations;
using System.Data.Entity;

namespace NGVSCAN.DAL.Context
{
    public class NGVSCANContext : DbContext
    {
        public NGVSCANContext() : base("NGVSCAN")
        {
        }

        #region Entities Sets

        public IDbSet<Field> Fields { get; set; }

        public IDbSet<Estimator> Estimators { get; set; }

        #endregion

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new FieldConfiguration());

            modelBuilder.Configurations.Add(new EstimatorConfiguration());

            modelBuilder.Configurations.Add(new FloutecConfiguration());

            modelBuilder.Configurations.Add(new ROC809Configuration());
        }
    }
}
