using System.ComponentModel.DataAnnotations;

namespace E_Commerce.InputModels
{
    public class UserRegistrationModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string CurrencyCode { get; set; }
    }
}
