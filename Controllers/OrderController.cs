using E_Commerce.Dtos;
using E_Commerce.Models;
using E_Commerce.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace E_Commerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService orderService;

        public OrderController(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        [HttpPost]
        public ActionResult Create(List<int> ids)
        {
            string username = this.User.Identity.Name;
            Order order = this.orderService.Create(ids, username);

            //TODO DTO
            return Ok(order);
        }

        [HttpGet]
        [Route("GetUserOrders")]
        public ActionResult<ProductDto> GetUserOrders() 
        {
            string username = this.User.Identity.Name;

            var orders = orderService.UserOrders(username);

            return Ok(orders);
        }

        [HttpPut()]
        public ActionResult<ProductDto> ChangeOrderStatus(int id, string status)
        {
            var orders = orderService.ChangeOrderStatus(id, status);

            return Ok(orders);
        }
    }
}
