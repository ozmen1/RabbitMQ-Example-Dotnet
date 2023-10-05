namespace RabbitMQProducer.Services
{
    public interface IRabbitMqService
    {
        void SendNameToQueue(string name);
    }
}
