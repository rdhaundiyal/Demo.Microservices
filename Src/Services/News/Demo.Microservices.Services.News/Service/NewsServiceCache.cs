using System.Linq;
using Demo.Microservices.Core.Cache;
using Demo.Microservices.Core.Handlers;
using Demo.Microservices.Core.Provider;
using Demo.Microservices.Services.NewsService.Constants;
using Demo.Microservices.Services.Entities;

namespace Demo.Microservices.Services.NewsService.Service
{
    public class NewsServiceCache : NewsService
    {
        private readonly ICache _cache;
        public NewsServiceCache(IEntityProvider<News> newsProvider, Messages messages,ICache cache) : base( newsProvider,  messages)
        {
            _cache = cache;
        }
        public override IQueryable<News> GetTopNews(int count = 10)
        {
            var topNewsList = _cache.Retrieve<IQueryable<News>>(CacheKeys.TopNewsList);
            if (topNewsList != null) return topNewsList;

            topNewsList = base.GetTopNews(count);
            _cache.Store(CacheKeys.TopNewsList,topNewsList);

            return topNewsList;
        }
    }
}
