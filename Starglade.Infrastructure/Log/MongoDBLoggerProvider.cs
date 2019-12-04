using Starglade.Core.Interfaces;
using System;

namespace Starglade.Infrastructure.Log
{
    public class MongoDBLoggerProvider : StargladeLoggerProvider
    {

        IMongoDBRepository<LogEntry> dbRepository;

        public MongoDBLoggerProvider(IMongoDBRepository<LogEntry> dbRepository)
        {
            this.dbRepository = dbRepository;
        }

        public async override void WriteEntry(LogEntry entry)
        {
            try
            {

                //await dbRepository.AddAsync(entry);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
