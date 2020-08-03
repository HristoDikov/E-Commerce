using E_Commerce.InputModels;
using E_Commerce.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using RestSharp;

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

            return this.Accepted();
        }

        [HttpGet]
        public IActionResult Logout() 
        {
            this.userService.Logout();

            return this.Accepted();
        }
    }
}
