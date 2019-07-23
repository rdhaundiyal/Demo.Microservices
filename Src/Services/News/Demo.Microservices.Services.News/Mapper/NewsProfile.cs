using AutoMapper;
using Demo.Microservices.Services.NewsService.ViewModels;

namespace Demo.Microservices.Services.NewsService.Mapper
{
    public class NewsProfile:Profile
    {
        public NewsProfile()
        {
            CreateMap<Entities.News, NewsViewModel>();
        }
    }
}
