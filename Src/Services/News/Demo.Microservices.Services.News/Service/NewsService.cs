using System;
using System.Linq;
using CSharpFunctionalExtensions;
using Demo.Microservices.Core.Handlers;
using Demo.Microservices.Services.Entities;
using Demo.Microservices.Core.Provider;
using Demo.Microservices.Services.NewsService.Commands;


namespace Demo.Microservices.Services.NewsService.Service
{

    public class NewsService : INewsService
    {
        private readonly Messages _messages;


        public NewsService(Messages messages)
        {

            _messages = messages;

        }


        public Entities.News GetNews(Guid newsId)
        {
            var result = _messages.Dispatch(new GetNewsQuery(newsId));
            return result;
        }




    }
}
