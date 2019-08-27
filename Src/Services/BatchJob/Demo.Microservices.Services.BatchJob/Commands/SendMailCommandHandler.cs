using System;
using CSharpFunctionalExtensions;
using Demo.Microservices.Core.Handlers;

namespace Demo.Microservices.Services.BatchJob.Commands
{
    public    class SendMailCommandHandler:ICommandHandler<SendMailCommand>
    {
        public Result Handle(SendMailCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
