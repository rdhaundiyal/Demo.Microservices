using System.Linq;
using CSharpFunctionalExtensions;
using Demo.Microservices.Core.Handlers;
using Demo.Microservices.Core.Handlers.Decorators;
using Demo.Microservices.Core.MessageQueue;
using Demo.Microservices.Core.Provider;
using Demo.Microservices.Services.BatchJob.Model;
using Demo.Microservices.Services.Entities;
using SolrNet;

namespace Demo.Microservices.Services.BatchJob.Commands
{
    [TransactionScope]
    public class ApproveNewsCommandHandler:ICommandHandler<ApproveNewsCommand>
    {
        private readonly IEntityProvider<News> _provider;
        private readonly ISolrOperations<SolrNewsItem> _solrOperation;
        private readonly IMessageServiceBus _messageServiceBus;
        public ApproveNewsCommandHandler(IEntityProvider<News> provider, ISolrOperations<SolrNewsItem> solrOperations, IMessageServiceBus messageServiceBus)
        {
            _provider = provider;
            _solrOperation = solrOperations;
            _messageServiceBus = messageServiceBus;
        }

        public Result Handle(ApproveNewsCommand command)
        {
            //news should be picked from queue
            //approved and removed from the queue
            //db entry for the item
            //pushed to solr
            //send email to the queue
            var news = _provider.GetById(command.NewsId);
            news.Approved = true;
            _provider.Update(news);
            var solrNews = new SolrNewsItem()
            {
                Category = null,
                Details = news.Details,
                Id = news.Id,
                Source = news.Source.Name,
                Title = news.Title,
                Thumbnail = news.Images.FirstOrDefault()?.ImagePath

            };
            _solrOperation.AddAsync(solrNews);
            return Result.Ok();
        }
    }
}
