using Microsoft.Extensions.Logging;
using System;

namespace Starglade.Infrastructure.Log
{
    class StargladeLogger : ILogger
    {
        string categoryName;
        StargladeLoggerProvider provider;
        bool enabled;

        public StargladeLogger(string categoryName, StargladeLoggerProvider provider, bool enabled)
        {
            this.categoryName = categoryName;
            this.provider = provider;
            this.enabled = enabled;
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return this.enabled;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            LogEntry logEntry = new LogEntry { LogLevel = logLevel.ToString(), EventName = eventId.Name, CreatedAt = DateTime.UtcNow, Message = formatter(state, exception), StackStrace = exception?.StackTrace, Method = exception?.TargetSite.Name };
            provider.WriteEntry(logEntry);
        }
    }
}
