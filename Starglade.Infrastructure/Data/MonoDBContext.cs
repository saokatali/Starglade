using Starglade.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Driver;
using Microsoft.Extensions.Options;

namespace Starglade.Infrastructure.Data
{
    public class MonoDBContext 
    {
        AppSettings appSettings;

        public MonoDBContext(IOptionsMonitor<AppSettings> appSettings)
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
