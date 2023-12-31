﻿using RabbitMQ.Client;
using System.Text;

namespace RabbitMQProducer.Services
{
    public class RabbitMqService : IRabbitMqService
    {
        public void SendNameToQueue(string name)
        {
            var factory = new ConnectionFactory() { HostName = "localhost", UserName = "kerem", Password = "kerem123" };//Konfigurasyondan alınabilir            
            using (IConnection connection = factory.CreateConnection())
            using (IModel channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "NameQueue",
                    durable: false, //Data saklama yöntemi (memory-fiziksel)
                    exclusive: false, //Başka bağlantıların kuyruğa ulaşmasını istersek true kullanabiliriz.
                    autoDelete: false,
                    arguments: null);//Exchange parametre tanımları.          

                var body = Encoding.UTF8.GetBytes(name); //Model alınarak json serialize uygulanabilir.

                channel.BasicPublish(exchange: "",
                    routingKey: "NameQueue",
                    body: body);
            }
        }
    }
}
