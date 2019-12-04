using System;

namespace Starglade.Infrastructure.Log
{
    public class LogEntry
    {
        public string Message { get; set; }
        public string StackStrace { get; set; }

        public DateTime CreatedAt { get; set; }

        public string LogLevel { get; set; }

        public string EventName { get; set; }

        public string Method { get; set; }


    }
}
