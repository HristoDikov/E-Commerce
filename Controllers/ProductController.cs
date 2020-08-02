using E_Commerce.InputModels;
using E_Commerce.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }
        [HttpPost]
        public ActionResult Create(ProductCreationalModel product)
        {
            this.productService.Create(product);

            return this.Created($"/api/product/{product.Name}", product.Name);
        }
    }
}
