using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Starglade.Core.Models;
using Microsoft.Extensions.Options;
using System.Threading;
using System.Threading.Tasks;
using Starglade.Core.Entities;

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

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            ChangeTracker.DetectChanges();

            foreach (var entity in ChangeTracker.Entries<StargladeEntity>())
            {
                if(entity.State == EntityState.Added || entity.State == EntityState.Deleted || entity.State == EntityState.Deleted)
                {
                    entity.Entity.LastUpdate = DateTime.UtcNow;

                    if(entity.State == EntityState.Deleted)
                    {
                        entity.State = EntityState.Modified;
                    }

                }

            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
