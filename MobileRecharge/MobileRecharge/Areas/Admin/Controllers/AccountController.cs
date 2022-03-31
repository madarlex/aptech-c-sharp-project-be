using Microsoft.AspNetCore.Mvc;
using MobileRecharge.Services;

namespace MobileRecharge.Areas.Admin.Controllers
{
    [Route("api/admin/account")]
    public class AccountController : Controller
    {
        private readonly AccountService accountService;
        public AccountController(AccountService accountService)
        {
            this.accountService = accountService;
        }

        [Produces("application/json")]
        [HttpGet("getAllAccounts")]
        public IActionResult GetAllAccounts()
        {
            try
            {
                return Ok(accountService.GetAllAccounts());
            } catch 
            {
                return BadRequest();
            }
        }

        [Produces("application/json")]
        [HttpGet("getAccountById/{id}")]
        public IActionResult GetAccountById(int id)
        {
            try
            {
                var account = accountService.GetAccountById(id);
                return Ok(account);
            } catch
            {
                return NotFound();
            }
        }

        [Produces("application/json")]
        [HttpGet("getRechargeHistory/{accountId}")]
        public IActionResult GetRechargeHistoryList(int accountId)
        {
            try
            {
                var rechargeHistoryList = accountService.GetRechargeHistoryById(accountId);
                return Ok(rechargeHistoryList);
            } catch
            {
                return BadRequest();
            }
        }

        [Produces("application/json")]
        [HttpGet("getPostpaidHistoryList/{accountId}")]
        public IActionResult GetPostPaidHistoryList(int accountId)
        {
            try
            {
                var postpaidHistoryList = accountService.GetPostPaidHistoryById(accountId);
                return Ok(postpaidHistoryList);
            } catch
            {
                return BadRequest();
            }
        }
    }
}
