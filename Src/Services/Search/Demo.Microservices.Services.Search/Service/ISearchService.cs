using System.Collections.Generic;
using Demo.Microservices.Services.Entities;

namespace Demo.Microservices.Services.Search.Service
{
   public interface ISearchService
   {
       IList<News> GetNews(int count);
       IList<News> Search(string keywords);
   }
}
