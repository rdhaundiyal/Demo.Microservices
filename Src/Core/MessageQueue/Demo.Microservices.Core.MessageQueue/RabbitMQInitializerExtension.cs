using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client;

namespace Demo.Microservices.Core.MessageQueue
{
    public static class RabbitMQInitializerExtension
    {
        private static ConnectionFactory _factory;
        
        private static Func<IServiceProvider, object> BuildConnection(Type interfaceType, IConfiguration configuration)
        {

            Func<IServiceProvider, object> func = provider =>
            {


                _factory = new ConnectionFactory
                {
                    HostName =configuration["localhost"],
                    UserName = configuration["username"],
                    Password = configuration["password"]
                };


              return _factory.CreateConnection();

            };

            return func;
        }

        public static void AddConnection(this IServiceCollection services, IConfiguration configuration)
        {

            Func<IServiceProvider, object> factory = BuildConnection(typeof(IConnection),configuration);

            services.AddScoped(typeof(IConnection), factory);
        }
    }
}
