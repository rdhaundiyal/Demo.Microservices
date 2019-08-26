using System;
using System.Collections.Generic;
using System.Text;
using Demo.Microservices.Core.Handlers;

namespace Demo.Microservices.Services.Common
{
   public class RetryAttribute<TQuery,TResult> : IQueryHandler<TQuery,TResult>
        where TQuery : IQuery<TResult>
    {
        private readonly IQueryHandler<TQuery,TResult> _handler;

        public RetryAttribute(IQueryHandler<TQuery, TResult> handler)
        {
            _handler = handler;
        }

        TResult IQueryHandler<TQuery, TResult>.Handle(TQuery query)
        {
            //apply logic here
            return _handler.Handle(query);
            
        }
    }

}
