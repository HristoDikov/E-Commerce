using Microsoft.EntityFrameworkCore.Migrations;

namespace E_Commerce.Migrations
{
    public partial class SeedProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Image", "Name", "OrderId", "Price" },
                values: new object[,]
                {
                    { 1, "https://st.depositphotos.com/2251265/4803/i/450/depositphotos_48037605-stock-photo-man-wearing-t-shirt.jpg", "Rubberised Print T-Shirt", null, 9.99m },
                    { 2, "https://picture-cdn.wheretoget.it/tvrznj-i.jpg", "Contrast Top TRF", null, 11.99m },
                    { 3, "https://celticandco.global.ssl.fastly.net/usercontent/img/col-12/69602.jpg", "Tied Leather Heeled Sandals", null, 49.95m },
                    { 4, "https://cf.shopee.com.my/file/36df2e1d04ca103f16ccefffa9927728", "Leather High Heel Sandals With Gathering", null, 39.95m },
                    { 5, "https://cf.shopee.ph/file/fecc650ca5802d709890a66cc00cfe23", "Pleated Palazzo Trousers TRF", null, 29.95m },
                    { 6, "https://emma.bg/images/products/damski-pantalon-faded-black-super-skinny-trousers-1.jpg", "Skinny Trousers With Belt", null, 19.99m }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);
        }
    }
}
