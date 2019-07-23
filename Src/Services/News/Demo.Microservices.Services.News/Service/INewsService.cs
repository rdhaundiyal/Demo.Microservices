using System;
using System.Linq;
using CSharpFunctionalExtensions;

namespace Demo.Microservices.Services.NewsService.Service
{
  public  interface INewsService
    {
        IQueryable<Entities.News> GetTopNews(int count =10);
        Entities.News GetNews(Guid newsId);
        Result PublishNews(Entities.News news);
        bool ApproveNews(Guid newsId);
    }
}
