using CSharpFunctionalExtensions;

namespace Demo.Microservices.Core.Handlers
{
    public interface ICommandHandler<TCommand>
      where TCommand : ICommand
    {
        Result Handle(TCommand command);
    }
}
