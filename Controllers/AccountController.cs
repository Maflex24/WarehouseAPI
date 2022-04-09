using Microsoft.AspNetCore.Mvc;
using WarehouseAPI.Models;
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

        [HttpPost("register/client")]
        public ActionResult RegisterClient([FromBody] RegisterClientModelDto clientModel)
        {
            _accountService.RegisterClient(clientModel);
            return Ok();
        }

        [HttpPost("register/employee")]
        public ActionResult RegisterEmployee([FromBody] RegisterEmployeeModelDto employeeModel)
        {
            _accountService.RegisterEmployee(employeeModel);
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
