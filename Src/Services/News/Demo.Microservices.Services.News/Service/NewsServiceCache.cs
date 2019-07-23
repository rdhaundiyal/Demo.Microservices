using Demo.Microservices.Core.Provider;
using Demo.Microservices.Services.NewsService.Entities;

namespace Demo.Microservices.Services.NewsService.Service
{
    public class NewsServiceCache : NewsService
    {
        public NewsServiceCache(IEntityProvider<News> newsProvider, Messages messages) : base( newsProvider,  messages)
        {
        }
    }
}
