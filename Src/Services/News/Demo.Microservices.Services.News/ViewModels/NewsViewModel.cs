using System;

namespace Demo.Microservices.Services.NewsService.ViewModels
{
    public class NewsViewModel
    {
        public string Title { get; set; }
        public string Thumbnail { get; set; }
        public string[] Images { get; set; }
        public string Details { get; set; }
        public DateTime PublishDate { get; set; }
        public string Source { get; set; }
    }
}
