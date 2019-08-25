using System;
using System.Collections.Generic;
using System.Text;
using Demo.Microservices.Core.Common;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQ.Client.MessagePatterns;

namespace Demo.Microservices.Core.MessageQueue
{
    public class RabbitMQServiceBus : IMessageServiceBus
    {
        private IModel _model;
        RabbitMQclient _client;
        public RabbitMQServiceBus(RabbitMQclient client)
        {
            CreateModel();
        }
        public void CreateModel()
        {
            IConnection connection = _client.GetConnection();
            _model = connection.CreateModel();
            _model.ExchangeDeclare(_client.ExchangeName, _client.Type);

           
        }
        public T GetMessage<T>(string queueName,string routingKey)
        {
            _model.QueueDeclare(queueName, true, false, false, null);
            _model.QueueBind(queueName, _client.ExchangeName, routingKey);

            //_model.QueueBind(queueName, _client.ExchangeName, "payment.card");
            _model.BasicQos(0, 10, false);
            Subscription subscription = new Subscription(_model,
                queueName, false);

            BasicDeliverEventArgs deliveryArguments = subscription.Next();

            var message =
                (T)deliveryArguments.Body.DeSerialize<T>();

            //var routingKey = deliveryArguments.RoutingKey;

            subscription.Ack(deliveryArguments);
            return message;
            
        }

        public void Push(object message,string routingKey)
        {
            SendMessage(message.Serialize(), routingKey);
        }

        

        public void SendMessage(byte[] message, string routingKey)
        {
            _model.BasicPublish(_client.ExchangeName, routingKey, null, message);
        }

       
    }
}
