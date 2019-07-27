using Demo.Microservices.Core.Handlers;
using Demo.Microservices.Core.Provider;
using Demo.Microservices.Services.NewsService.Entities;

namespace Demo.Microservices.Services.NewsService.Commands
{
    public class GetNewsQueryHandler : IQueryHandler<GetNewsQuery, News>
    {
      private readonly  IEntityProvider<News> _provider;
        public GetNewsQueryHandler(IEntityProvider<News> provider)
        {
            _provider = provider;
        }
        public News Handle(GetNewsQuery query)
        {
            return _provider.GetById(query.NewsId);
        }
    }
}
