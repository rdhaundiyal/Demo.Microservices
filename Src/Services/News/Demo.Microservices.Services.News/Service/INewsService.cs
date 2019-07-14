using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using Demo.Microservices.Services.NewsService.Entities;
namespace Demo.Microservices.Services.NewsService.Service
{
  public  interface INewsService
    {
        IQueryable<Demo.Microservices.Services.NewsService.Entities.News> GetTopNews(int count =10);
        Demo.Microservices.Services.NewsService.Entities.News GetNews(Guid newsId);
        Result PublishNews(Demo.Microservices.Services.NewsService.Entities.News news);
        bool ApproveNews(Guid newsId);
    }
}
