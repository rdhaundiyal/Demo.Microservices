using System;
using System.IO;
using System.Net.Sockets;
using Demo.Microservices.Core.Common;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQ.Client.Exceptions;
using RabbitMQ.Client.MessagePatterns;

namespace Demo.Microservices.Core.MessageQueue
{
   public abstract  class RabbitMQclient:IDisposable
    {
        protected  IConnection Connection;
        protected  IModel Model;
     
        protected  string ExchangeName;
        protected string QueueName;
        protected string RoutingKey;
        private IConnectionFactory _connectionFactory;
        private int _retryCount;
        private ILogger _logger;
        IConnection _connection;
        bool _disposed;
        protected RabbitMQclient(IConnectionFactory connectionFactory, ILogger logger, int retryCount = 5)
        {
            _connectionFactory = connectionFactory ?? throw new ArgumentNullException(nameof(connectionFactory));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _retryCount = retryCount;
        }

      
        

        object sync_root = new object();
        public bool IsConnected
        {
            get
            {
                return _connection != null && _connection.IsOpen && !_disposed;
            }
        }
        public IModel CreateModel()
        {
            if (!IsConnected)
            {
                throw new InvalidOperationException("No RabbitMQ connections are available to perform this action");
            }

            return _connection.CreateModel();
        }
        void OnConnectionShutdown(object sender, ShutdownEventArgs reason)
        {
            if (_disposed) return;

            _logger.LogWarning("A RabbitMQ connection is on shutdown. Trying to re-connect...");

            TryConnect();
        }
        public void SendMessage<T>(T message, string routingKey,string topicName="")
        {
            SendMessage(message.Serialize(),routingKey);
        }


        public void SendMessage(byte[] message, string routingKey)
        {
            Model.BasicPublish(ExchangeName, routingKey, null, message);
        }

        public T ReceiveMessage<T>(string queueName)
        {

            Model.BasicQos(0, 10, false);
            Subscription subscription = new Subscription(Model,
                queueName, false);

            BasicDeliverEventArgs deliveryArguments = subscription.Next();

            var message =
                (T)deliveryArguments.Body.DeSerialize<T>();

            var routingKey = deliveryArguments.RoutingKey;

            subscription.Ack(deliveryArguments);
            return message;
            
        }

        public void Dispose()
        {
            if (_disposed) return;

            _disposed = true;

            try
            {
                _connection.Dispose();
            }
            catch (IOException ex)
            {
                _logger.LogCritical(ex.ToString());
            }
        }

        public bool TryConnect()
        {
            _logger.LogInformation("RabbitMQ Client is trying to connect");

            lock (sync_root)
            {
                var policy = RetryPolicy.Handle<SocketException>()
                    .Or<BrokerUnreachableException>()
                    .WaitAndRetry(_retryCount, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)), (ex, time) =>
                        {
                            _logger.LogWarning(ex, "RabbitMQ Client could not connect after {TimeOut}s ({ExceptionMessage})", $"{time.TotalSeconds:n1}", ex.Message);
                        }
                    );

                policy.Execute(() =>
                {
                    _connection = _connectionFactory
                        .CreateConnection();
                });

                if (IsConnected)
                {
                    _connection.ConnectionShutdown += OnConnectionShutdown;
               

                    _logger.LogInformation("RabbitMQ Client acquired a persistent connection to '{HostName}' and is subscribed to failure events", _connection.Endpoint.HostName);

                    return true;
                }
                else
                {
                    _logger.LogCritical("FATAL ERROR: RabbitMQ connections could not be created and opened");

                    return false;
                }
            }
        }

    }
}
