using System;
using System.Linq;
using CSharpFunctionalExtensions;
using Demo.Microservices.Core.Handlers;
using Demo.Microservices.Services.Entities;
using Demo.Microservices.Core.Provider;
using Demo.Microservices.Services.NewsService.Commands;


namespace Demo.Microservices.Services.NewsService.Service
{

    public class NewsService : INewsService
    {
        private readonly Messages _messages;
        //Newsprovider might be used her if we are making  a direct call to other source else remove it later
        private readonly IEntityProvider<News> _newsProvider;
     
        public NewsService(IEntityProvider<News> newsProvider, Messages messages)
        {
            _newsProvider = newsProvider;
            _messages = messages;
           
        }
        public bool ApproveNews(Guid newsId)
        {
       
            throw new NotImplementedException();
        }

        public Entities.News GetNews(Guid newsId)
        {
            var result = _messages.Dispatch(new GetNewsQuery(newsId));
            return result;
        }

        public virtual IQueryable<Entities.News> GetTopNews(int count = 10)
        {
            throw new NotImplementedException();
        }

        public Result PublishNews(Entities.News news)
        {
            throw new NotImplementedException();
        }
    }
}
