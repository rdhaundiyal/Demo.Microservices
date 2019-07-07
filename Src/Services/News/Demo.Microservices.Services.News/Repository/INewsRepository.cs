using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Microservices.Services.News.Repository
{
   public interface INewsRepository:IRepository<News.Entities.News>
    {
    }
}
