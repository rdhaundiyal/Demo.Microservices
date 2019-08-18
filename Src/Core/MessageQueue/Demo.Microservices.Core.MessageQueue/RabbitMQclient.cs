using System;
using Demo.Microservices.Core.Common;
using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;

namespace Demo.Microservices.Core.MessageQueue
{
   public  class RabbitMQclient:IDisposable
    {


        private static IConnection _connection;
        private static IModel _model;
        private static IConfiguration _configuration;
        private const string ExchangeName = "Topic_Exchange";
        private const string CardPaymentQueueName = "CardPaymentTopic_Queue";
        private const string PurchaseOrderQueueName = "PurchaseOrderTopic_Queue";
        private const string AllQueueName = "AllTopic_Queue";

        public RabbitMQclient(IConnection connection,IConfiguration configuration)
        {
            _connection = connection;
            _configuration = configuration;
        }


      

        private static void CreateModel(string queueName,string routingKey)
        {
           
            _model = _connection.CreateModel();
            _model.ExchangeDeclare(_configuration["ExchangeName"], _configuration[ "topic"]);

            _model.QueueDeclare(queueName, true, false, false, null);
            _model.QueueBind(queueName, ExchangeName, routingKey);
         
        }

        public void SendMessage<T>(T message, string routingKey)
        {
            SendMessage(message.Serialize(),routingKey);
        }


        public void SendMessage(byte[] message, string routingKey)
        {
            _model.BasicPublish(ExchangeName, routingKey, null, message);
        }

        public T ReceiveMessage<T>()
        {
           throw new NotImplementedException();
        }

        public void Dispose()
        {
            _model?.Dispose();
        }
    }
}
