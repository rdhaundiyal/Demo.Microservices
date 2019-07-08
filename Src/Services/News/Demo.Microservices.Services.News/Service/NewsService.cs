using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using Demo.Microservices.Services.News.Entities;
using Demo.Microservices.Services.News.Repository;

namespace Demo.Microservices.Services.News.Service
{
    
    public class NewsService : INewsService
    {
        public NewsService(INewsRepository newsRepository)
        {

        }
        public Result AddNews(Entities.News news)
        {
            throw new NotImplementedException();
        }

        public virtual Entities.News GetNews(string newsId)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Entities.News> GetTopNews(int count = 10)
        {
            throw new NotImplementedException();
        }
    }
}
