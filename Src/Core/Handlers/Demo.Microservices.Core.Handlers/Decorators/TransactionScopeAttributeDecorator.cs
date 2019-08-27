using System.Transactions;
using CSharpFunctionalExtensions;


namespace Demo.Microservices.Core.Handlers.Decorators
{
    public sealed class TransactionScopeAttributeDecorator<TCommand> : ICommandHandler<TCommand>
    where TCommand : ICommand
    {
        private readonly ICommandHandler<TCommand> _handler;

        public TransactionScopeAttributeDecorator(ICommandHandler<TCommand> handler)
        {
            _handler = handler;

        }


        public Result Handle(TCommand command)
        {
            using (var scope = new TransactionScope())
            {
                var result = _handler.Handle(command);
                scope.Complete();
                return result;
            }
        }
    }
}
