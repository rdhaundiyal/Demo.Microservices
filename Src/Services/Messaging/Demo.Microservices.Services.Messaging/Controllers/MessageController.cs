using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Demo.Microservices.Core.Common;
using Demo.Microservices.Core.MessageQueue;
using Demo.Microservices.Services.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Microservices.Services.Messaging.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : BaseController
    {
        private IMessageQueueProvider _messageQueueProvider;
        public MessageController(IMessageQueueProvider messageQueueProvider)
        {
            _messageQueueProvider = messageQueueProvider;

        }
        [HttpGet("submit")]
        public IActionResult SubmitNews(News news)
        {
            _messageQueueProvider.Push(news);
            return Ok();
        }
        //This one move to the job as it will be a background task
        public ActionResult ApproveNews()
        {
            //here based on some rules pipeline, it will either accept or reject the new
            //if accept, it will call an endpoint which will then push the news to db as well as solr and then push an approve email to the queue back
            //if reject, it will send a rejection email to the sender

            throw new NotImplementedException();
        }

        //again this will be moved to a consumer
        public ActionResult SendNotification()
        {
            throw new NotImplementedException();
        }
    }
}