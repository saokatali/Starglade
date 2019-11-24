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
        public StargladeDbContext(IOptionsMonitor<AppSettings> appSettings)
        {
            this.appSettings = appSettings.CurrentValue;

        }


        #region methods
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(appSettings.ConnectionStrings.Db);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            ChangeTracker.DetectChanges();

            foreach (var entity in ChangeTracker.Entries())
            {
                if(entity.State == EntityState.Added || entity.State == EntityState.Deleted || entity.State == EntityState.Deleted)
                {
                    (entity.Entity as StargladeEntity).LastUpdate = DateTime.UtcNow;

                    if(entity.State == EntityState.Deleted)
                    {
                        entity.State = EntityState.Modified;
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
