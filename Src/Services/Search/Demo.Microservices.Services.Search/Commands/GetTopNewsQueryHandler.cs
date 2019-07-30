using System;
using System.Collections.Generic;
using Demo.Microservices.Core.Handlers;
using Demo.Microservices.Services.Entities;
using Demo.Microservices.Services.Search.Model;
using SolrNet;

namespace Demo.Microservices.Services.Search.Commands
{
    public class GetTopNewsQueryHandler:IQueryHandler<GetTopNewsQuery,IList<News>>
    {
        private readonly ISolrOperations<SolrNewsItem> _solrOperations;
        public GetTopNewsQueryHandler(ISolrOperations<SolrNewsItem> solrOperations, Messages messages)
        {
            _solrOperations = solrOperations;

        }
        public IList<News> Handle(GetTopNewsQuery query)
        {
            throw new NotImplementedException();
        }
    }
}
