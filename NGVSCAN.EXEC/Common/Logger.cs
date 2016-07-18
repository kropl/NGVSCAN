using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Linq;
using System;

namespace NGVSCAN.EXEC.Common
{
    public static class Logger
    {
        private static string _fileName;

        static int day;
        static int month;
        static int year;

        private static readonly string _filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "NGVSCAN");

        private static List<LogEntry> log;

        public static void Log(ListView console, LogEntry entry)
        {
            if (day != DateTime.Now.Day || month != DateTime.Now.Month || year != DateTime.Now.Year)
            {
                day = DateTime.Now.Day;
                month = DateTime.Now.Month;
                year = DateTime.Now.Year;
                log = new List<LogEntry>();
                _fileName = DateTime.Now.ToString("yyyy.MM.dd") + "_" + Settings.ServerName + "_log.json";
                console.Items.Clear();
            }

            log.Add(entry);

            LogToFile(entry);

            LogToConsole(console, entry);
        }

        private static void LogToFile(LogEntry entry)
        {
            if (!Directory.Exists(_filePath))
                Directory.CreateDirectory(_filePath);

            using (StreamWriter log = new StreamWriter(Path.Combine(_filePath, _fileName), true))
            {
                log.WriteLine(JsonConvert.SerializeObject(entry));
            }
        }

        private static void LogToConsole(ListView console, LogEntry entry)
        {
            string type = "";
            switch (entry.Type)
            {
                case LogType.System:
                    type = "Система";
                    break;
                case LogType.Floutec:
                    type = "ФЛОУТЭК";
                    break;
                case LogType.ROC:
                    type = "ROC809";
                    break;
            }

            ListViewItem item = new ListViewItem(new[]
            {
                "",
                type,
                entry.Timestamp.ToString("dd.MM.yyyy HH:mm:ss"),
                entry.Message
            });

            switch (entry.Status)
            {
                case LogStatus.Info:
                    item.ImageIndex = 0;
                    item.StateImageIndex = 0;
                    break;
                case LogStatus.Success:
                    item.ImageIndex = 1;
                    item.StateImageIndex = 1;
                    break;
                case LogStatus.Error:
                    item.ImageIndex = 3;
                    item.StateImageIndex = 3;
                    break;
                case LogStatus.Warning:
                    item.ImageIndex = 2;
                    item.StateImageIndex = 2;
                    break;
                default:
                    break;
            }
            console.BeginUpdate();
            console.Items.Add(item);

            console.AutoResizeColumn(0, ColumnHeaderAutoResizeStyle.HeaderSize);
            console.AutoResizeColumn(1, ColumnHeaderAutoResizeStyle.ColumnContent);
            console.AutoResizeColumn(2, ColumnHeaderAutoResizeStyle.ColumnContent);
            console.AutoResizeColumn(3, ColumnHeaderAutoResizeStyle.ColumnContent);

            console.Items[console.Items.Count - 1].EnsureVisible();
            console.EndUpdate();
        }

        public static void UpdateConsole(ListView console, bool showInfo, bool showSuccess, bool showWarning, bool showAlarm)
        {
            int[] statuses = new int[4];
            statuses[0] = showInfo ? 0 : 255;
            statuses[1] = showSuccess ? 1 : 255;
            statuses[2] = showWarning ? 3 : 255;
            statuses[3] = showAlarm ? 2 : 255;

            console.Items.Clear();

            List<ListViewItem> items = new List<ListViewItem>();

            foreach (var entry in log.Where(e => statuses.Contains((int)e.Status)))
            {
                string type = "";
                switch (entry.Type)
                {
                    case LogType.System:
                        type = "Система";
                        break;
                    case LogType.Floutec:
                        type = "ФЛОУТЭК";
                        break;
                    case LogType.ROC:
                        type = "ROC809";
                        break;
                }

                ListViewItem item = new ListViewItem(new[]
                {
                    "",
                    type,
                    entry.Timestamp.ToString("dd.MM.yyyy HH:mm:ss"),
                    entry.Message
                });

                switch (entry.Status)
                {
                    case LogStatus.Info:
                        item.ImageIndex = 0;
                        item.StateImageIndex = 0;
                        break;
                    case LogStatus.Success:
                        item.ImageIndex = 1;
                        item.StateImageIndex = 1;
                        break;
                    case LogStatus.Error:
                        item.ImageIndex = 3;
                        item.StateImageIndex = 3;
                        break;
                    case LogStatus.Warning:
                        item.ImageIndex = 2;
                        item.StateImageIndex = 2;
                        break;
                    default:
                        break;
                }

                items.Add(item);
            }

            console.Items.AddRange(items.ToArray());
        }

        private static List<LogEntry> GetExistingLog()
        {
            if (!Directory.Exists(_filePath))
                Directory.CreateDirectory(_filePath);

            using (StreamReader file = new StreamReader(Path.Combine(_filePath, _fileName)))
            {
                return JsonConvert.DeserializeObject<List<LogEntry>>(file.ReadToEnd());
            }
        }
    }
}
