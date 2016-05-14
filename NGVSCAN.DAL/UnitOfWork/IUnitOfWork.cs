using NGVSCAN.CORE.Entities.Common;
using NGVSCAN.DAL.Repository;
using System;

namespace NGVSCAN.DAL.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Entity> Repository<Entity>() where Entity : class, IEntity;

        void Commit();
    }
}
