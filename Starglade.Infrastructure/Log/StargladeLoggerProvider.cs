using Microsoft.Extensions.Logging;
using System.Collections.Concurrent;

namespace Starglade.Infrastructure.Log
{
    public abstract class StargladeLoggerProvider : ILoggerProvider
    {
        private readonly ConcurrentDictionary<string, StargladeLogger> _loggers = new ConcurrentDictionary<string, StargladeLogger>();

        public ILogger CreateLogger(string categoryName)
        {
            return _loggers.GetOrAdd(categoryName, name => new StargladeLogger(name, this, true));
        }

        public void Dispose()
        {

        }

        public abstract void WriteEntry(LogEntry entry);

    }
}
