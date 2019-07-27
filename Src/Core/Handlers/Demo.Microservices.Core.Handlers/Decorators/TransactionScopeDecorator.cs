using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;
using CSharpFunctionalExtensions;


namespace Demo.Microservices.Core.Handlers.Decorators
{
    public sealed class TransactionScopeDecorator<TCommand> : ICommandHandler<TCommand>
    where TCommand : ICommand
    {
        private readonly ICommandHandler<TCommand> _handler;

        public TransactionScopeDecorator(ICommandHandler<TCommand> handler)
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
