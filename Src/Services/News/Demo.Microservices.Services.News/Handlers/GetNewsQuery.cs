using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Demo.Microservices.Services.NewsService.Entities;

namespace Demo.Microservices.Services.NewsService.Handlers
{
    public class GetNewsQuery:IQuery<News>
    {
        private Guid guid;

        public GetNewsQuery(Guid guid)
        {
            this.guid = guid;
        }

        public  Guid NewsId { get; set; }
    }
}
