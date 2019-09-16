using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Starglade.Core.Models;

namespace Starglade.Infrastructure.Log
{
    public abstract class StargladeLoggerProvider : ILoggerProvider
    {
        private readonly ConcurrentDictionary<string, StargladeLogger> _loggers = new ConcurrentDictionary<string, StargladeLogger>();
        
        public ILogger CreateLogger(string categoryName)
        {
            return _loggers.GetOrAdd(categoryName, name => new StargladeLogger(name, this,true));
        }

        public void Dispose()
        {
            
        }

        public abstract void  WriteEntry(LogEntry entry);
       
    }
}
