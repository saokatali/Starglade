using Starglade.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Starglade.Infrastructure.Log
{
    public class MongoDBLoggerProvider : StargladeLoggerProvider
    {
        //private AppSettings appSettings;

        //public MongoDBLoggerProvider(AppSettings appSettings)
        //{
        //    this.appSettings = appSettings;
        //}

        public override void WriteEntry(LogEntry entry)
        {
            Console.WriteLine(entry);
        }
    }
}
