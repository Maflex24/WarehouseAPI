using Microsoft.AspNetCore.Mvc;

namespace WarehouseAPI.Controllers
{
    [Route("api/account")]
    public class AccountController : ControllerBase
    {
        [HttpPost("register")]
        public ActionResult Register()
        {
            // todo
            return StatusCode(501);
        }

        [HttpPost("login")]
        public ActionResult Login()
        {
            // todo
            return StatusCode(501);
        }
    }
}
