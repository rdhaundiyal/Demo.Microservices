namespace Demo.Microservices.Core.Handlers.Decorators
{
   public class RetryAttributeDecorator<TQuery,TResult> : IQueryHandler<TQuery,TResult>
        where TQuery : IQuery<TResult>
    {
        private readonly IQueryHandler<TQuery,TResult> _handler;

        public RetryAttributeDecorator(IQueryHandler<TQuery, TResult> handler)
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
