using System;
using System.Collections.Generic;

namespace Demo.Microservices.Services.Entities
{
    public class NewsSource
    {
        public NewsSource()
        {
            News = new HashSet<News>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Country { get; set; }

        public Countries CountryNavigation { get; set; }
        public ICollection<News> News { get; set; }
    }
}
