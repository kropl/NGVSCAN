using NGVSCAN.CORE.Entities;
using NGVSCAN.DAL.Extensions;
using System;
using System.Collections.Generic;
using System.Data.OleDb;

namespace NGVSCAN.DAL.Repositories
{
    public class FloutecHourlyDataRepository
    {
        #region Конструктор и поля

        private readonly string _connectionString;

        public FloutecHourlyDataRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        #endregion

        public List<FloutecHourlyData> Get(int address, int line, DateTime from, DateTime to)
        {
            List<FloutecHourlyData> hourlyData = new List<FloutecHourlyData>();
            int n_flonit = address * 10 + line;

            using (OleDbConnection connection = new OleDbConnection(_connectionString))
            using (OleDbCommand command = connection.CreateCommand())
            {
                connection.Open();
                command.CommandText = "SELECT DISTINCT * FROM rour.DBF WHERE N_FLONIT=" + n_flonit + " AND CONVERT(DATETIME, DAT, 110) > ?";
                command.Parameters.Add(new OleDbParameter("from", OleDbType.DBTimeStamp)).Value = from;
                command.Parameters.Add(new OleDbParameter("to", OleDbType.DBTimeStamp)).Value = to;

                using (OleDbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        hourlyData.FromHourTable(reader);
                    }
                }
            }

            hourlyData.ForEach(h => h.N_FLONIT = n_flonit);

            return hourlyData;
        }
    }
}
