using Microsoft.Extensions.DependencyInjection;
using Starglade.Infrastructure.Data;
using Starglade.Service.Services;
using System.Linq;
using System.Reflection;

namespace Starglade.Web.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddStargladeServices(this IServiceCollection services)
        {
            Assembly assembly = Assembly.GetAssembly(typeof(StargladeService));

            foreach (var type in assembly.GetTypes().Where(e => e.Name.EndsWith("Service") && !e.Name.StartsWith(nameof(StargladeService))))
            {
                var baseType = type.GetInterfaces().FirstOrDefault(e => e.Name.EndsWith("Service"));

                services.AddTransient(baseType, type);


            }


        }

        public static void AddMongo(this IServiceCollection services)
        {
            services.AddSingleton(typeof(MongoDBContext));
        }

    }
}
