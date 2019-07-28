using CSharpFunctionalExtensions;
using Demo.Microservices.Core.Messages;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Microservices.Core.Common
{
 public abstract   class BaseController : Controller
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

        protected IActionResult FromResult(Result result)
        {
            return result.IsSuccess ? Ok() : Error(result.Error);
        }
    }
}
