using System.Collections.Generic;
using System.Linq;
using Demo.Microservices.Core.Handlers;
using Demo.Microservices.Services.Entities;
using Demo.Microservices.Services.Search.Commands;
using Demo.Microservices.Services.Search.Model;
using SolrNet;

namespace Demo.Microservices.Services.Search.Service
{
    public class SearchService : ISearchService
    {
        private readonly ISolrOperations<SolrNewsItem> _solrOperations;
        private readonly Messages _messages;
        public  SearchService(ISolrOperations<SolrNewsItem> solrOperations, Messages messages)
        {
            _solrOperations = solrOperations;
            _messages = messages;

        }

        public virtual IQueryable<News> GetTopNews(int count)
        {
            var result = _messages.Dispatch(new GetTopNewsQuery(){Count = count});
            return result;
        }

        public IList<News> Search(string keywords)
        {
            var result = _messages.Dispatch(new SearchNewsQuery() { Keywords = keywords });
            return result;
        }

       
    }
}





//solrOperations.Query()
//var results = solr.Query(new SolrQueryByField("author", searchString),
//    new QueryOptions
//    {
//        Highlight = new HighlightingParameters
//        {
//            Fields = new[] { "search_snippet" },
//        }
//    });

//var returnedResults = new List<Dictionary<string, string>>();

//    if (results.Count > 0)
//{
//    foreach (var pdfDoc in results)
//    {
//        var docBuffer = new Dictionary<string, string>();
//        docBuffer.Add("Id", ""+pdfDoc.Id.GetHashCode());
//        docBuffer.Add("Content", "" + pdfDoc.Content.ElementAt(0));
//        docBuffer.Add("Version", "" + pdfDoc.Version);

//        foreach (var h in results.Highlights[results[0].Id])
//        {
//            docBuffer.Add("search_snippet", String.Format("{0}", string.Join(", ", h.Value.ToArray())));
//            Debug.WriteLine("search_snippet", String.Format("{0}", string.Join(", ", h.Value.ToArray())));
//        }
//        returnedResults.Add(docBuffer);
//    }
//}
//return returnedResults;
