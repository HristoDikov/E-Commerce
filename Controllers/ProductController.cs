using E_Commerce.Dtos;
using E_Commerce.InputModels;
using E_Commerce.Models;
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
        [Authorize(AuthenticationSchemes = "Bearer")]
        public ActionResult<ProductDto> Create(ProductCreationalModel product)
        {
            var msg = this.productService.Create(product);

            return this.Created($"/api/product/{product.Name}", msg);
        }

        [HttpGet]
        [Route("GetProductById")]
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

        [HttpDelete]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public IActionResult Delete(int id)
        {
            var user = this.User.Identity.Name;
            string msg = this.productService.DeleteProduct(id);

            if (msg == null)
            {
                return BadRequest("No such product.");
            }
            return Ok(msg);
        }
    }
}
