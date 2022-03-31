using Microsoft.AspNetCore.Mvc;
using MobileRecharge.Services;

namespace MobileRecharge.Areas.Admin.Controllers
{
    [Route("api/admin/feedback")]
    public class FeedbackController : Controller
    {
        private readonly FeedbackService feedbackService;
        public FeedbackController(FeedbackService feedbackService)
        {
            this.feedbackService = feedbackService;  
        }
        [Produces("application/json")]
        [HttpGet("getFeedbacks")]
        public IActionResult GetFeedbacks()
        {
            try
            {
                var feedbacks = feedbackService.GetFeedbacks(); 
                return Ok(feedbacks);
            } catch
            {
                return BadRequest();
            }
        }

        [Produces("application/json")]
        [HttpGet("getFeedbackById/{id}")]
        public IActionResult GetFeedbackById(int id)
        {
            try
            {
                var feedback = feedbackService.GetFeedback(id);
                return Ok(feedback);
            } catch
            {
                return BadRequest();
            }
        }
    }
}
