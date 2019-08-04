using System;
using System.Collections.Generic;
using Demo.Microservices.Core.Handlers;
using Demo.Microservices.Services.Entities;
using Demo.Microservices.Services.Search.Model;
using Demo.Microservices.Services.Search.Solr;
using SolrNet;

namespace Demo.Microservices.Services.Search.Commands
{
    public class SearchNewsQueryHandler:IQueryHandler<SearchNewsQuery,IList<News>>
    {
        private readonly ISolrOperations<SolrNewsItem> _solrOperations;
        public SearchNewsQueryHandler(ISolrOperations<SolrNewsItem> solrOperations, Messages messages)
        {
            _solrOperations = solrOperations;

        }
        public IList<News> Handle(SearchNewsQuery query)
        {



            var news = _solrOperations.QueryAsync(SolrQueryHelper.BuildQuery(new SearchParameters()));
            var result= news.Result;
            throw new NotImplementedException();
        }

        

    }
}
