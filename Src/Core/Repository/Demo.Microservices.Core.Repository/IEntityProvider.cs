using System.Collections.Generic;

namespace Demo.Microservices.Core.Provider
{
   public interface IEntityProvider<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> Get();
        TEntity GetById(object id);
        void Insert(TEntity entity);
        void Delete(object id);
        void Update(TEntity entityToUpdate);
    }
}
