using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Microservices.Services.NewsService.ViewModels
{
    public class LocationViewModel
    {
        public CountriesViewModel Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public CoordinatesViewModel Coordinates { get; set; }
    }
}
