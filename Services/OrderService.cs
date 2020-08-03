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

            switch (status.ToLower())
            {
                case "new":
                    order.Status = Status.New;
                    break;
                case "payment":
                    order.Status = Status.Payment;
                    break;
                case "delivery":
                    order.Status = Status.Delivery;
                    break;
                case "cancelled":
                    order.Status = Status.Cancelled;
                    break;
                case "completed":
                    order.Status = Status.Completed;
                        break;
                default:
                    order.Status = Status.New;
                    break;
            }

            this.db.SaveChanges();
            return $"The status was changed to {status}.";
        }

        public Order Create(List<int> ids, string username)
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

                if (product != null)
                {
                    products.Add(product);
                }

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

            order.TotalPrice *= exchangeRate;

            this.db.Orders.Add(order);
            this.db.SaveChanges();

            foreach (var p in products)
            {
                p.OrderId = order.Id;
            }

            this.db.Products.UpdateRange(products);
            this.db.SaveChanges();

            return order;
        }

        public List<OrderDto> UserOrders(string username)
        {
            var user = (ApplicationUser)this.db.Users.FirstOrDefault(u => u.UserName == username);

            if (user == null)
            {
                return new List<OrderDto>();
            }

            var exchangeRate = this.currencyService.GetCurrency(user.CurrencyCode);

            return this.db.Orders.Where(o => o.ApplicationUser.UserName == username)
                .Select(o => new OrderDto
                {
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
