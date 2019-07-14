using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Demo.Microservices.Services.NewsService.Entities;
using Demo.Microservices.Services.NewsService.Handlers;
namespace Demo.Microservices.Services.NewsService.Handlers
{
    public class GetNewsQueryHandler : IQueryHandler<GetNewsQuery, Entities.News>
    {
        public News Handle(GetNewsQuery query)
        {
            throw new NotImplementedException();
        }
    }
}
