using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using MobileRecharge.Services;
using MobileRecharge.Models;

namespace MobileRecharge.Controllers
{
    [Route("api/recharge")]
    [ApiController]
    public class PrepaidController : ControllerBase
    {
        private PrepaidService prepaidService;
        public PrepaidController(PrepaidService _prepaidService)
        {
            prepaidService = _prepaidService;
        }

        [Produces("application/json")]
        [HttpGet("findnormalrecharge")]
        public IActionResult FindNormalRecharge()
        {
            try
            {
              return Ok(prepaidService.FindAllNormal());
            }
            catch
            {
                return BadRequest();
            };
        }

        [Produces("application/json")]
        [HttpGet("findspecialrecharge")]
        public IActionResult FindSpecialRecharge()
        {
            try
            {
                return Ok(prepaidService.FindAllSpecial());
            }
            catch
            {
                return BadRequest();
            };
        }

        [Consumes("application/json")]
        [Produces("application/json")]
        [HttpPost("createRechargeHistory")]
        public IActionResult CreateRechargeHistory([FromBody] RechargeHistory rechargeHistory)
        {
            try
            {
                return Ok(new
                {
                    result = prepaidService.CreateRechargeHistory(rechargeHistory)
                });
            }
            catch (Exception ex)
            {
                return BadRequest();
            };
        }

        [HttpPut("updateRechargeHistory/{id}")]
        public IActionResult UpdateRechargeHistory(string id)
        {
            try
            {
                return Ok(new
                {
                    result = prepaidService.UpdateRechargeHistory(id)
                });
            }
            catch (Exception ex)
            {
                return BadRequest();
            };
        }
    }
}
