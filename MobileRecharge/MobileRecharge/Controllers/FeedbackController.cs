using Microsoft.AspNetCore.Mvc;
using MobileRecharge.Models;
using MobileRecharge.Services;

namespace MobileRecharge.Controllers
{
    [Route("api/feedback")]
    public class FeedbackController : Controller
    {
        private FeedbackService feedbackService;
        public FeedbackController(FeedbackService _feedbackService)
        {
            feedbackService = _feedbackService;
        }
        [Consumes("application/json")]
        [Produces("application/json")]
        [HttpPost("add")]
        public IActionResult Add([FromBody] Feedback feedback)
        {
            try
            {
                return Ok(new
                {
                    Result = feedbackService.Create(feedback)
                });
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
