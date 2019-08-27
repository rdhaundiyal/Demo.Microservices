using Demo.Microservices.Core.Provider;
using Demo.Microservices.Services.Entities;

namespace Demo.Microservices.Services.NewsService.Providers
{
    public class NewsEFProvider : EFBaseProvider<News>
    {
        public NewsEFProvider(NewsDbContext dbContext) : base(dbContext)
        {
        }
    }
}
