using Microsoft.AspNetCore.Mvc;
using MobileRecharge.Models;
using MobileRecharge.Services;
using System.Diagnostics;

namespace MobileRecharge.Areas.Admin.Controllers
{
    [Route("api/admin/recharges")]
    public class RechargeController : Controller
    {
        private readonly RechargeService rechargeService;

        public RechargeController(RechargeService rechargeService)
        {
            this.rechargeService = rechargeService;
        }

        [Produces("application/json")]
        [HttpGet("getRecharges")]
        public IActionResult getRecharges()
        {
            try
            {
                var recharges = rechargeService.GetRecharges();
                return Ok(recharges);
            } catch
            {
                return BadRequest();
            }
        }

        [Produces("application/json")]
        [HttpGet("getRechargeById/{id}")]
        public IActionResult getRechargeById(int id)
        {
            try
            {
                var recharge = rechargeService.GetRechargeById(id);
                return Ok(recharge);
            } catch
            {
                return BadRequest();
            }
        }

        [Produces("application/json")]
        [HttpGet("getRechargeTypes")]
        public IActionResult getRechargeType()
        {
            try
            {
                var rechargeTypesList = rechargeService.GetRechargeTypes();
                return Ok(rechargeTypesList);
            } catch
            {
                return BadRequest();
            }
        }

        [Produces("application/json")]
        [HttpGet("getRechargeHistories")]
        public IActionResult getRechargeHistories()
        {
            try
            {
                var rechargeHistories = rechargeService.GetRechargeHistories();
                return Ok(rechargeHistories);
            }
            catch
            {
                return BadRequest();
            }
        }

        [Consumes("application/json")]
        [HttpPost("create")]
        public IActionResult createRechargeType([FromBody] Recharge recharge)
        {
            try
            {
                rechargeService.createRecharge(recharge);
                return Ok();
            } catch
            {
                return BadRequest();
            }
        }

        [Produces("application/json")]
        [HttpGet("getRechargeHistoryByRechargeId/{rechargeId}")]
        public IActionResult GetRechargeHistoryByRechargeId(int rechargeId)
        {
            try
            {
                var rechargeHistories = rechargeService.GetRechargeListByRechargeId(rechargeId);
                return Ok(rechargeHistories);
            } catch
            {
                return BadRequest();
            }
        }


        [Consumes("application/json")]
        [HttpPut("update/{id}")]
        public IActionResult updateRecharge(int id, [FromBody] Recharge recharge)
        {
            try
            {
                if(id == 0)
                {
                    return NotFound();
                } else if (id != recharge.Id)
                {
                    return NotFound();
                } else
                {
                    var result = this.rechargeService.updateRecharge(recharge, id);
                    if(result)
                    {
                        return Ok();
                    }
                    else return NotFound();
                }
                
            } catch
            {
                return BadRequest();
            }
        }
    }
}
