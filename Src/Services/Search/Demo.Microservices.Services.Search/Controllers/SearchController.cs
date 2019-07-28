using System;
using Demo.Microservices.Core.Common;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Microservices.Services.Search.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : BaseController
    {
        [HttpGet("{count}")]
        public IActionResult GetTopNews(int count)
        {
            throw new NotImplementedException();
        }

        [HttpGet("search/{keyword}")]
        public IActionResult Search(string keyWord)
        {
            throw new NotImplementedException();
        }
    }
}