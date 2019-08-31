using System;
using System.Collections.Generic;
using System.Text;

namespace Starglade.Core.Models
{
    public class AppSettings
    {
        public ConnectionStrings ConnectionStrings { get; set; }



    }

    public class ConnectionStrings
    {
        public string Db { get; set; }
    }
}
