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
        private readonly IMessageQueueProvider _messageQueueProvider;
        public PublishNewsCommandHandler(  IMessageQueueProvider messageQueueProvider)
        {
            _messageQueueProvider = messageQueueProvider;
        }
        public Result Handle(PublishNewsCommand command)
        {
            _messageQueueProvider.Push(command);
            return Result.Ok();
        }
    }
}
