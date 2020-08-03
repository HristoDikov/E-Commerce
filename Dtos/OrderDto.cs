using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce.Dtos
{
    public class OrderDto
    {
        [DisplayName("Order total price")]
        public decimal OrderPrice { get; set; }

        [DisplayName("Order status")]
        public string Status { get; set; }

        [DisplayName("Order created at")]
        public string CreatedAt{ get; set; }

        public List<ProductDto> Products { get; set; }
    }
}
