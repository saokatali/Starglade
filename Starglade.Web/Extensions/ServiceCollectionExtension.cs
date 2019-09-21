using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Starglade.Service.Services;
using Starglade.Infrastructure.Data;

namespace Starglade.Web.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddStargladeServices(this IServiceCollection services)
        {
            Assembly assembly = Assembly.GetAssembly(typeof(StargladeService));

            foreach (var type in assembly.GetTypes().Where(e=>e.Name.EndsWith("Service") && !e.Name.StartsWith(nameof(StargladeService))))
            {
                var baseType = type.GetInterfaces().FirstOrDefault(e=>e.Name.EndsWith("Service"));

                services.AddTransient(baseType, type);


            }


        }

        public static void AddMongo(this IServiceCollection services)
        {
            services.AddSingleton(typeof(MonoDBContext));
        }

    }
}
