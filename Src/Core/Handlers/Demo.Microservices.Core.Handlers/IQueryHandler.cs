namespace Demo.Microservices.Core.Handlers
{
    public interface IQueryHandler<TQuery, TResult>
      where TQuery : IQuery<TResult>
    {
        TResult Handle(TQuery query);
    }
}
