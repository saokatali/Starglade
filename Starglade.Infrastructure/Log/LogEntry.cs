using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Logging;

namespace Starglade.Infrastructure.Log
{
    public class LogEntry
    {
        public string Message { get; set; }
        public string StackStrace { get; set; }

        public DateTime CreatedAt { get; set; }

    }
}
