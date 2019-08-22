using System;
using System.Linq;
using CSharpFunctionalExtensions;

namespace Demo.Microservices.Services.NewsService.Service
{
  public  interface INewsService
    {
       
        Entities.News GetNews(Guid newsId);
       
        
    }
}
