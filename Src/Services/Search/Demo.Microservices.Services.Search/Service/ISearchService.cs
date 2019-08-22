using System.Collections.Generic;
using System.Linq;
using Demo.Microservices.Services.Entities;

namespace Demo.Microservices.Services.Search.Service
{
   public interface ISearchService
   {
       IQueryable GetTopNews(int count);
       IList<News> Search(string keywords);
   }
}
