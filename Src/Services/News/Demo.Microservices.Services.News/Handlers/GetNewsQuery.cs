using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Demo.Microservices.Services.News.Entities;

namespace Demo.Microservices.Services.News.Handlers
{
    public class GetNewsQuery : Query<Entities.News>
    {
        public GetNewsQuery(Entities.News entity) : base(entity)
        {
        }

        public override Entities.News Execute()
        {
            throw new NotImplementedException();
        }
    }
}
