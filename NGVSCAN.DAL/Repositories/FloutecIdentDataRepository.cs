using NGVSCAN.CORE.Entities;
using NGVSCAN.DAL.Extensions;
using System.Data.OleDb;

namespace NGVSCAN.DAL.Repositories
{
    public class FloutecIdentDataRepository
    {
        #region Конструктор и поля

        private readonly string _connectionString;

        public FloutecIdentDataRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        #endregion

        public FloutecIdentData Get(int address, int line)
        {
            FloutecIdentData identData = new FloutecIdentData();
            int n_flonit = address * 10 + line;
            identData.N_FLONIT = n_flonit;

            using (OleDbConnection connection = new OleDbConnection(_connectionString))
            using (OleDbCommand command = connection.CreateCommand())
            {
                connection.Open();
                command.CommandText = "SELECT * FROM ident.DBF WHERE N_FLONIT=" + n_flonit;

                using (OleDbDataReader reader = command.ExecuteReader())
                {
                    reader.Read();

                    identData.FromIdentTable(reader);
                }

                command.CommandText = "SELECT * FROM stat.DBF WHERE N_FLONIT=" + n_flonit;

                using (OleDbDataReader reader = command.ExecuteReader())
                {
                    reader.Read();

                    identData.FromStatTable(reader);
                }
            }

            return identData;
        }
    }
}
