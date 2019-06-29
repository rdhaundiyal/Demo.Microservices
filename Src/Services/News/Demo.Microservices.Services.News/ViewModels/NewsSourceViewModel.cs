using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Microservices.Services.News.ViewModels
{
    public class NewsSourceViewModel
    {
        public string SourceName { get; set; }
        public string Correspondent { get; set; }
        public Countries Country { get; set; } 
    }
}
