using System;
using System.Collections.Generic;
using System.Text;
using CSharpFunctionalExtensions;
using Demo.Microservices.Core.Handlers;
using Demo.Microservices.Services.BatchJob.Commands;

namespace Demo.Microservices.Services.BatchJob
{
public    class SendMailCommandHandler:ICommandHandler<SendMailCommand>
    {
        public Result Handle(SendMailCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
