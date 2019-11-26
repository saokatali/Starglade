using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Starglade.Mobile
{
    public static class Container
    {
        public static IServiceProvider Services { get; private set; }
        public static void RegisterServices()
        {
            IServiceCollection serviceDescriptors = new ServiceCollection();

            Services = serviceDescriptors.BuildServiceProvider();
        }
    }
}
