using System;
using System.Collections.Generic;
using Demo.Microservices.Core.Handlers;
using Demo.Microservices.Services.Entities;

namespace Demo.Microservices.Services.Search.Commands
{
    public class GetTopNewsQueryHandler:IQueryHandler<GetTopNewsQuery,IList<News>>
    {
        public IList<News> Handle(GetTopNewsQuery query)
        {
            throw new NotImplementedException();
        }
    }
}
