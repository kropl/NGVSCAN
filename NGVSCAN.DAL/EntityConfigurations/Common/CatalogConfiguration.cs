using NGVSCAN.CORE.Entities.Common;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace NGVSCAN.DAL.EntityConfigurations.Common
{
    /// <summary>
    /// Конфигурация, общая для всех справочных таблиц
    /// </summary>
    /// <typeparam name="T">Тип справочной таблицы</typeparam>
    public class CatalogConfiguration<T> : EntityTypeConfiguration<T> where T : class, ICatalog
    {
        /// <summary>
        /// Конфигурация, общая для всех справочных таблиц
        /// </summary>
        public CatalogConfiguration()
        {
            HasKey(с => с.Code);
            Property(с => с.Code).IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(с => с.Description).IsRequired().HasMaxLength(400);
        }
    }
}
