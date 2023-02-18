using ServiceBasedRabbit.Core.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceBasedRabbit.Core.Interfaces.MessageBroker
{
    public interface IRabbitMQPublisher
    {
        public void Publish<T>(T message, string queue, string routing_key);


    }
}
