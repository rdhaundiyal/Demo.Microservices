using CSharpFunctionalExtensions;
using Demo.Microservices.Core.Handlers;
using Demo.Microservices.Core.MessageQueue;
using Demo.Microservices.Core.Provider;
using Demo.Microservices.Services.Entities;

namespace Demo.Microservices.Services.NewsService.Commands
{
    public class PublishNewsCommandHandler:ICommandHandler<PublishNewsCommand>
    {
        private readonly IEntityProvider<News> _provider;
        private IMessageQueueProvider _messageQueueProvider;

        public PublishNewsCommandHandler(IEntityProvider<News> newsProvider,IMessageQueueProvider messageQueueProvider)
        {
            _provider = newsProvider;
            _messageQueueProvider = messageQueueProvider;

        }

        public Result Handle(PublishNewsCommand command)
        {
            //here it should push the item to queue as a first step as if it is pushed to database then there should be another one which will remove it if it is not approved
            //queue should be a persistent one

            var news = new News()
            {
                Images = command.Images,
                Details = command.Details,
                PublishDate = command.PublishDate,
                Title = command.Title,
                SourceId = command.SourceId
            };

            _messageQueueProvider.Push(news);

            _provider.Insert(news);
           //add the item to queue for approval
            return Result.Ok();
        }
    }
}
