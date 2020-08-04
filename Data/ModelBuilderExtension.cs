using E_Commerce.Models;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Data
{
    public static class ModelBuilderExtension
    {
        public static void Seed(this ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<Product>().HasData(
                    new Product
                    {
                        Id = 1,
                        Name = "Rubberised Print T-Shirt",
                        Price = 9.99m,
                        Image = "https://st.depositphotos.com/2251265/4803/i/450/depositphotos_48037605-stock-photo-man-wearing-t-shirt.jpg"
                    },
                     new Product
                     {
                         Id = 2,
                         Name = "Contrast Top TRF",
                         Price = 11.99m,
                         Image = "https://picture-cdn.wheretoget.it/tvrznj-i.jpg"
                     },

                     new Product
                     {
                         Id = 3,
                         Name = "Tied Leather Heeled Sandals",
                         Price = 49.95m,
                         Image = "https://celticandco.global.ssl.fastly.net/usercontent/img/col-12/69602.jpg"
                     },

                   new Product
                   {
                       Id = 4,
                       Name = "Leather High Heel Sandals With Gathering",
                       Price = 39.95m,
                       Image = "https://cf.shopee.com.my/file/36df2e1d04ca103f16ccefffa9927728"
                   },

                   new Product
                   {
                       Id = 5,
                       Name = "Pleated Palazzo Trousers TRF",
                       Price = 29.95m,
                       Image = "https://cf.shopee.ph/file/fecc650ca5802d709890a66cc00cfe23"
                   },

                   new Product
                   {
                       Id = 6,
                       Name = "Skinny Trousers With Belt",
                       Price = 19.99m,
                       Image = "https://emma.bg/images/products/damski-pantalon-faded-black-super-skinny-trousers-1.jpg"
                   });
        }
    }
}
