using System;
using System.Collections.Generic;
using System.Text;

namespace Starglade.Core.Models
{
    public class AppSettings
    {
        public ConnectionStrings ConnectionStrings { get; set; }

        public MongoDBSettings MongoDB { get; set; }

        public Logging Logging { get; set; }

        public JWT JWT { get; set; }





    }

    public class ConnectionStrings
    {
        public string Db { get; set; }

      
    }

    public class Logging
    {
        public string Provider { get; set; }
        public bool IsEnabled { get; set; }
    }

    public class MongoDBSettings
    {
        public string ConnectionStrings { get; set; }

        public string Db { get; set; }
    }

    public class JWT
    {
        public string SecretKey { get; set; }
        public string Issuer { get; set; }
        public int ExpireDays { get; set; }
    }


}
