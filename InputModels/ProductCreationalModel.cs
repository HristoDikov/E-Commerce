using System.ComponentModel.DataAnnotations;

namespace E_Commerce.InputModels
{
    public class ProductCreationalModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public string Image { get; set; }
    }
}
