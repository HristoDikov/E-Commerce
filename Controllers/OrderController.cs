using E_Commerce.Dtos;
using E_Commerce.Models;
using E_Commerce.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

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
        [Authorize(AuthenticationSchemes = "Bearer")]
        public ActionResult<OrderDto> Create(List<int> ids)
        {
            string username = this.User.Claims.First().Value;

            OrderDto order = this.orderService.Create(ids, username);

            if (order == null)
            {
                return NotFound();
            }

            return CreatedAtAction("Create", order);
        }

        [HttpGet]
        [Route("GetUserOrders")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public ActionResult<OrderDto> GetUserOrders() 
        {
            string username = this.User.Claims.First().Value;

            List<OrderDto> orders = orderService.UserOrders(username);

            if (orders == null)
            {
                return NotFound();
            }

            return Ok(orders);
        }

        [HttpPut]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public ActionResult<string> ChangeOrderStatus(int id, string status)
        {
            string message = orderService.ChangeOrderStatus(id, status);

            if (message == null)
            {
                return NotFound("Order does not exist!");
            }

            return Ok(message);
        }
    }
}
