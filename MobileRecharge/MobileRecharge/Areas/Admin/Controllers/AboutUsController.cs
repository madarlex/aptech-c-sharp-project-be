using Microsoft.AspNetCore.Mvc;
using MobileRecharge.Models;
using MobileRecharge.Services;

namespace MobileRecharge.Areas.Admin.Controllers
{
    [Route("api/admin/aboutus")]
    public class AboutUsController : Controller
    {

        private readonly AboutUsService _aboutUsService;
        public AboutUsController(AboutUsService aboutUsService)
        {
            _aboutUsService = aboutUsService;
        }
        [Produces("application/json")]
        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            try
            {
                var aboutUsList = _aboutUsService.GetAll();
                return Ok(aboutUsList);
            } catch
            {
                return BadRequest();
            }
        }

        [Produces("application/json")]
        [HttpGet("getAboutUsByID/{id}")]
        public IActionResult getAboutUsByID(int id)
        {
            try
            {
                var aboutUs = _aboutUsService.ShowContentById(id);
                return Ok(aboutUs);
            }
            catch
            {
                return BadRequest();
            }
        }

        [Consumes("application/json;charset=utf8")]
        [HttpPost("create")]
        public IActionResult CreateConent([FromBody] AboutU aboutus)
        {
            try
            {
                _aboutUsService.GetContent(aboutus.Maincontent);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
