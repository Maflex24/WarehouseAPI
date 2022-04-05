using Microsoft.AspNetCore.Mvc;

namespace WarehouseAPI.Controllers
{
    [Route("api/order")]
    public class OrderController : ControllerBase
    {
        [HttpPost]
        public ActionResult CreateNewOrder()
        {
            // todo
            return StatusCode(501);
        }
    }
}
