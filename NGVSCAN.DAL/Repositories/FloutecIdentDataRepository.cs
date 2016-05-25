using NGVSCAN.CORE.Entities;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NGVSCAN.DAL.Repositories
{
    public class FloutecIdentDataRepository
    {
        #region Конструктор и поля

        private readonly OleDbConnection _connection;

        public FloutecIdentDataRepository(OleDbConnection connection)
        {
            _connection = connection;
        }

        #endregion

        #region Вспомогательные методы

        private static T GetReaderValue<T>(OleDbDataReader reader, string ordinal, T defaultValue = default(T))
        {
            try
            {
                return (T)Convert.ChangeType(reader[ordinal], typeof(T));
            }
            catch (Exception)
            {
                return defaultValue;
            }
        }

        private static FloutecIdentData GetReaderValues(OleDbDataReader reader)
        {
            return new FloutecIdentData
            {
                
            };
        }

        #endregion
    }
}
