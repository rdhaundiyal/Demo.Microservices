using System;
using System.Collections.Generic;

namespace Demo.Microservices.Services.NewsService.Entities { 
    public partial class Images
    {
        public Guid Id { get; set; }
        public string ImagePath { get; set; }
        public Guid NewsId { get; set; }

        public News News { get; set; }
    }
}
