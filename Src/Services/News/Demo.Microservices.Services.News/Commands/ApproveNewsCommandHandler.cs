using CSharpFunctionalExtensions;
using Demo.Microservices.Core.Handlers;
using Demo.Microservices.Core.Provider;
using Demo.Microservices.Services.Entities;

namespace Demo.Microservices.Services.NewsService.Commands
{
    public class ApproveNewsCommandHandler : ICommandHandler<ApproveNewsCommand>
    {
        private readonly IEntityProvider<News> _provider;
        public ApproveNewsCommandHandler(IEntityProvider<News> provider)
        {
            _provider = provider;
        }

        public Result Handle(ApproveNewsCommand command)
        {
            //var news = _provider.GetById(command.NewsId);
            //news.IsApproved = true;
            //_provider.Update(news);
            return Result.Ok();
        }
    }
}
