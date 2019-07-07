using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Microservices.Services.News.Entities
{
    public class News
    {
        [Key]
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Thumbnail { get; set; }
        public string Images { get; set; }
        public string Details { get; set; }
        public DateTime PublishDate { get; set; }
        public string Source { get; set; }
    }
}
