using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Starglade.Core.Identity;
using Starglade.Core.Models;

namespace Starglade.Infrastructure.Data
{
    public class SecurityDbContext : IdentityDbContext<ApplicationUser>
    {
        AppSettings appSettings;
        public SecurityDbContext(IOptionsSnapshot<AppSettings> appSettings)
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
