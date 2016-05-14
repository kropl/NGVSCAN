using NGVSCAN.CORE.Entities.Common;
using System.Collections.Generic;

namespace NGVSCAN.DAL.Services
{
    public interface IDataService<Entity> where Entity : class, IEntity
    {
        IEnumerable<Entity> GetAll();

        Entity Get(int id);

        void Insert(IEnumerable<Entity> entities);

        void Insert(Entity entity);

        void Update(IEnumerable<Entity> entities);

        void Update(Entity entity);

        void DeleteAll();

        void Delete(IEnumerable<Entity> entities);

        void Delete(int id);
    }
}
