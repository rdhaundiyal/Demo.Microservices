using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Demo.Microservices.Core.Handlers;
using Demo.Microservices.Services.Entities;

namespace Demo.Microservices.Services.Messaging.Commands
{
    public class PublishNewsCommand : ICommand
    {
        public PublishNewsCommand()
        {
            Images=new List<Images>();
            NewsCategory=new List<NewsCategory>();
        }
        public string Title { get; set; }
        public string Details { get; set; }
        public DateTime? PublishDate { get; set; }
        public Guid SourceId { get; set; }
        public ICollection<Images> Images { get; set; }
        public ICollection<NewsCategory> NewsCategory { get; set; }
    }
}
