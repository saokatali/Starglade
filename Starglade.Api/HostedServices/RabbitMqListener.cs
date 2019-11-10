using Microsoft.Extensions.Hosting;
using Starglade.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Starglade.Api.HostedServices
{
    public class RabbitMqListener : IHostedService
    {
        IBusClient busClient;

        public RabbitMqListener(IBusClient busClient)
        {
            this.busClient = busClient;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            busClient.Register();



            return Task.CompletedTask;
        }

        public  Task StopAsync(CancellationToken cancellationToken)
        {
             busClient.DeRegister();
            return Task.CompletedTask;
        }
    }
}
