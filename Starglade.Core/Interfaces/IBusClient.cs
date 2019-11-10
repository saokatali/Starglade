using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Starglade.Core.Interfaces
{
    public interface IBusClient
    {
        void Register();

        void DeRegister();

        void Publish<T>(T data);

        void Subscribe(EventHandler<BasicDeliverEventArgs> callback);

        
    }
}
