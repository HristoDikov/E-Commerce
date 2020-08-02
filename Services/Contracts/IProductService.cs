using E_Commerce.Dtos;
using E_Commerce.InputModels;

namespace E_Commerce.Services.Contracts
{
    public interface IProductService
    {
        public void Create(ProductCreationalModel productCreationalModel);

        public ProductDto GetProductById(int Id);
    }
}
