using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace NGVSCAN.EXEC
{
    public static class Settings
    {
        private static readonly string _fileName = "Settings.ngv";

        #region Настройки

        public static string ServerName { get; set; }

        public static string SqlServerPath { get; set; }

        public static string SqlDatabaseName { get; set; }

        public static string SqlUserName { get; set; }

        public static string SqlUserPassword { get; set; }

        public static string DbfTablesPath { get; set; }

        #endregion

        #region Методы получения/сохранения настроек

        public static void Get()
        {
            Hashtable settings = null;

            using (FileStream fileStream = new FileStream(_fileName, FileMode.Open))
            {
                try
                {
                    BinaryFormatter formatter = new BinaryFormatter();

                    settings = (Hashtable)formatter.Deserialize(fileStream);

                    ServerName = settings["ServerName"] == null ? "" : settings["ServerName"].ToString();
                    SqlServerPath = settings["SqlServerPath"] == null ? "" : settings["SqlServerPath"].ToString();
                    SqlDatabaseName = settings["SqlDatabaseName"] == null ? "" : settings["SqlDatabaseName"].ToString();
                    SqlUserName = settings["SqlUserName"] == null ? "" : settings["SqlUserName"].ToString();
                    SqlUserPassword = settings["SqlUserPassword"] == null ? "" : settings["SqlUserPassword"].ToString();
                    DbfTablesPath = settings["DbfTablesPath"] == null ? "" : settings["DbfTablesPath"].ToString();
                }
                catch (SerializationException)
                {

                }
            }
        }

        public static void Save()
        {
            Hashtable settings = new Hashtable();
            settings.Add("ServerName", ServerName);
            settings.Add("SqlServerPath", SqlServerPath);
            settings.Add("SqlDatabaseName", SqlDatabaseName);
            settings.Add("SqlUserName", SqlUserName);
            settings.Add("SqlUserPassword", SqlUserPassword);
            settings.Add("DbfTablesPath", DbfTablesPath);

            using (FileStream fileStream = new FileStream(_fileName, FileMode.Create))
            {
                BinaryFormatter formatter = new BinaryFormatter();

                try
                {
                    formatter.Serialize(fileStream, settings);
                }
                catch (SerializationException)
                {

                }
            }               
        }

        #endregion
    }
}
