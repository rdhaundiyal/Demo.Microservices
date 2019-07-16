using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Demo.Microservices.Core.Repository;
using Demo.Microservices.Services.NewsService.Entities;
using Demo.Microservices.Services.NewsService.Service;
using Demo.Microservices.Services.NewsService.Providers;
namespace Demo.Microservices.Services.NewsService.Providers
{
    public class NewsEFProvider : EFBaseProvider<News>
    {
        public NewsEFProvider(NewsDbContext dbContext) : base(dbContext)
        {
        }
    }
}
