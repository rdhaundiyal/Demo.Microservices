using System;
using AutoMapper;
using Demo.Microservices.Services.NewsService.Service;
using Demo.Microservices.Services.NewsService.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Demo.Microservices.Core.Common;


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

        //[HttpGet("{count}")]
        //public IActionResult GetTopNews(int newsCount=5)
        //{
        //    throw  new NotImplementedException();
        //}

        //[HttpGet("search/{count}")]
        //public IActionResult Search(int newsCount = 5)
        //{
        //    throw new NotImplementedException();
        //}



        // POST api/values
        [HttpPost("approve/{newsId}")]
        public IActionResult Approve([FromBody] string value)
        {
            throw  new NotImplementedException();
        }

      
    }
}