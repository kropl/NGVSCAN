using NGVSCAN.CORE.Entities.Common;
using NGVSCAN.DAL.Context;
using NGVSCAN.DAL.Repository;
using System;
using System.Collections.Generic;

namespace NGVSCAN.DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        #region Constructor & Fields

        private readonly NGVSCANContext _context;

        private Dictionary<string, object> _repositories;

        private bool _disposed;

        public UnitOfWork()
        {
            _context = new NGVSCANContext();
        }

        #endregion

        public IRepository<Entity> Repository<Entity>() where Entity : class, IEntity
        {
            if (_repositories == null)
                _repositories = new Dictionary<string, object>();

            string type = typeof(Entity).Name;

            if (!_repositories.ContainsKey(type))
            {
                Type repositoryType = typeof(Repository<>);

                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(Entity)), _context);

                _repositories.Add(type, repositoryInstance);
            }

            return (Repository<Entity>)_repositories[type];
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        #region Disposing

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
