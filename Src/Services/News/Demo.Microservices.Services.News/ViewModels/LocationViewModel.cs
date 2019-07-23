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
