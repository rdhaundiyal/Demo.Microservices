using System;
using System.Collections.Generic;

namespace Demo.Microservices.Services.Entities
{
    public partial class NewsCategory
    {
        public Guid NewsId { get; set; }
        public Guid CategoryId { get; set; }
        public Guid Id { get; set; }

        public Category Category { get; set; }
        public News News { get; set; }
    }
}
