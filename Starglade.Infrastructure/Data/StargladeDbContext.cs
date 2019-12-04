using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Starglade.Core.Entities;
using Starglade.Core.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Starglade.Infrastructure.Data
{
    public class StargladeDbContext : DbContext
    {
        AppSettings appSettings;

        ILoggerFactory factory = LoggerFactory.Create(buider => buider.AddConsole());
        public StargladeDbContext(IOptionsMonitor<AppSettings> appSettings)
        {
            this.appSettings = appSettings.CurrentValue;

        }


        #region methods
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

#if DEBUG
            optionsBuilder.UseLoggerFactory(factory);
#endif

            optionsBuilder.UseSqlServer(appSettings.ConnectionStrings.Db);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            ChangeTracker.DetectChanges();

            foreach (var entry in ChangeTracker.Entries())
            {
                if (entry.State == EntityState.Added || entry.State == EntityState.Deleted || entry.State == EntityState.Deleted)
                {
                    var entity = entry.Entity as StargladeEntity;
                    if (entity != null)
                    {
                        entity.LastUpdate = DateTime.UtcNow;


                        if (entry.State == EntityState.Deleted)
                        {
                            entry.State = EntityState.Modified;
                            entity.IsDeleted = true;
                        }
                    }

                }

            }

            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PostCategory>().HasKey(e => new { e.PostId, e.CategoryId });
            modelBuilder.Entity<PostTag>().HasKey(e => new { e.PostId, e.TagId });
            // modelBuilder.Entity<StargladeEntity>().HasQueryFilter(e => !e.IsDeleted);



            base.OnModelCreating(modelBuilder);
        }

        #endregion 

        #region entities

        public DbSet<Post> Posts { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Tag> Tags { get; set; }
        #endregion


    }
}
