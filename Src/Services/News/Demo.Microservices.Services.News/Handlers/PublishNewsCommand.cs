using System;

namespace Demo.Microservices.Services.NewsService.Handlers
{
    public class PublishNewsCommand:ICommand
    {
        public Guid NewsId { get; }

        public PublishNewsCommand(Guid newsId)
      {
          NewsId = newsId;
      }
        
    }
}
