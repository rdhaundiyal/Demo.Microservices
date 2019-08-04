using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Demo.Microservices.Core.Handlers;
using Demo.Microservices.Services.Entities;
using Demo.Microservices.Services.Search.Model;
using Demo.Microservices.Services.Search.Solr;
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
         var ClustresuerResults=  GetNews();

            throw new NotImplementedException();
        }

        public async Task<object> GetNews()
        {
            var news = await _solrOperations.QueryAsync(SolrQueryHelper.BuildQuery(new SearchParameters()));
            return news;
        }
    }
}
