using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Starglade.Core.Interfaces;
using Starglade.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace Starglade.Infrastructure.MessageBroker
{
    public class RabbitMQClient : IBusClient
    {
        AppSettings appSettings;
        private IConnection connection;
        private IModel channel;
        ILogger logger;


        public RabbitMQClient(IOptionsMonitor<AppSettings> appSettings, ILogger<RabbitMQClient> logger)
        {
            this.appSettings = appSettings.CurrentValue;
            this.logger = logger;
        }

        public void Register()
        {

            try
            {
                var cf = new ConnectionFactory();
                cf.HostName = appSettings.RabbitMQ.Host;
                cf.UserName = appSettings.RabbitMQ.User;
                cf.Password = appSettings.RabbitMQ.Pass;
                connection = cf.CreateConnection();
                channel = connection.CreateModel();
                channel.ExchangeDeclare(appSettings.RabbitMQ.Exchange, appSettings.RabbitMQ.ExchangeType, true, false);
                channel.QueueDeclare(appSettings.RabbitMQ.Queue, true, false, false);
                channel.QueueBind(appSettings.RabbitMQ.Queue, appSettings.RabbitMQ.Exchange, appSettings.RabbitMQ.RoutingKey);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
            }

        }



        public void DeRegister()
        {
            try
            {
                connection.Close();
                channel.Close();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
            }


        }

        public void Publish<T>(T data) where T : IMessage
        {

            channel.BasicPublish(appSettings.RabbitMQ.Exchange, appSettings.RabbitMQ.RoutingKey, null, Encoding.UTF8.GetBytes(JsonSerializer.Serialize(data)));
        }
        public void Subscribe(EventHandler<BasicDeliverEventArgs> callback)
        {

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += callback;


            channel.BasicConsume(appSettings.RabbitMQ.Queue, false, consumer);
        }


    }
}
