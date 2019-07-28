using System.Collections.Generic;
using Demo.Microservices.Core.Handlers;
using Demo.Microservices.Services.Entities;

namespace Demo.Microservices.Services.Search.Commands
{
    public class GetTopNewsQuery:IQuery<IList<News>>
    {
        public int Count { get; set; }
    }
}
