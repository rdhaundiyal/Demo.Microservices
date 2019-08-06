using System;
using System.Collections.Generic;
using System.Linq;
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

         foreach (var s in ClustresuerResults.Result.ToList())
         {
             var z = s;
         }
         throw new NotImplementedException();
        }

        public async Task<SolrQueryResults<SolrNewsItem>> GetNews()
        {
            var news = await _solrOperations.QueryAsync(SolrQueryHelper.BuildQuery(new SearchParameters()));
            return news;
        }
    }
}
