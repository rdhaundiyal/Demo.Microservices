using System.Linq;
using CSharpFunctionalExtensions;
using Demo.Microservices.Core.Handlers;
using Demo.Microservices.Core.Provider;
using Demo.Microservices.Services.Entities;
using Demo.Microservices.Services.NewsService.Models;
using SolrNet;

namespace Demo.Microservices.Services.NewsService.Commands
{
    public class ApproveNewsCommandHandler : ICommandHandler<ApproveNewsCommand>
    {
        private readonly IEntityProvider<News> _provider;
        private readonly ISolrOperations<SolrNewsItem> _solrOperation;
        public ApproveNewsCommandHandler(IEntityProvider<News> provider, ISolrOperations<SolrNewsItem> solrOperations)
        {
            _provider = provider;
            _solrOperation = solrOperations;
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
                Thumbnail = news.Images.FirstOrDefault().ImagePath

            };
            _solrOperation.AddAsync(solrNews);
            return Result.Ok();
        }
    }
}
