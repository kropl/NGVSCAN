﻿using NGVSCAN.CORE.Entities;
using NGVSCAN.DAL.Extensions;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Diagnostics;
using System.Linq;

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

            if (to >= from)
            {
                int n_flonit = address * 10 + line;

                List<DateTime> days = new List<DateTime>();

                for (var date = from; date <= to; date = date.AddDays(1))
                {
                    days.Add(date);
                }

                Debug.WriteLine("Days list initialized");

                using (OleDbConnection connection = new OleDbConnection(_connectionString))
                using (OleDbCommand command = connection.CreateCommand())
                {
                    connection.Open();

                    foreach (var date in days)
                    {
                        command.CommandText = "SELECT DISTINCT * FROM rour.DBF WHERE N_FLONIT=" + n_flonit + " AND DAT LIKE('" + date.ToString("dd.MM.yyyy") + " __:00:00" + "')";

                        using (OleDbDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                hourlyData.FromHourTable(reader);
                            }
                        }

                        Debug.WriteLine("Data for day " + date.ToString("dd.MM.yyyy") + " readed");
                    }
                }

                hourlyData.ForEach(h => h.N_FLONIT = n_flonit);
            }

            return hourlyData.Where(h => h.DAT >= from && h.DAT <= to).ToList();
        }
    }
}