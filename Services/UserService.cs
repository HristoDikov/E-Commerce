using E_Commerce.Data;
using E_Commerce.InputModels;
using E_Commerce.Models;
using E_Commerce.Services.Contracts;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace E_Commerce.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext db;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public UserService(ApplicationDbContext db, UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            this.db = db;
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
        }

        public void Login(UserLoginModel userLoginModel)
        {
             signInManager.PasswordSignInAsync(userLoginModel.Username, userLoginModel.Password, true, false);
        }

        public void Register(UserRegistrationModel registerUser)
        {

            var ApplicationUser = new ApplicationUser()
            {
                UserName = registerUser.Username,
                CurrencyCode = registerUser.CurrencyCode,
            };

            userManager.CreateAsync(ApplicationUser, registerUser.Password);
            db.Users.Add(ApplicationUser);
            db.SaveChanges();
        }

    }
}
