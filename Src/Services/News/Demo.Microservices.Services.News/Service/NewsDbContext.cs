using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Demo.Microservices.Services.News.Service
{
    public class NewsDbContext:DbContext
    {

        public NewsDbContext(DbContextOptions<NewsDbContext> options) : base(options)
        {
        }

        public DbSet<News.Entities.News> News { get; set; }
      
    }
}
