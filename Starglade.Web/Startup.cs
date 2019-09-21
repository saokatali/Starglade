using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Starglade.Core.Models;
using Starglade.Infrastructure.Data;
using Starglade.Core.Interfaces;
using Starglade.Web.Extensions;
using Microsoft.Extensions.Logging;
using Starglade.Infrastructure.Log;
using Starglade.Web.Middlewares;

namespace Starglade.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddOptions();
            services.Configure<AppSettings>(Configuration);
            services.AddDbContext<StargladeDbContext>();           
            services.AddScoped(typeof(IDbRepository<>),typeof(DbContextRepository<>));
            services.AddMongo();
            services.AddSingleton(typeof(IMongoDBRepository<>), typeof(MongoDbRepository<>));
            services.AddLogging(builder => builder.Services.AddSingleton<ILoggerProvider, MongoDBLoggerProvider>());       
            services.AddStargladeServices();
           




            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }



        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            // loggerFactory.AddProvider(new MongoDBLoggerProvider());

            app.UseMiddleware<ExceptionMiddleware>();

            if (!env.IsDevelopment())
            {
                app.UseHsts();
            }
           

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
