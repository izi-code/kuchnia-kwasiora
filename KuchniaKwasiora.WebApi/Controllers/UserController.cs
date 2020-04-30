using KuchniaKwasiora.Domain.DTOs;
using KuchniaKwasiora.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace KuchniaKwasiora.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public ActionResult<long> Post([FromBody] UserDto user)
        {
            return Ok(_userService.Create(user));
        }
    }
}
