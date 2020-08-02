using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace E_Commerce.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            this.Orders = new HashSet<Order>();
        }

        public string CurrencyCode { get; set; }

        public virtual IEnumerable<Order> Orders { get; set; }
    }
}
