using E_Commerce.Data;
using E_Commerce.Dtos;
using E_Commerce.Enums;
using E_Commerce.Models;
using E_Commerce.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce.Services
{
    public class OrderService : IOrderService
    {
        private readonly ApplicationDbContext db;
        private readonly ICurrencyService currencyService;

        public OrderService(ApplicationDbContext db, ICurrencyService currencyService)
        {
            this.db = db;
            this.currencyService = currencyService;
        }

        public string ChangeOrderStatus(int id, string status)
        {
            var order = this.db.Orders.FirstOrDefault(o => o.Id == id);

            if (order == null)
            {
                return null;
            }

            order.Status = (status.ToLower()) switch
            {
                "new" => Status.New,
                "payment" => Status.Payment,
                "delivery" => Status.Delivery,
                "cancelled" => Status.Cancelled,
                "completed" => Status.Completed,
                _ => Status.New,
            };

            this.db.SaveChanges();
            return $"The status was changed to {status}.";
        }

        public OrderDto Create(List<int> ids, string username)
        {
            List<Product> products = new List<Product>();
            var user = (ApplicationUser)this.db.Users.FirstOrDefault(u => u.UserName == username);

            var userCurrency = user.CurrencyCode;

            foreach (var id in ids)
            {
                var product = this.db.Products.Select(p => new Product
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    Image = p.Image,
                })
                    .FirstOrDefault(p => p.Id == id);

                if (product != null || product.OrderId == 0)
                {
                    products.Add(product);
                }
            }

            if (products.Count < 1)
            {
                return null;
            }

            

            Order order = new Order()
            {
                ApplicationUserId = user.Id,
                Status = Status.New,
                CreatedAt = DateTime.UtcNow,
            };

            foreach (var product in products)
            {
                order.TotalPrice += product.Price;
            }

            var exchangeRate = this.currencyService.GetCurrency(userCurrency);

            if (exchangeRate == 0)
            {
                return null;
            }

            order.TotalPrice *= exchangeRate;

            this.db.Orders.Add(order);
            this.db.SaveChanges();

            foreach (var p in products)
            {
                p.OrderId = order.Id;
            }

            this.db.Products.UpdateRange(products);
            this.db.SaveChanges();

            OrderDto orderDtos = new OrderDto
            {
                Id = order.Id,
                OrderPrice = order.TotalPrice * exchangeRate,
                Status = order.Status.ToString(),
                CreatedAt = order.CreatedAt.ToString(),
                Products = order.Products.Select(p => new ProductDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price.ToString(),
                    Image = p.Image,
                }).ToList(),
            };

            return orderDtos;
        }

        public List<OrderDto> UserOrders(string username)
        {
            var user = (ApplicationUser)this.db.Users.FirstOrDefault(u => u.UserName == username);

            if (user == null)
            {
                return null;
            }

            var exchangeRate = this.currencyService.GetCurrency(user.CurrencyCode);

            return this.db.Orders.Where(o => o.ApplicationUser.UserName == username)
                .Select(o => new OrderDto
                {Id = o.Id,
                    OrderPrice = o.TotalPrice,
                    Status = o.Status.ToString(),
                    CreatedAt = o.CreatedAt.ToString(),
                    Products = o.Products.Select(p => new ProductDto
                    {
                        Id = p.Id,
                        Name = p.Name,
                        Image = p.Image,
                        Price = (p.Price * exchangeRate).ToString(),
                    })
                .ToList(),

                })
                .ToList();
        }
    }
}
