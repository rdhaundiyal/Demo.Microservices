using System;
using AutoMapper;
using Demo.Microservices.Core.Common;
using Demo.Microservices.Core.Handlers;
using Demo.Microservices.Services.Entities;
using Demo.Microservices.Services.Messaging.Commands;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Microservices.Services.Messaging.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : BaseController
    {

        private readonly Messages _messages;
        private readonly IMapper _mapper;
        public MessageController(Messages messages, IMapper mapper)
        {
            _messages = messages;
            _mapper = mapper;
        }
        [HttpGet("submit")]
        public IActionResult SubmitNews(News news)
        {


            var publishNewsCommand=_mapper.Map<PublishNewsCommand>(news);
              
            var result = _messages.Dispatch(publishNewsCommand);
            return FromResult(result);
        }

    }
}