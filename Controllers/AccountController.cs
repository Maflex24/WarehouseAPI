using Microsoft.AspNetCore.Mvc;
using WarehouseAPI.Services;

namespace WarehouseAPI.Controllers
{
    [Route("api/account")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("register")]
        public ActionResult Register()
        {
            _accountService.Test();
            return Ok();
        }

        [HttpPost("login")]
        public ActionResult Login()
        {
            // todo
            return StatusCode(501);
        }
    }
}
