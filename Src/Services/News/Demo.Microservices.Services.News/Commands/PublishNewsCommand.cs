using System;
using System.Collections.Generic;
using Demo.Microservices.Core.Handlers;
using Demo.Microservices.Services.NewsService.Entities;

namespace Demo.Microservices.Services.NewsService.Commands
{
    public class PublishNewsCommand : ICommand
    {

        public string Title { get; set; }
        public string Details { get; set; }
        public DateTime? PublishDate { get; set; }
        public Guid SourceId { get; set; }
        public NewsSource Source { get; set; }
        public ICollection<Images> Images { get; set; }


        public PublishNewsCommand()
        {
            Images = new List<Images>();
        }

    }
}
