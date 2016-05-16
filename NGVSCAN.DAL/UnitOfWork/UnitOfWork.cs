using NGVSCAN.CORE.Entities.Common;
using NGVSCAN.DAL.Context;
using NGVSCAN.DAL.Repositories;
using System;
using System.Collections.Generic;

namespace NGVSCAN.DAL.UnitOfWork
{
    /// <summary>
    /// Реализация паттерна UnitOfWork
    /// </summary>
    public class UnitOfWork : IDisposable
    {
        #region Конструктор и поля

        // Контекст доступа к данным СУБД MS SQL
        private readonly NGVSCANContext _context;

        // Словарь репозиториев доступа к данным СУБД MS SQL
        private Dictionary<string, object> _repositories;

        // Признак освобождения ресурсов
        private bool _disposed;

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public UnitOfWork()
        {
            // Инициализация контекста доступа к данным СУБД MS SQL
            _context = new NGVSCANContext();
        }

        #endregion

        /// <summary>
        /// Получение репозитория доступа к данным
        /// </summary>
        /// <typeparam name="Entity">Тип сущности</typeparam>
        /// <returns>Репозиторий доступа к данным для указанного типа сущности</returns>
        public SqlRepository<Entity> Repository<Entity>() where Entity : class, IEntity
        {
            // Инициализация словаря репозиториев
            if (_repositories == null)
                _repositories = new Dictionary<string, object>();

            // Определение названия типа (класса) сущности
            string type = typeof(Entity).Name;

            // Если в словаре репозиториев запрашиваемый репозиторий ещё отсутствует, то ...
            if (!_repositories.ContainsKey(type))
            {
                // Определение типа репозитория
                Type repositoryType = typeof(SqlRepository<>);

                // Создание репозитория для указанного типа сущности 
                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(Entity)), _context);

                // Добавление репозитория в словарь репозиториев
                _repositories.Add(type, repositoryInstance);
            }

            // Возвращение репозитория из словаря репозиториев
            return (SqlRepository<Entity>)_repositories[type];
        }

        /// <summary>
        /// Сохранение изменений в контексте доступа к данным
        /// </summary>
        public void Commit()
        {
            _context.SaveChanges();
        }

        #region Освобождение ресурсов
        
        /*
            Реализация интерфейса IDisposable для автоматического освобождения ресурсов
            контекста доступа к данным при использовании конструкции using
        */

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }

            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
