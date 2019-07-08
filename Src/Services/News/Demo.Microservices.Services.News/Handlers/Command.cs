using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;

namespace Demo.Microservices.Services.News.Handlers
{
    public abstract class Command<TEntity> : ICommand where TEntity : class
    {
      private  TEntity _entity;
        public Command(TEntity entity)
        {
            _entity = entity;
        }
        public abstract Result Execute();

    }
}
