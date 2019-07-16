using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using Demo.Microservices.Services.NewsService.Entities;
using Demo.Microservices.Services.NewsService.Providers;
using Demo.Microservices.Core.Repository;
namespace Demo.Microservices.Services.NewsService.Service
{

    public class NewsService : INewsService
    {
        private readonly Messages _messages;
        private readonly IEntityProvider<Entities.News> _newsProvider;

        public NewsService(IEntityProvider<News> newsProvider, Messages messages)
        {
            _newsProvider = newsProvider;
            _messages = messages;

        }
        public bool ApproveNews(Guid newsId)
        {
            //List<StudentDto> list = _messages.Dispatch(new GetListQuery(enrolled, number));
            //return Ok(list);
            throw new NotImplementedException();
        }

        public Entities.News GetNews(Guid newsId)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Entities.News> GetTopNews(int count = 10)
        {
            throw new NotImplementedException();
        }

        public Result PublishNews(Entities.News news)
        {
            throw new NotImplementedException();
        }
    }
}
