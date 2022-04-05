using Microsoft.AspNetCore.Mvc;

namespace WarehouseAPI.Controllers
{
    [Route("api/product")]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        public ActionResult GetAll()
        {
            // todo
            return StatusCode(501);
        }
    }
}
