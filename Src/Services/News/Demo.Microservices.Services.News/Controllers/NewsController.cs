using System;
using System.Collections.Generic;
using Demo.Microservices.Core.Messages;
using Demo.Microservices.Services.NewsService.Entities;
using Demo.Microservices.Services.NewsService.Service;
using Microsoft.AspNetCore.Mvc;



namespace Demo.Microservices.Services.NewsService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController :  ControllerBase
    {
        private readonly INewsService _newsService;
       
        public NewsController(INewsService newsService) => _newsService = newsService;

        [HttpGet]
        public IActionResult Get(Guid newsId)
        {
            var news = _newsService.GetNews(newsId);
            //map the newsentity to view model in either service or here
            return Ok(news);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // GET api/values/5
        
     
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