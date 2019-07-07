﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Demo.Microservices.Services.News.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Microservices.Services.News.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController :  ControllerBase
    {
        INewsRepository _newsRepository;
        public NewsController(INewsRepository newsRepository) => _newsRepository = newsRepository;

        [HttpGet]
        public ActionResult<IEnumerable<News.Entities.News>> Get()
        {
            return _newsRepository.GetAll().ToList();
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