using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Microservices.Services.News.Handlers
{
  public  interface IQuery<TEntity> where TEntity:class
    {
        TEntity Execute();
    }
}
