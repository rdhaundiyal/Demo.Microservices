using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Demo.Microservices.Core.Repository;
using Demo.Microservices.Services.NewsService.Entities;
using Demo.Microservices.Services.NewsService.Models;
using Demo.Microservices.Services.NewsService.Service;

namespace Demo.Microservices.Services.NewsService.Repository
{
    public class NewsRepository : EFBaseRepository<News>
    {
        public NewsRepository(NewsDbContext dbContext) : base(dbContext)
        {
        }
    }
}
