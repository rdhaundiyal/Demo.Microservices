namespace Demo.Microservices.Services.NewsService.Handlers
{
    public interface IQueryHandler<TQuery, TResult>
      where TQuery : IQuery<TResult>
    {
        TResult Handle(TQuery query);
    }
}
