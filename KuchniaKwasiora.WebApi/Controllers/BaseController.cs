using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Mvc;

namespace KuchniaKwasiora.WebApi.Controllers
{
    public class BaseController : ControllerBase
    {
        protected new IActionResult Ok()
        {
            return base.Ok();
        }

        protected IActionResult Ok<T>(T result)
        {
            return base.Ok(result);
        }

        protected IActionResult FromResult(Result result)
        {
            if (result.IsSuccess)
                return Ok();

            return BadRequest(result.Error);
        }

        protected IActionResult FromResult<T>(Result<T> result)
        {
            if (result.IsSuccess)
                return Ok(result.Value);

            return BadRequest(result.Error);
        }
    }
}