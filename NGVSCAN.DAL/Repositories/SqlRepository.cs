using NGVSCAN.CORE.Entities.Common;
using NGVSCAN.DAL.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace NGVSCAN.DAL.Repositories
{
    /// <summary>
    /// Обобщённый репозиторий для доступа к данным СУБД MS SQL
    /// </summary>
    /// <typeparam name="Entity">Тип сущности</typeparam>
    public class SqlRepository<Entity> : IDisposable where Entity : class, IEntity
    {
        #region Конструктор и поля

        // Контекст доступа к данным
        private readonly NGVSCANContext _context;

        // Признак освобождения ресурсов
        private bool _disposed;

        /// <summary>
        /// Конструктор репозитория доступа к данным СУБД MS SQL
        /// </summary>
        /// <param name="context"><see cref="DbContext"/>Контекст доступа к данным</param>
        public SqlRepository()
        {
            // Инициализация контекста доступа к данным
            _context = new NGVSCANContext();
        }

        public SqlRepository(NGVSCANContext context)
        {
            // Инициализация контекста доступа к данным
            _context = context;
        }

        #endregion

        #region Операции Get (получения) 

        /// <summary>
        /// Получение всех сущностей типа <see cref="Entity"/>
        /// </summary>
        /// <returns>Коллеция сущностей типа <see cref="Entity"/></returns>
        public IQueryable<Entity> GetAll()
        {
            try
            {
                return _context.Set<Entity>();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Получение сущности типа <see cref="Entity"/> по идентификатору (первичному ключу)
        /// </summary>
        /// <param name="id">Первичный ключ сущности</param>
        /// <returns>Сущность типа <see cref="Entity"/></returns>
        public Entity Get(int id)
        {
            try
            {
                return _context.Set<Entity>().Where(e => e.Id == id).SingleOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region Операции Insert (добавления)

        /// <summary>
        /// Добавление коллекции сущностей типа <see cref="Entity"/>
        /// </summary>
        /// <param name="entities">Коллекция сущностей типа <see cref="Entity"/></param>
        public void Insert(IEnumerable<Entity> entities)
        {
            try
            {
                _context.Set<Entity>().AddRange(entities);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Добавление сущности типа <see cref="Entity"/>
        /// </summary>
        /// <param name="entity">Сущность типа <see cref="Entity"/></param>
        public void Insert(Entity entity)
        {
            try
            {
                _context.Set<Entity>().Add(entity);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region Операции Update (изменения)

        /// <summary>
        /// Обновление коллеции сущностей типа <see cref="Entity"/>
        /// </summary>
        /// <param name="entities">Коллекция сущностей типа <see cref="Entity"/></param>
        public void Update(IEnumerable<Entity> entities)
        {
            try
            {
                foreach (Entity entity in entities)
                {
                    _context.Entry(entity).State = EntityState.Modified;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Обновление сущности типа <see cref="Entity"/>
        /// </summary>
        /// <param name="entity">Сущность типа <see cref="Entity"/></param>
        public void Update(Entity entity)
        {
            try
            {
                _context.Entry(entity).State = EntityState.Modified;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region Операции Delete (удаления)

        /// <summary>
        /// Удаление всех сущностей типа <see cref="Entity"/>
        /// </summary>
        public void DeleteAll()
        {
            try
            {
                _context.Set<Entity>().RemoveRange(GetAll());
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Удаление коллеции сущностей типа <see cref="Entity"/>
        /// </summary>
        /// <param name="entities">Коллекция сущностей типа <see cref="Entity"/></param>
        public void Delete(IEnumerable<Entity> entities)
        {
            try
            {
                _context.Set<Entity>().RemoveRange(entities);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Удаление сущности типа <see cref="Entity"/> по идентификатору (первичному ключу)
        /// </summary>
        /// <param name="id">Первичный ключ сущности</param>
        public void Delete(int id)
        {
            try
            {
                _context.Set<Entity>().Remove(Get(id));
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

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
