using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Demo.Microservices.Core.Repository;
using Demo.Microservices.Services.NewsService.Entities;
using Demo.Microservices.Services.NewsService.Repository;

namespace Demo.Microservices.Services.NewsService.Service
{
    public class NewsServiceCache : NewsService
    {
        public NewsServiceCache(IEntityProvider<Entities.News> newsProvider) : base(newsProvider)
        {
        }
    }
}
