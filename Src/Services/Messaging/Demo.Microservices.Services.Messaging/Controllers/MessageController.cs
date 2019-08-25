using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Demo.Microservices.Core.Common;
using Demo.Microservices.Core.Handlers;
using Demo.Microservices.Core.MessageQueue;
using Demo.Microservices.Services.Entities;
using Demo.Microservices.Services.Messaging.Commands;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Microservices.Services.Messaging.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : BaseController
    {

        private readonly Messages _messages;
        public MessageController(Messages messages)
        {
            _messages = messages;

        }
        [HttpGet("submit")]
        public IActionResult SubmitNews(News news)
        {
            var publishNewsCommand = new PublishNewsCommand()
            {
                Details = news.Details,
                Title = news.Title,
                SourceId = news.SourceId,
                PublishDate=DateTime.Now
            };
            var result = _messages.Dispatch(publishNewsCommand);
            return FromResult(result);
        }

    }
}