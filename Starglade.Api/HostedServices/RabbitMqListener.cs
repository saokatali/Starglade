using Microsoft.Extensions.Hosting;
using RabbitMQ.Client.Events;
using Starglade.Core.Constants;
using Starglade.Core.Entities;
using Starglade.Core.Interfaces;
using Starglade.Core.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Starglade.Api.HostedServices
{
    public class RabbitMqListener : IHostedService
    {
        IBusClient busClient;
        ICacheRepository cache;
        private readonly ICategoryService categoryService;

        public RabbitMqListener(IBusClient busClient, ICacheRepository cache, ICategoryService categoryService)
        {
            this.busClient = busClient;
            this.cache = cache;
            this.categoryService = categoryService;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            busClient.Register();

            busClient.Subscribe(async (obj, e) =>
            {
                    var categories = await categoryService.GetAllAsync();
                    cache.SetAsync(CacheConstant.CATEGORY_KEY, categories);
                
                ((EventingBasicConsumer)obj).Model.BasicAck(e.DeliveryTag, false);

            });

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            busClient.DeRegister();
            return Task.CompletedTask;
        }
    }
}
