using RabbitMQ.Client.Events;
using System;

namespace Starglade.Core.Interfaces
{
    public interface IBusClient
    {
        void Register();

        void DeRegister();

        void Publish<T>(T data) where T : IMessage;

        void Subscribe(EventHandler<BasicDeliverEventArgs> callback);


    }
}
