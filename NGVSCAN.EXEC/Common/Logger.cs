using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Linq;

namespace NGVSCAN.EXEC.Common
{
    public static class Logger
    {
        private static readonly string _fileName = "Log.json";

        private static List<LogEntry> log;

        public static void Log(ListView console, LogEntry entry)
        {
            if (log == null)
                log = new List<LogEntry>();

            log.Add(entry);

            LogToFile(entry);

            LogToConsole(console, entry);
        }

        private static void LogToFile(LogEntry entry)
        {
            using (StreamWriter log = new StreamWriter(_fileName, true))
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

            console.Items.Add(item);

            console.AutoResizeColumn(0, ColumnHeaderAutoResizeStyle.HeaderSize);
            console.AutoResizeColumn(1, ColumnHeaderAutoResizeStyle.ColumnContent);
            console.AutoResizeColumn(2, ColumnHeaderAutoResizeStyle.ColumnContent);
            console.AutoResizeColumn(3, ColumnHeaderAutoResizeStyle.ColumnContent);

            console.Items[console.Items.Count - 1].EnsureVisible();
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
            using (StreamReader file = new StreamReader(_fileName))
            {
                return JsonConvert.DeserializeObject<List<LogEntry>>(file.ReadToEnd());
            }
        }
    }
}
