using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Microservices.Services.News.Handlers
{
    public abstract class Query<TEntity> : IQuery<TEntity> where TEntity : class
    {
        private TEntity _entity;
        public Query(TEntity entity)
        {
            _entity = entity;
        }
        public abstract TEntity Execute();
        
    }
}
