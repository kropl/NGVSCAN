using NGVSCAN.CORE.Entities;
using NGVSCAN.DAL.Extensions;
using System.Data.Odbc;
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

            using (OdbcConnection connection = new OdbcConnection(_connectionString))
            using (OdbcCommand command = connection.CreateCommand())
            {
                connection.Open();
                command.CommandText = "SELECT * FROM ident.DB WHERE N_FLONIT=" + n_flonit;

                using (OdbcDataReader reader = command.ExecuteReader())
                {
                    reader.Read();

                    identData.FromIdentTable(reader);
                }

                command.CommandText = "SELECT * FROM stat.DB WHERE N_FLONIT=" + n_flonit;

                using (OdbcDataReader reader = command.ExecuteReader())
                {
                    reader.Read();

                    identData.FromStatTable(reader);
                }
            }

            return identData;
        }
    }
}
