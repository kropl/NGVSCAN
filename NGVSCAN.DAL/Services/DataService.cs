using NGVSCAN.CORE.Entities.Common;
using NGVSCAN.DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace NGVSCAN.DAL.Services
{
    public class DataService<Entity> : IDataService<Entity> where Entity : class, IEntity
    {
        #region Constructor & Fields

        private readonly IUnitOfWork _unitOfWork;

        public DataService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        #endregion

        #region Get

        public IEnumerable<Entity> GetAll()
        {
            return _unitOfWork.Repository<Entity>().GetAll();
        }

        public Entity Get(int id)
        {
            return _unitOfWork.Repository<Entity>().Get(id);
        }

        #endregion

        #region Insert

        public void Insert(IEnumerable<Entity> entities)
        {
            try
            {
                _unitOfWork.Repository<Entity>().Insert(entities);
                _unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                Debug.Write(ex.Message);
            }
        }

        public void Insert(Entity entity)
        {
            try
            {
                _unitOfWork.Repository<Entity>().Insert(entity);
                _unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                Debug.Write(ex.Message);
            }
        }

        #endregion

        #region Update

        public void Update(IEnumerable<Entity> entities)
        {
            try
            {
                _unitOfWork.Repository<Entity>().Update(entities);
                _unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                Debug.Write(ex.Message);
            }
        }

        public void Update(Entity entity)
        {
            try
            {
                _unitOfWork.Repository<Entity>().Update(entity);
                _unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                Debug.Write(ex.Message);
            }
        }

        #endregion

        #region Delete

        public void DeleteAll()
        {
            try
            {
                _unitOfWork.Repository<Entity>().DeleteAll();
                _unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                Debug.Write(ex.Message);
            }
        }

        public void Delete(IEnumerable<Entity> entities)
        {
            try
            {
                _unitOfWork.Repository<Entity>().Delete(entities);
                _unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                Debug.Write(ex.Message);
            }
        }

        public void Delete(int id)
        {
            try
            {
                _unitOfWork.Repository<Entity>().Delete(id);
                _unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                Debug.Write(ex.Message);
            }
        }

        #endregion
    }
}
