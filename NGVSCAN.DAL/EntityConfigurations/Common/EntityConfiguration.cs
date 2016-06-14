using NGVSCAN.CORE.Entities.Common;
using System.Data.Entity.ModelConfiguration;

namespace NGVSCAN.DAL.EntityConfigurations.Common
{
    /// <summary>
    /// Конфигурация, общая для всех сущностей
    /// </summary>
    /// <typeparam name="T">Тип сущности</typeparam>
    public class EntityConfiguration<T> : EntityTypeConfiguration<T> where T : class, IEntity
    {
        /// <summary>
        /// Конфигурация, общая для всех сущностей
        /// </summary>
        public EntityConfiguration()
        {
            HasKey(e => e.Id);
            Property(e => e.DateCreated).IsRequired().HasColumnType("datetime2");
            Property(e => e.DateModified).IsRequired().HasColumnType("datetime2");
            Property(e => e.DateDeleted).IsOptional().HasColumnType("datetime2");
        }
    }
}
