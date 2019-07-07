using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Demo.Microservices.Services.News.Service;

namespace Demo.Microservices.Services.News.Repository
{
    public class NewsRepository : Repository<Entities.News>, INewsRepository
    {
        public NewsRepository(NewsDbContext dbContext) : base(dbContext)
        {
        }
    }
}
