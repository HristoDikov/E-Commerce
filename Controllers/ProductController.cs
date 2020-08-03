using E_Commerce.Dtos;
using E_Commerce.InputModels;
using E_Commerce.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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

        [HttpGet("{id}")]
        public ActionResult<ProductDto> GetProductById(int id)
        {
            ProductDto product = this.productService.GetProductById(id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpGet]
        public IEnumerable<ProductDto> GetProducts() 
        {
            return this.productService.GetProducts();
        }

        [HttpDelete("{Id}")]
        public IActionResult Delete(int id)
        {
            string msg = this.productService.DeleteProduct(id);

            if (msg == null)
            {
                return BadRequest("No such product.");
            }
            return Ok(msg);
        }
    }
}
