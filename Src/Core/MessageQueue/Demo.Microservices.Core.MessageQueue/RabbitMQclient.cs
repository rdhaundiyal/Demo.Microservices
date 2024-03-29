﻿using System;
using System.IO;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;

namespace Demo.Microservices.Core.MessageQueue
{
    public abstract class RabbitMQclient : IDisposable
    {
        public readonly string ExchangeName;
        private readonly IConnectionFactory _connectionFactory;
        private int _retryCount;
        private readonly ILogger _logger;
        private IConnection _connection;
        bool _disposed;
        public readonly string Type;
        readonly object _syncRoot = new object();
        protected RabbitMQclient(IConnectionFactory connectionFactory, ILogger logger, string exchangeName, string type, int retryCount = 5)
        {
            _connectionFactory = connectionFactory ?? throw new ArgumentNullException(nameof(connectionFactory));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _retryCount = retryCount;
            ExchangeName = exchangeName;
            Type = type;
        }

        public IConnection GetConnection()
        {
            if (!IsConnected)
            {
                TryConnect();
            }
            return _connection;

        }



        private bool IsConnected => _connection != null && _connection.IsOpen && !_disposed;


        void OnConnectionShutdown(object sender, ShutdownEventArgs reason)
        {
            if (_disposed) return;

            _logger.LogWarning("A RabbitMQ connection is on shutdown. Trying to re-connect...");

            TryConnect();
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

            lock (_syncRoot)
            {
                _connection = _connectionFactory
                       .CreateConnection();

                //var policy = RetryPolicy.Handle<SocketException>()
                //    .Or<BrokerUnreachableException>()
                //    .WaitAndRetry(_retryCount, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)), (ex, time) =>
                //        {
                //            _logger.LogWarning(ex, "RabbitMQ Client could not connect after {TimeOut}s ({ExceptionMessage})", $"{time.TotalSeconds:n1}", ex.Message);
                //        }
                //    );

                //policy.Execute(() =>
                //{
                //    _connection = _connectionFactory
                //        .CreateConnection();
                //});

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
