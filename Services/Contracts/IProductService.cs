using E_Commerce.Dtos;
using E_Commerce.InputModels;
using System.Collections.Generic;

namespace E_Commerce.Services.Contracts
{
    public interface IProductService
    {
         string Create(ProductCreationalModel productCreationalModel);

         ProductDto GetProductById(int Id);

        IEnumerable<ProductDto> GetProducts();

        public string DeleteProduct(int id);
    }
}
