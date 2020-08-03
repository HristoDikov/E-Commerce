using E_Commerce.Data;
using E_Commerce.Dtos;
using E_Commerce.InputModels;
using E_Commerce.Models;
using E_Commerce.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        public ProductDto GetProductById(int id)
        {
            return this.db.Products
                .Select(p => new ProductDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price.ToString(),
                    Image = p.Image,
                })
                .FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<ProductDto> GetProducts() 
        {
            return this.db.Products.Select(p => new ProductDto
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price.ToString(),
                Image = p.Image,
            })
                .ToList();
        }

        public string DeleteProduct(int id) 
        {
            var product = this.db.Products.FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                return "No such product!";
            }
            var productToBeDeleted = new Product { Id = id };

            this.db.Remove(product);
            db.SaveChanges();

            return "Deletion successful!";
        }
    }
}
