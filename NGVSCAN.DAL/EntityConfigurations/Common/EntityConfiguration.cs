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
        /// Конструктор по умолчанию общей для всех сущностей конфигурации
        /// </summary>
        public EntityConfiguration()
        {
            // Id сущности - первичный ключ
            HasKey(e => e.Id);

            // Свойство DateCreated сущности - обязательно (не допускает значений NULL), 
            // в базе данных имеет тип данных datetime2
            Property(e => e.DateCreated).IsRequired().HasColumnType("datetime2");

            // Свойство DateModified сущности - обязательно (не допускает значений NULL), 
            // в базе данных имеет тип данных datetime2
            Property(e => e.DateModified).IsRequired().HasColumnType("datetime2");

            // Свойство DateDeleted сущности - необязательно (допускает значение NULL), 
            // в базе данных имеет тип данных datetime2
            Property(e => e.DateDeleted).IsOptional().HasColumnType("datetime2");
        }
    }
}
