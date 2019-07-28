using SolrNet.Attributes;

namespace Demo.Microservices.Services.NewsService.Models
{
    public class SolrNewsItem
    {

        [SolrUniqueKey("id")]
        public string Id { get; set; }

        [SolrField("title")]
        public string Title { get; set; }

        [SolrField("subtitle")]
        public string SubTitle { get; set; }

        //[SolrField("thumbnail")]
        //public ICollection<string> Categories { get; set; }

        [SolrField("thumbnail")]
        public string Thumbnail { get; set; }

        [SolrField("description")]
        public string  Description { get; set; }
    }

}
