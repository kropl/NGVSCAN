using System;
using System.Collections;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace NGVSCAN.EXEC.Common
{
    public static class Settings
    {
        private static readonly string _fileName = "Settings.ngv";

        private static readonly string _filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "NGVSCAN");

        #region Настройки

        public static string ServerName { get; set; } = "SEM-SRV";

        public static string SqlServerPath { get; set; } = @"localhost";

        public static string SqlDatabaseName { get; set; } = "NGVSCAN";

        public static string SqlUserName { get; set; } = "";

        public static string SqlUserPassword { get; set; } = "";

        public static string DbfTablesPath { get; set; } = @"C:\Dispatch\tabDbf";

        #endregion

        #region Методы получения/сохранения настроек

        public static void Get()
        {
            Hashtable settings = null;

            if (File.Exists(Path.Combine(_filePath, _fileName)))
            {
                using (FileStream fileStream = new FileStream(Path.Combine(_filePath, _fileName), FileMode.Open))
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
            else
                Save();
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

            if (!Directory.Exists(_filePath))
                Directory.CreateDirectory(_filePath);

            using (FileStream fileStream = new FileStream(Path.Combine(_filePath, _fileName), FileMode.Create))
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
