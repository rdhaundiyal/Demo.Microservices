using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Demo.Microservices.Core.Messages;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Microservices.Services.NewsService.Controllers
{
    public class BaseController : Controller
    {
        protected new IActionResult Ok()
        {
            return base.Ok(ResponseMessage.Ok());
        }

        protected IActionResult Ok<T>(T result)
        {
            return base.Ok(ResponseMessage.Ok(result));
        }

        protected IActionResult Error(string errorMessage)
        {
            return BadRequest(ResponseMessage.Error(errorMessage));
        }

        protected IActionResult FromResult(ResponseMessage result)
        {
            return result.IsSuccess ? Ok() : Error(result.Error);
        }
    }
}