using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using MobileRecharge.Services;
using MobileRecharge.Models;

namespace MobileRecharge.Controllers
{
    [Route("api/postpaid")]
    [ApiController]
    public class PostPaidController : ControllerBase
    {
        private PostPaidService postPaidService;
        public PostPaidController(PostPaidService _postPaidService)
        {
            postPaidService = _postPaidService;
        }

        [Produces("application/json")]
        [HttpGet("findpostpaid")]
        public IActionResult FindPostPaid()
        {
            try
            {
              return Ok(postPaidService.FindAll());
            }
            catch
            {
                return BadRequest();
            };
        }


        [Consumes("application/json")]
        [Produces("application/json")]
        [HttpPost("createPostPaidHistory")]
        public IActionResult CreatePostPaidHistory([FromBody] PostPaidHistory postPaidHistory)
        {
            try
            {
                return Ok(new
                {
                    result = postPaidService.CreatePostPaidHistory(postPaidHistory)
                });
            }
            catch (Exception ex)
            {
                return BadRequest();
            };
        }

        [HttpPut("updatePostPaidHistory/{id}")]
        public IActionResult UpdatePostPaidHistory(string id)
        {
            try
            {
                return Ok(new
                {
                    result = postPaidService.UpdatePostPaidHistory(id)
                });
            }
            catch (Exception ex)
            {
                return BadRequest();
            };
        }
    }
}
