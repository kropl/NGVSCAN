using NGVSCAN.CORE.Entities.Common;
using NGVSCAN.DAL.Context;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Data.SqlClient;
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
        public SqlRepository(string connectionString)
        {
            SqlConnection connection = new SqlConnection(connectionString);            

            // Инициализация контекста доступа к данным
            _context = new NGVSCANContext(connection);
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
            catch (Exception ex)
            {
                throw ex;
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
            catch (Exception ex)
            {
                throw ex;
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
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
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
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
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
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
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
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
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
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
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
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
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
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

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
