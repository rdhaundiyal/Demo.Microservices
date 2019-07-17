using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Demo.Microservices.Core.Provider;
using Demo.Microservices.Services.NewsService.Entities;
using Demo.Microservices.Services.NewsService.Handlers;
using Demo.Microservices.Services.NewsService.Providers;
namespace Demo.Microservices.Services.NewsService.Handlers
{
    public class GetNewsQueryHandler : IQueryHandler<GetNewsQuery, Entities.News>
    {
      private readonly  IEntityProvider<News> _provider;
        public GetNewsQueryHandler(IEntityProvider<News> provider)
        {
            _provider = provider;
        }
        public News Handle(GetNewsQuery query)
        {
            return _provider.GetByID(query.NewsId);
        }
    }
}
