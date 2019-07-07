using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Demo.Microservices.Services.News.Service;
using Microsoft.EntityFrameworkCore;

namespace Demo.Microservices.Services.News.Repository
{
    public class Repository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        private readonly NewsDbContext _dbContext;

        public Repository(NewsDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task Create(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntity> GetAll()
        {
            return _dbContext.Set<TEntity>().AsNoTracking();
        }

        public Task<TEntity> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(int id, TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
