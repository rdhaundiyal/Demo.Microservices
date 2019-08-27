namespace Demo.Microservices.Core.MessageQueue
{
    public interface IMessageServiceBus
   {
       void Push(object message,string routingKey);
       T GetMessage<T>(string queueName, string routingKey);
   }
}
