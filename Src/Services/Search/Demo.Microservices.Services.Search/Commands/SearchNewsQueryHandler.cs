using System;
using System.Collections.Generic;
using Demo.Microservices.Core.Handlers;
using Demo.Microservices.Services.Entities;

namespace Demo.Microservices.Services.Search.Commands
{
    public class SearchNewsQueryHandler:IQueryHandler<SearchNewsQuery,IList<News>>
    {
        public IList<News> Handle(SearchNewsQuery query)
        {
            throw new NotImplementedException();
        }
    }
}
