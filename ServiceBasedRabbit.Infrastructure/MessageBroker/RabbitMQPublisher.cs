using Newtonsoft.Json;
using RabbitMQ.Client;
using ServiceBasedRabbit.Core.Dto;
using ServiceBasedRabbit.Core.Interfaces.MessageBroker;
using System;
using System.Text;

namespace ServiceBasedRabbit.Infrastructure.MessageBroker
{


    public class RabbitMQPublisher : IRabbitMQPublisher
    {

        public void Publish<T>(T message, string queue, string routing_key) //where T : ISomeClass
        {

          



            var factory = new ConnectionFactory { HostName = "localhost" };
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();

            channel.QueueDeclare(queue: queue, //"UserItemQueue",
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

            string x;
            
            if (typeof(T) == typeof(UserDto))
            {
                UserDto messageDto = message as UserDto;
                x = JsonConvert.SerializeObject(messageDto);
            }
            else if (typeof(T) == typeof(ItemDto))
            {
                ItemDto messageDto = message as ItemDto;
                x = JsonConvert.SerializeObject(messageDto);
            }
            else
            {
                UserItemDto messageDto = message as UserItemDto;
                x = JsonConvert.SerializeObject(messageDto);
            }

            var body = Encoding.UTF8.GetBytes(x);


            channel.BasicPublish(exchange: string.Empty,
                                 routingKey: queue, //"UserItemQueue", //routing_key
                                 basicProperties: null,
                                 body: body);

            Console.WriteLine($" [x] Sent {x}");


        }

        //public interface ISomeClass { }
        //class SomeClass : ISomeClass { }

    }

}
