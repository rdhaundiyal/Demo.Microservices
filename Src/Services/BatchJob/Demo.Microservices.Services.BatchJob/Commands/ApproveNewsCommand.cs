using System;
using Demo.Microservices.Core.Handlers;

namespace Demo.Microservices.Services.BatchJob.Commands
{
  public  class ApproveNewsCommand:ICommand
    {
        public Guid NewsId { get; set; }
    }
}
