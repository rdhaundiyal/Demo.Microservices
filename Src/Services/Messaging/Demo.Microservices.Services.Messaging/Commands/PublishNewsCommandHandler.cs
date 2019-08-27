using CSharpFunctionalExtensions;
using Demo.Microservices.Core.Handlers;
using Demo.Microservices.Core.Handlers.Decorators;
using Demo.Microservices.Core.MessageQueue;

namespace Demo.Microservices.Services.Messaging.Commands
{
    [Retry]
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
