using System.Collections.Generic;

namespace Demo.Microservices.Services.Entities
{
    public partial class Countries
    {
        public Countries()
        {
            NewsSource = new HashSet<NewsSource>();
        }

        public int Code { get; set; }
        public string Name { get; set; }

        public ICollection<NewsSource> NewsSource { get; set; }
    }
}
