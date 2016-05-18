using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration.Configuration;

namespace NGVSCAN.DAL.EntityConfigurations.Common
{
    /// <summary>
    /// Методы расширения конфигурации сущностей
    /// </summary>
    internal static class EntityConfigurationExtensions
    {
        /// <summary>
        /// Определение уникальности свойства сущности
        /// </summary>
        /// <param name="property">Свойство сущности</param>
        /// <param name="indexName">Название индекса</param>
        /// <param name="columnOrder">Порядок</param>
        /// <returns>Свойство сущности</returns>
        public static PrimitivePropertyConfiguration HasUniqueIndex(this PrimitivePropertyConfiguration property, string indexName, int columnOrder)
        {
            var indexAttribute = new IndexAttribute(indexName, columnOrder) { IsUnique = true };
            var indexAnnotation = new IndexAnnotation(indexAttribute);

            return property.HasColumnAnnotation(IndexAnnotation.AnnotationName, indexAnnotation);
        }
    }
}
