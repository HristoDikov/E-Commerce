using E_Commerce.Data;
using E_Commerce.InputModels;
using E_Commerce.Models;
using E_Commerce.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce.Services
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext db;

        public ProductService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void Create(ProductCreationalModel productInput)
        {
            var product = new Product
            {
                Name = productInput.Name,
                Price = productInput.Price,
                Image = productInput.Image,
            };

            this.db.Products.Add(product);
            this.db.SaveChanges();
        }
    }
}
