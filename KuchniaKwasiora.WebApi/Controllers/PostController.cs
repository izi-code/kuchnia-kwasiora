using KuchniaKwasiora.Domain.DTOs;
using KuchniaKwasiora.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace KuchniaKwasiora.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpPost]
        public ActionResult<long> Post([FromBody] PostDto post)
        {
            return Ok(_postService.Create(post));
        }
    }
}
