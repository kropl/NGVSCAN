using System;
using System.Windows.Forms;

namespace NGVSCAN.EXEC.Common
{
    public static class Logger
    {
        public static void Log(ListView console, string message, LogType type)
        {
            ListViewItem item = new ListViewItem(new[]
                    {
                        "",
                        DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss"),
                        message
                    });

            switch (type)
            {
                case LogType.Info:
                    item.ImageIndex = 0;
                    item.StateImageIndex = 0;
                    break;
                case LogType.Success:
                    item.ImageIndex = 1;
                    item.StateImageIndex = 1;
                    break;
                case LogType.Error:
                    item.ImageIndex = 3;
                    item.StateImageIndex = 3;
                    break;
                case LogType.Warning:
                    item.ImageIndex = 2;
                    item.StateImageIndex = 2;
                    break;
                default:
                    break;
            }

            AddLogItem(console, item);   
        }

        private static void AddLogItem(ListView console, ListViewItem item)
        {
                console.Items.Add(item);

                console.AutoResizeColumn(0, ColumnHeaderAutoResizeStyle.ColumnContent);
                console.AutoResizeColumn(1, ColumnHeaderAutoResizeStyle.ColumnContent);
                console.AutoResizeColumn(2, ColumnHeaderAutoResizeStyle.ColumnContent);

                console.Items[console.Items.Count - 1].EnsureVisible();
        }
    }
}
