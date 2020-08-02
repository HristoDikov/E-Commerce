namespace E_Commerce.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Image { get; set; }

        public int? OrderId { get; set; }

        public virtual Order Order { get; set; }
    }
}
