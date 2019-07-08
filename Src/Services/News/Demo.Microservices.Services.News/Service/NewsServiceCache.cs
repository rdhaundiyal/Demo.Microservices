using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Demo.Microservices.Services.News.Repository;

namespace Demo.Microservices.Services.News.Service
{
    public class NewsServiceCache : NewsService
    {
        public NewsServiceCache(INewsRepository newsRepository) : base(newsRepository)
        {
        }

        public override Entities.News GetNews(string newsId)
        {
            throw new NotImplementedException();
        }
    }
}
