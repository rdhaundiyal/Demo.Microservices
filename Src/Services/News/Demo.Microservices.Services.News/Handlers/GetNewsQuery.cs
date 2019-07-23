using System;
using Demo.Microservices.Services.NewsService.Entities;

namespace Demo.Microservices.Services.NewsService.Handlers
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
