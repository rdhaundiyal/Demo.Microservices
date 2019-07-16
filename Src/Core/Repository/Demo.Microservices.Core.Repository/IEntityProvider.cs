using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Microservices.Core.Repository
{
   public interface IEntityProvider<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> Get();
        TEntity GetByID(object id);
        void Insert(TEntity entity);
        void Delete(object id);
        void Update(TEntity entityToUpdate);
    }
}
