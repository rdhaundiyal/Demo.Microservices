using CSharpFunctionalExtensions;
using Demo.Microservices.Core.Handlers;
using Demo.Microservices.Core.Provider;
using Demo.Microservices.Services.Entities;

namespace Demo.Microservices.Services.NewsService.Commands
{
    public class PublishNewsCommandHandler:ICommandHandler<PublishNewsCommand>
    {
        private readonly IEntityProvider<News> _provider;

        public PublishNewsCommandHandler(IEntityProvider<News> newsProvider)
        {
            _provider = newsProvider;
        }

        public Result Handle(PublishNewsCommand command)
        {
            var news = new News()
            {
                Images = command.Images,
                Details = command.Details,
                PublishDate = command.PublishDate,
                Title = command.Title,
                SourceId = command.SourceId
            };
            _provider.Insert(news);
           
            return Result.Ok();
        }
    }
}
