using Microsoft.AspNetCore.Mvc;
using MobileRecharge.Models;
using MobileRecharge.Services;
using System.Diagnostics;
using System.Globalization;
using System.Net;
using System.Net.Mail;

namespace MobileRecharge.Controllers
{
    [Route("api/account")]
    public class AccountController : Controller
    {
        private AccountService accountService;
        public AccountController(AccountService _accountService)
        {
            accountService = _accountService;
        }
        [Produces("application/json")]
        [HttpGet("findall")]
        public IActionResult FindAll()
        {
            try
            {
                return Ok(accountService.FindAll());
            }
            catch
            {
                return BadRequest();
            }
        }

        [Consumes("application/json")]
        [Produces("application/json")]
        [HttpPost("add")]
        public IActionResult Add([FromBody] Account account)
        {
            try
            {
                if (!accountService.CheckUniqueEmail(account.Email))
                {
                    string token = Convert.ToBase64String(Guid.NewGuid().ToByteArray());
                    if (token.Contains('/'))
                    {
                        token = token.Replace('/', 'a');
                    }
                    string message = "Account registration confirmation code: " + token;
                    SendEmail(account.Email, "Confirm account creation", message);
                    account.ActiveToken = token;
                    account.Password = BCrypt.Net.BCrypt.HashString(account.Password);
                    return Ok(new
                    {
                        Result = accountService.Create(account)
                    });
                }
                else
                {
                    return Ok(new
                    {
                        Result = false
                    });
                }
            }
            catch
            {
                return BadRequest();
            }
        }

        [Consumes("application/json")]
        [Produces("application/json")]
        [HttpGet("active/{email}/{token}")]
        public IActionResult Active(string email, string token)
        {
            try
            {
                return Ok(new
                {
                    Result = accountService.Active(email, token)
                });
            }
            catch
            {
                return BadRequest();
            }
        }

        [Consumes("application/json")]
        [Produces("application/json")]
        [HttpGet("changepass/{email}/{token}/{password}")]
        public IActionResult ChangePass(string email, string token, string password)
        {
            try
            {
                return Ok(new
                {
                    Result = accountService.ChangePass(email, token, password)
                });
            }
            catch
            {
                return BadRequest();
            }
        }

        [Consumes("application/json")]
        [Produces("application/json")]
        [HttpGet("forgot/{email}")]
        public IActionResult Forgot(string email)
        {
            string token = Convert.ToBase64String(Guid.NewGuid().ToByteArray());
            if (token.Contains('/'))
            {
                token = token.Replace('/', 'a');
            }
            string message = "Password Reset Confirmation Code: " + token;
            SendEmail(email, "Reset Password", message);
            try
            {
                return Ok(new
                {
                    Result = accountService.Forgot(email, token)
                });
            }
            catch
            {
                return BadRequest();
            }
        }

        [Consumes("application/json")]
        [Produces("application/json")]
        [HttpGet("login/{email}/{password}")]
        public IActionResult Login(string email, string password)
        {
            var account = accountService.Login(email, password);
            try
            {
                if(account != null)
                {
                    return Ok(new
                    {
                        name = account.Name,
                        accountId = account.Id,
                        accountType = account.AccountType.Id
                    });
                }
                else
                {
                    return Ok(new
                    {
                        Result = false
                    });
                }
            }
            catch
            {
                return BadRequest();
            }
        }

        [Consumes("application/json")]
        [Produces("application/json")]
        [HttpGet("edit/{id}")]
        public IActionResult Edit(int id)
        {
            var account = accountService.Find(id);
            try
            {
                return Ok(new
                {
                    Id = account.Id,
                    Name = account.Name,
                    Address = account.Address,
                    Dob = account.Dob,
                    Gender = account.Gender,
                    Password = account.Password,
                    IdentityCard = account.IdentityCard,
                    Phone = account.Phone,
                    Email = account.Email
                });
            }
            catch
            {
                return BadRequest();
            }
        }

        [Consumes("application/json")]
        [Produces("application/json")]
        [HttpGet("find/{id}")]
        public IActionResult Find(int id)
        {
            var account = accountService.Find(id);
            try
            {
                return Ok(new
                {
                    Id = account.Id,
                    Name = account.Name,
                    Address = account.Address,
                    Dob = account.Dob,
                    Gender = account.Gender,
                    Password = account.Password,
                    IdentityCard = account.IdentityCard,
                    Phone = account.Phone,
                    Email = account.Email
                });
            }
            catch
            {
                return BadRequest();
            }
        }

        [Consumes("application/json")]
        [Produces("application/json")]
        [HttpPost("update")]
        public IActionResult Update([FromBody] Account account)
        {
            var currentAccount = accountService.Find(account.Id);
            try
            {
                currentAccount.Gender = account.Gender;
                currentAccount.Name = account.Name;
                currentAccount.Phone = account.Phone;
                if (!string.IsNullOrEmpty(account.Password))
                {
                    currentAccount.Password = BCrypt.Net.BCrypt.HashString(account.Password);
                }
                currentAccount.IdentityCard = account.IdentityCard;
                currentAccount.Address = account.Address;
                currentAccount.Dob = account.Dob;
                accountService.Update(currentAccount);
                return Ok(new
                {
                    Result = true
                });
            }
            catch
            {
                return BadRequest();
            }
        }

        public static void SendEmail(string email, string subject, string body)
        {
            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress("annguyen29.k44@st.ueh.edu.vn");
                mail.To.Add(email);
                mail.Subject = subject;
                mail.Body = body;
                mail.IsBodyHtml = true;
                //mail.Attachments.Add(new Attachment("D:\\TestFile.txt"));//--Uncomment this to send any attachment  
                using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtp.Credentials = new NetworkCredential("annguyen29.k44@st.ueh.edu.vn", "olfhrfofnfzxjqlu");
                    smtp.EnableSsl = true;
                    smtp.Send(mail);
                }
            }
        }
    }
}
