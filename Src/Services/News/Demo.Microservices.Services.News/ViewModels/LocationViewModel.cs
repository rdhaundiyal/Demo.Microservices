using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Microservices.Services.News.ViewModels
{
    public class LocationViewModel
    {
        public Countries Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public Coordinates Coordinates { get; set; }
    }
}
