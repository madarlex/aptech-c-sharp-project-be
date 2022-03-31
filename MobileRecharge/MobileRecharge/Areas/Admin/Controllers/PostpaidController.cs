using Microsoft.AspNetCore.Mvc;
using MobileRecharge.Models;
using MobileRecharge.Services;

namespace MobileRecharge.Areas.Admin.Controllers
{
    [Route("api/admin/postpaid")]
    public class PostpaidController : Controller
    {
        private readonly PostpaidService postpaidService;
        public PostpaidController(PostpaidService postpaidService)
        {
            this.postpaidService = postpaidService; 
        }

        [Produces("application/json")]
        [HttpGet("getPostpaids")]
        public IActionResult GetPostpaids()
        {
            try
            {
                var postpaids = postpaidService.GetPostpaids();
                return Ok(postpaids);
            } catch
            {
                return BadRequest();    
            }
        }

        [Produces("application/json")]
        [HttpGet("getPostpaidHistories")]
        public IActionResult GetPostpaidHistories()
        {
            try
            {
                var postpaidHistories = postpaidService.GetPostPaidHistories();
                return Ok(postpaidHistories);
            }
            catch
            {
                return BadRequest();
            }
        }

        [Produces("application/json")]
        [HttpGet("getPostpaidHistoriesByPostpaidId/{postpaidId}")]
        public IActionResult GetPostpaidHistoriesByPostpaidId(int postpaidId)
        {
            try
            {
                var postpaidHistories = postpaidService.GetPostPaidHistoriesByPostpaidId(postpaidId);
                return Ok(postpaidHistories);
            }
            catch
            {
                return BadRequest();
            }
        }

        [Produces("application/json")]
        [HttpGet("getPostpaidById/{id}")]
        public IActionResult GetPostpaidById(int id)
        {
            try
            {
                var postpaid = postpaidService.GetPostpaidById(id);
                return Ok(postpaid);
            } catch
            {
                return NotFound();
            }
        }
        
        [Consumes("application/json")]
        [HttpPost("create")]
        public IActionResult Create([FromBody] PostPaid postPaid)
        {
            try
            {
                this.postpaidService.createPostpaid(postPaid);
                return Ok();
            } catch
            {
                return BadRequest();
            }
        }

        [Consumes("application/json")]
        [HttpPut("update/{id}")]
        public IActionResult Update(int id, [FromBody] PostPaid postPaid)
        {
            try
            {
                if (id == 0)
                {
                    return NotFound();
                }
                else if (id != postPaid.Id)
                {
                    return NotFound();
                }
                else
                {
                    var result = this.postpaidService.updatePostpaid(postPaid, id);
                    if (result)
                    {
                        return Ok();
                    }
                    else return NotFound();
                }

            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
