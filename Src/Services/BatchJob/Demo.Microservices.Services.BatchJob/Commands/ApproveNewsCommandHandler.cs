using System;
using System.Collections.Generic;
using System.Text;
using CSharpFunctionalExtensions;
using Demo.Microservices.Core.Handlers;

namespace Demo.Microservices.Services.BatchJob.Commands
{
    public class ApproveNewsCommandHandler:ICommandHandler<ApproveNewsCommand>
    {
        public Result Handle(ApproveNewsCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
