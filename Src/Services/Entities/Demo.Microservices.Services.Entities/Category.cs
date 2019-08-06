using System;
using System.Collections.Generic;

namespace Demo.Microservices.Services.Entities
{
    public partial class Category
    {
        public Category()
        {
            NewsCategory = new HashSet<NewsCategory>();
        }

        public string Name { get; set; }
        public Guid Id { get; set; }

        public ICollection<NewsCategory> NewsCategory { get; set; }
    }
}
