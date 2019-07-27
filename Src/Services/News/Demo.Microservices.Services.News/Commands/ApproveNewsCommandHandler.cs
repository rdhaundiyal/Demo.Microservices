using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using Demo.Microservices.Core.Handlers;

namespace Demo.Microservices.Services.NewsService.Commands
{
    public class ApproveNewsCommandHandler:ICommandHandler<ApproveNewsCommand>
    {
        public Guid NewsId { get; set; }
        public Result Handle(ApproveNewsCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
