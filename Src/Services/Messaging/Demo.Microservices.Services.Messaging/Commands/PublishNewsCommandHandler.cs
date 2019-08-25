using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using Demo.Microservices.Core.Handlers;
using Demo.Microservices.Core.MessageQueue;
using Demo.Microservices.Services.Entities;

namespace Demo.Microservices.Services.Messaging.Commands
{
    public class PublishNewsCommandHandler:ICommandHandler<PublishNewsCommand>
    {
        private readonly IMessageServiceBus _messageServiceBus;
        public PublishNewsCommandHandler(  IMessageServiceBus messageServiceBus)
        {
            _messageServiceBus = messageServiceBus;
        }
        public Result Handle(PublishNewsCommand command)
        {
            _messageServiceBus.Push(command,"message.news");
            return Result.Ok();
        }
    }
}
