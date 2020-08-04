using E_Commerce.InputModels;
using E_Commerce.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Security.Claims;

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
            string msg = this.userService.Register(registerUser);

            return this.Created($"/api/user/{registerUser.Username}", msg);
        }

        [HttpPost]
        [Route("Login")]
        public ActionResult<string> Login(UserLoginModel userLoginModel)
        {
           string token = this.userService.Login(userLoginModel);

            var user = this.User.Identity;
            var smthElse = this.User;
            var st = this.User.Claims;
            var currentUser = this.User.Identity.Name;
            return this.Ok(token);
        }

        [HttpGet]
        public IActionResult Logout() 
        {
            this.userService.Logout();

            return this.Accepted();
        }

    }
}
