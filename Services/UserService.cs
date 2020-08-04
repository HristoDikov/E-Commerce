using E_Commerce.Data;
using E_Commerce.InputModels;
using E_Commerce.Models;
using E_Commerce.Services.Contracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System.Linq;

namespace E_Commerce.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext db;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly IJwtService jwtService;

        public UserService(ApplicationDbContext db, UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager, IJwtService jwtService)
        {
            this.db = db;
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.jwtService = jwtService;
        }

        public string Login(UserLoginModel userLoginModel)
        {
            var rsult = signInManager.PasswordSignInAsync(userLoginModel.Username, userLoginModel.Password, true, false).Result;
            if (rsult.Succeeded)
            {
                return jwtService.GenerateSecurityToken(userLoginModel.Username);
            }

            return "Incorrect username or password";
        }

        public string Register(UserRegistrationModel registerUser)
        {

            var ApplicationUser = new ApplicationUser()
            {
                UserName = registerUser.Username,
                CurrencyCode = registerUser.CurrencyCode,
            };

            userManager.CreateAsync(ApplicationUser, registerUser.Password);
            db.Users.Add(ApplicationUser);
            db.SaveChanges();

            return $"User with username {registerUser.Username} was registered.";
        }

        public void Logout()
        {
            this.signInManager.SignOutAsync();
        }

    }
}
