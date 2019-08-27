
using AutoMapper;
using Demo.Microservices.Services.Messaging.Commands;

namespace Demo.Microservices.Services.Messaging.Mapper
{
    public class NewsProfile:Profile
    {
        public NewsProfile()
        {
            CreateMap<Entities.News, PublishNewsCommand>();
        }
    }
}
