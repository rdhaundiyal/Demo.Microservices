using System;
using System.Collections.Generic;

namespace Demo.Microservices.Services.Entities
{
    public partial class News
    {
        public News()
        {
            Images = new HashSet<Images>();
            NewsCategory = new HashSet<NewsCategory>();
        }

        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public DateTime? PublishDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public Guid SourceId { get; set; }
        public bool Approved { get; set; }

        public NewsSource Source { get; set; }
        public ICollection<Images> Images { get; set; }
        public ICollection<NewsCategory> NewsCategory { get; set; }
    }
}
