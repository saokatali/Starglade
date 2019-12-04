using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Starglade.Core.Models;

namespace Starglade.Infrastructure.Data
{
    public class MongoDBContext
    {
        AppSettings appSettings;

        public MongoDBContext(IOptionsMonitor<AppSettings> appSettings)
        {
            this.appSettings = appSettings.CurrentValue;
        }

        public IMongoDatabase GetDatabase()
        {
            MongoClient client = new MongoClient(appSettings.MongoDB.ConnectionStrings);
            return client.GetDatabase(appSettings.MongoDB.Db);
        }

    }
}
