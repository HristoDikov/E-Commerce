using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace E_Commerce.Models
{
    public class Order
    {
        public Order()
        {
            this.Products = new HashSet<Product>();
        }

        public int Id { get; set; }

        public decimal TotalPrice { get; set; }

        public string Status { get; set; }

        public DateTime CreatedAt { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

        public string ApplicationUserId { get; set; }

        public virtual IEnumerable<Product> Products { get; set; }
    }
}
