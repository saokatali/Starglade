using Microsoft.Extensions.DependencyInjection;
using Starglade.Mobile.Services;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Starglade.Mobile
{
    public static class Container
    {
        public static IServiceProvider Services { get; private set; }
        public static void RegisterServices()
        {
            IServiceCollection serviceCollection = new ServiceCollection();
            serviceCollection.AddSingleton<HttpClientHandler, StargladeHttpClientHandler>();
            serviceCollection.AddSingleton<HttpClient, StargladeHttpClient>();
            serviceCollection.AddSingleton(typeof(PostService));

            Services = serviceCollection.BuildServiceProvider();
        }
    }
}
