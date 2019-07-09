using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using Demo.Microservices.Services.News.Entities;

namespace Demo.Microservices.Services.News.Handlers
{
    public class PublishNewsCommand : Command<News.Entities.News>
    {
        public PublishNewsCommand(Entities.News entity) : base(entity)
        {
        }

        public override Result Execute()
        {
            throw new NotImplementedException();
        }
    }
}
