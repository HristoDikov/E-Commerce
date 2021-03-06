﻿using E_Commerce.Data;
using E_Commerce.Dtos;
using E_Commerce.InputModels;
using E_Commerce.Models;
using E_Commerce.Services.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace E_Commerce.Services
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext db;

        public ProductService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public string Create(ProductCreationalModel productInput)
        {
            Product product = new Product
            {
                Name = productInput.Name,
                Price = productInput.Price,
                Image = productInput.Image,
            };

            this.db.Products.Add(product);
            this.db.SaveChanges();

            ProductDto productDto = new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price.ToString(),
                Image = product.Image
            };

            return $"Product {product.Name} with Id: {product.Id} was succesfully created!";
        }

        public ProductDto GetProductById(int id)
        {
            ProductDto pDto = this.db.Products
                .Select(p => new ProductDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price.ToString(),
                    Image = p.Image,
                })
                .FirstOrDefault(p => p.Id == id);

            if (pDto == null)
            {
                return null;
            }

            return pDto;
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
            Product product = this.db.Products.FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                return null;
            }

            Product productToBeDeleted = new Product { Id = id };

            this.db.Remove(product);
            db.SaveChanges();

            return "Deletion successful!";
        }
    }
}
