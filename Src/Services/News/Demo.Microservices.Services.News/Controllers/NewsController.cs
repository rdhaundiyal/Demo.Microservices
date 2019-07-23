using System;
using System.Collections.Generic;
using AutoMapper;
using Demo.Microservices.Core.Messages;
using Demo.Microservices.Services.NewsService.Entities;
using Demo.Microservices.Services.NewsService.Service;
using Demo.Microservices.Services.NewsService.ViewModels;
using Microsoft.AspNetCore.Mvc;



namespace Demo.Microservices.Services.NewsService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : BaseController
    {
        private readonly INewsService _newsService;
        private readonly IMapper _mapper;
        public NewsController(INewsService newsService, IMapper mapper)
        {
            _newsService = newsService;
            _mapper = mapper;
        }

        [HttpGet("{newsId}")]
        public IActionResult Get(Guid newsId)
        {
            var news = _newsService.GetNews(newsId);

            var newsViewmodel = _mapper.Map<NewsViewModel>(news);
            return Ok(newsViewmodel);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}