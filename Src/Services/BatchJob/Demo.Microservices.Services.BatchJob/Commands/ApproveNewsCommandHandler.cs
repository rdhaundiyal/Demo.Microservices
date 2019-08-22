using System;
using System.Collections.Generic;
using System.Text;
using CSharpFunctionalExtensions;
using Demo.Microservices.Core.Handlers;
using Demo.Microservices.Core.MessageQueue;

namespace Demo.Microservices.Services.BatchJob.Commands
{
    public class ApproveNewsCommandHandler:ICommandHandler<ApproveNewsCommand>
    {
        private IMessageQueueProvider _messageQueueProvider;
        public ApproveNewsCommandHandler(IMessageQueueProvider messageQueueProvider)
        {
            _messageQueueProvider = messageQueueProvider;
        }
        public Result Handle(ApproveNewsCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
