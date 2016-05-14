using NGVSCAN.CORE.Entities.Common;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace NGVSCAN.DAL.Repository
{
    public class Repository<Entity> : IRepository<Entity> where Entity : class, IEntity
    {
        #region Constructor & Fields

        private readonly DbContext _context;

        public Repository(DbContext context)
        {
            _context = context;
        }

        #endregion

        #region Get 

        public IEnumerable<Entity> GetAll()
        {
            return _context.Set<Entity>().ToList();
        }

        public Entity Get(int id)
        {
            return _context.Set<Entity>().Where(e => e.Id == id).SingleOrDefault();
        }

        #endregion

        #region Insert

        public void Insert(IEnumerable<Entity> entities)
        {
            _context.Set<Entity>().AddRange(entities);
        }

        public void Insert(Entity entity)
        {
            _context.Set<Entity>().Add(entity);
        }

        #endregion

        #region Update

        public void Update(IEnumerable<Entity> entities)
        {
            foreach (Entity entity in entities)
            {
                _context.Entry(entity).State = EntityState.Modified;
            }
        }

        public void Update(Entity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        #endregion

        #region Delete

        public void DeleteAll()
        {
            _context.Set<Entity>().RemoveRange(GetAll());
        }

        public void Delete(IEnumerable<Entity> entities)
        {
            _context.Set<Entity>().RemoveRange(entities);
        }

        public void Delete(int id)
        {
            _context.Set<Entity>().Remove(Get(id));
        }

        #endregion
    }
}
