using System;
using System.Collections;
using System.Collections.Generic;
using SolrNet.Attributes;

namespace Demo.Microservices.Services.Search.Model
{
    public class SolrNewsItem
    {

        [SolrUniqueKey("id")]
        public Guid Id { get; set; }

        [SolrField("title")]
        public string Title { get; set; }

        [SolrField("details")]
        public string Details { get; set; }

      
        [SolrField("thumbnail")]
        public string Thumbnail { get; set; }

        [SolrField("source")]
        public string Source { get; set; }

        [SolrField("category")]
        public IEnumerable<string> Category { get; set; }

        [SolrField("publish_date")]
        public DateTime PublishDate { get; set; }
    }
}
