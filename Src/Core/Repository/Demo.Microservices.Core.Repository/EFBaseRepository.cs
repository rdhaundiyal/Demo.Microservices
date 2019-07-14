using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
namespace Demo.Microservices.Core.Repository
{
    public abstract class EFBaseRepository<TEntity>: IRepository<TEntity>
        where TEntity : class
    {
        internal DbContext context;
        internal DbSet<TEntity> dbSet;
      //  private Microservices.Services.NewsService.Repository.NewsDbContext dbContext;

        /*

{
_dbContext.Set<TEntity>().Add(entity);
throw new NotImplementedException();
}

public Task Delete(int id)
{
//_entities.Set<T>().Remove(entity);
throw new NotImplementedException();
}

public virtual IQueryable<TEntity> GetAll()
{

IQueryable<TEntity> query = _dbContext.Set<TEntity>();
return query;
}

*/
        public EFBaseRepository(DbContext context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }

        

        public virtual IEnumerable<TEntity> Get()
        {
            IQueryable<TEntity> query = dbSet;
            return query.ToList();
        }

        public virtual TEntity GetByID(object id)
        {
            return dbSet.Find(id);
        }

        public virtual void Insert(TEntity entity)
        {
            dbSet.Add(entity);
        }

        public virtual void Delete(object id)
        {
            TEntity entityToDelete = dbSet.Find(id);
            Delete(entityToDelete);
        }

        public virtual void Update(TEntity entityToUpdate)
        {
            dbSet.Attach(entityToUpdate);
            context.Entry(entityToUpdate).State = EntityState.Modified;
        }
    }
  
}
