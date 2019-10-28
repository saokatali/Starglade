﻿using System;
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
using Microsoft.Extensions.Hosting;
using Starglade.Core.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;

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
            services.AddDbContext<SecurityDbContext>();
            services.AddScoped(typeof(IDbRepository<>), typeof(DbContextRepository<>));
            services.AddMongo();
            services.AddSingleton(typeof(IMongoDBRepository<>), typeof(MongoDbRepository<>));
            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = Configuration["Redis:Configuration"];
                options.InstanceName = Configuration["Redis:InstanceName"];
            });
            services.AddLogging(builder => builder.Services.AddSingleton<ILoggerProvider, MongoDBLoggerProvider>());
            services.AddStargladeServices();
            services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<SecurityDbContext>().AddDefaultTokenProviders();
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = true;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = false,
                    ValidateAudience=false,                  
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:SecretKey"])),
                    ClockSkew = TimeSpan.Zero

                };

            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
        }



        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // loggerFactory.AddProvider(new MongoDBLoggerProvider());

            app.UseMiddleware<ExceptionMiddleware>();

            if (!env.IsDevelopment())
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });


        }
    }
}