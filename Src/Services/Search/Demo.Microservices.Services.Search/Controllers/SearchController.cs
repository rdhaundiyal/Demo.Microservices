using System;
using AutoMapper;
using Demo.Microservices.Core.Common;
using Demo.Microservices.Services.Search.Service;
using Demo.Microservices.Services.Search.ViewModels;
using Microsoft.AspNetCore.Mvc;
using SolrNet.Exceptions;

namespace Demo.Microservices.Services.Search.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : BaseController
    {


        private readonly ISearchService _searchService;
        private readonly IMapper _mapper;
       

        public SearchController(ISearchService searchService, IMapper mapper)
        {
            _searchService = searchService;
            _mapper = mapper;
        }
        [HttpGet("{count}")]
        public IActionResult GetTopNews(int count)
        {
            try
            {

            }
            catch (InvalidFieldException)

            {
            }

            var news = _searchService.GetNews(count);
            var newsViewmodel = _mapper.Map<NewsListViewModel>(news);
            return Ok(newsViewmodel);
        }

        [HttpGet("search/{keyword}")]
        public IActionResult Search(string keyWord)
        {
            var news = _searchService.Search(keyWord);
            var newsViewmodel = _mapper.Map<NewsListViewModel>(news);
            return Ok(newsViewmodel);
        }
    }
}