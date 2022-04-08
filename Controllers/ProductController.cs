using Microsoft.AspNetCore.Mvc;
using WarehouseAPI.Entities;
using WarehouseAPI.Models;
using WarehouseAPI.Services;

namespace WarehouseAPI.Controllers
{
    [Route("api/product")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService ProductService)
        {
            _productService = ProductService;
        }

        [HttpGet]
        public ActionResult<List<ProductModelDto>> GetAll([FromQuery] int resultsAmount, [FromQuery] bool isWarehouseQuery)
        {
            var products = _productService.GetProducts(resultsAmount, isWarehouseQuery);

            if (products == null)
                return NotFound();

            return Ok(products);
        }
    }
}
