using System;
using System.Collections.Generic;
using System.Text;
using RabbitMQ.Client;

namespace Demo.Microservices.Core.MessageQueue
{
  public  class RabbitMQTopicClient:RabbitMQclient
    {
        public RabbitMQTopicClient(IConnection connection,string routingKey,string queueName, string exchangeName = ""):base(connection,routingKey,queueName,exchangeName)
        {
           
        }

        


        protected override void CreateModel()
        {

            Model = Connection.CreateModel();
            Model.ExchangeDeclare(ExchangeName, "topic");

            Model.QueueDeclare(QueueName, true, false, false, null);
            Model.QueueBind(QueueName, ExchangeName, RoutingKey);

        }

    }
}
