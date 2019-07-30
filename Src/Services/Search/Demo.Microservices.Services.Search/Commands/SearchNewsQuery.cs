using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Demo.Microservices.Core.Handlers;
using Demo.Microservices.Services.Entities;

namespace Demo.Microservices.Services.Search.Commands
{
    public class SearchNewsQuery:IQuery<IList<News>>
    {
        public string Keywords { get; set; }

    }
}
