using System;
using System.Collections.Generic;

namespace Demo.Microservices.Services.NewsService.Entities
{
    public partial class News
    {
        public News()
        {
            Images = new HashSet<Images>();
        }

        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public DateTime? PublishDate { get; set; }
        public int SourceId { get; set; }
        public DateTime? LastModifiedDate { get; set; }

        public NewsSource Source { get; set; }
        public ICollection<Images> Images { get; set; }
    }
}
