using System;

namespace NGVSCAN.EXEC.Common
{
    public class LogEntry
    {
        public LogStatus Status { get; set; }
        public LogType Type { get; set; }
        public DateTime Timestamp { get; set; }
        public string Message { get; set; }
    }
}
