using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SolrNet;

namespace Demo.Microservices.Services.Search.Solr
{
    public static class SolrQueryHelper
    {
        /// <summary>
        /// Builds the Solr query from the search parameters
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static ISolrQuery BuildQuery(SearchParameters parameters)
        {
            if (!string.IsNullOrEmpty(parameters.FreeSearch))
                return new SolrQuery(parameters.FreeSearch);
            return SolrQuery.All;
        }
    }
}
