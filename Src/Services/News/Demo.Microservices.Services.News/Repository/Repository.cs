using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Demo.Microservices.Services.News.Service;
using Microsoft.EntityFrameworkCore;

namespace Demo.Microservices.Services.News.Repository
{
    public abstract class Repository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        private readonly NewsDbContext _dbContext;

        public Repository(NewsDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task Create(TEntity entity)
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

        public Task<TEntity> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(int id, TEntity entity)
        {
            throw new NotImplementedException();
        }



       

        public IQueryable<TEntity> GetBy(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate)
        {

            IQueryable<TEntity> query = _dbContext.Set<TEntity>().Where(predicate);
            return query;
        }

      



    }
}
