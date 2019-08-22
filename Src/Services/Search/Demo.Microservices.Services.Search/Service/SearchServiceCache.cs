using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Demo.Microservices.Core.Cache;
using Demo.Microservices.Core.Handlers;
using Demo.Microservices.Services.Entities;
using Demo.Microservices.Services.Search.Model;
using SolrNet;

namespace Demo.Microservices.Services.Search.Service
{
    public class SearchServiceCache:SearchService
    {
        private readonly ICache _cache;
        public SearchServiceCache(ISolrOperations<SolrNewsItem> solrOperations, Messages messages, ICache cache) : base(solrOperations, messages)
        {
            _cache = cache;
        }
        public override IList<News> GetTopNews(int count = 10)
        {
            var topNewsList = _cache.Retrieve<IQueryable<News>>(CacheKeys.TopNewsList);
            if (topNewsList != null) return topNewsList;

            topNewsList = base.GetTopNews(count);
            _cache.Store(CacheKeys.TopNewsList, topNewsList);

            return topNewsList;
        }
    }
}
