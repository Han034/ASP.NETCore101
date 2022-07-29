using ASP.NETCore101.Models;
using ASP.NETCore101.Services;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NETCore101.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        //api çağırma kısmı
        public ProductsController(JsonFileProductService productService) 
        {
            this.ProductService = productService;

        }
        public JsonFileProductService ProductService { get; }
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return ProductService.GetProducts(); 
        }

        //[HttpPatch] "[FromBody]"
        //Api üzerinden rating ekleyebilme
        //https://localhost:7254/products/rate?ProductId=jenlooper-cactus&Rating=5
        [Route("Rate")]
        [HttpGet]
        public ActionResult Get(
            [FromQuery]string ProductId,
            [FromQuery] int Rating)
        {
            ProductService.AddRating(ProductId, Rating);
                return Ok();
        }
        
        //public ActionResult Login()
        //{
        //   return0
        //}
    }
}
