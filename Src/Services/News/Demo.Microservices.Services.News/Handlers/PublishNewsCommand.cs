using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using Demo.Microservices.Services.NewsService.Entities;

namespace Demo.Microservices.Services.NewsService.Handlers
{
    public class PublishNewsCommand:ICommand
    {
       Guid newsId { get; set; }
        
    }
}
