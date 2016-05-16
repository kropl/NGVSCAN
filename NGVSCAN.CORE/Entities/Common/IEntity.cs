using System;

namespace NGVSCAN.CORE.Entities.Common
{
    /// <summary>
    /// Интерфейс общего содержания сущностей
    /// </summary>
    public interface IEntity
    {
        /// <summary>
        /// Идентификатор (первичный ключ) сущности
        /// </summary>
        int Id { get; set; }

        /// <summary>
        /// Дата и время создания (добавления) сущности
        /// </summary>
        DateTime DateCreated { get; set; }

        /// <summary>
        /// Дата и время изменения (модификации) сущности
        /// </summary>
        DateTime DateModified { get; set; }

        /// <summary>
        /// Признак удаления сущности
        /// </summary>
        bool IsDeleted { get; set; }

        /// <summary>
        /// Дата и время удаления сущности
        /// </summary>
        DateTime? DateDeleted { get; set; }
    }
}
