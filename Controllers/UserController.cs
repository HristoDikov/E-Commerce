using E_Commerce.InputModels;
using E_Commerce.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpPost]
        [Route("Register")]
        public ActionResult Register(UserRegistrationModel registerUser)
        {
            this.userService.Register(registerUser);

            return this.Created($"/api/user/{registerUser.Username}", registerUser.Username);
        }

        [HttpPost]
        [Route("Login")]
        public ActionResult Login(UserLoginModel userLoginModel)
        {
           this.userService.Login(userLoginModel);

            var loggedType = this.User.Identity.AuthenticationType;
            var logged = this.User.Identity.IsAuthenticated;
            var smth = this.User.Identity.Name;

            return this.Accepted();
        }
    }
}
