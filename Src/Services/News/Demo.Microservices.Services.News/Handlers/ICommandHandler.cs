using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;

namespace Demo.Microservices.Services.NewsService.Handlers
{
    public interface ICommandHandler<TCommand>
      where TCommand : ICommand
    {
        Result Handle(TCommand command);
    }
}
