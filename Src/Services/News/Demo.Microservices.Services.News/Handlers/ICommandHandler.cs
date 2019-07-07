using CSharpFunctionalExtensions;

namespace Demo.Microservices.Services.News.Handlers
{
    public interface ICommand
    {
    }

    public interface ICommandHandler<TCommand>
        where TCommand : ICommand
    {
        Result Handle(TCommand command);
    }
}
