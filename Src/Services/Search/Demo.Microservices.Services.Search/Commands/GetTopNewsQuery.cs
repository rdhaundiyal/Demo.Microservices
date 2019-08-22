using System.Collections.Generic;
using System.Linq;
using Demo.Microservices.Core.Handlers;
using Demo.Microservices.Services.Entities;

namespace Demo.Microservices.Services.Search.Commands
{
    public class GetTopNewsQuery:IQuery<IQueryable<News>>
    {
        public int Count { get; set; }
    }
}
