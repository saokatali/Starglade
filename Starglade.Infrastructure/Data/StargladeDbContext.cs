using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Starglade.Core.Models;
using Microsoft.Extensions.Options;

namespace Starglade.Infrastructure.Data
{
    public class StargladeDbContext:DbContext
    {
        AppSettings appSettings; 
        public StargladeDbContext(IOptionsSnapshot<AppSettings> appSettings)
        {
            this.appSettings = appSettings.Value;

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(appSettings.ConnectionStrings.Db);
        }


    }
}
