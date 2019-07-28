using System;
using Demo.Microservices.Core.Handlers;
using Demo.Microservices.Services.Entities;

namespace Demo.Microservices.Services.NewsService.Commands
{
    public class GetNewsQuery:IQuery<News>
    {
       

        public GetNewsQuery(Guid guid)
        {
            NewsId = guid;
        }

        public readonly Guid NewsId;
    }
}
