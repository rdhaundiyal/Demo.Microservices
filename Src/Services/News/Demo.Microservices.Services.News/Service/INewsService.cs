using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;

namespace Demo.Microservices.Services.News.Service
{
  public  interface INewsService
    {
        IQueryable<News.Entities.News> GetTopNews(int count =10);
        News.Entities.News GetNews(string newsId);
        Result AddNews(News.Entities.News news);
    }
}
