using BookStore.API.Contracts.Services;
using BookStore.API.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IUserservice _userService;

        public UsersController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager, IUserservice userservice)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _userService = userservice;
        }

        /// <summary>
        /// User login.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] UserDTO user)
        {
            var userName = user.UserName;
            var password = user.Password;

            var result = await _signInManager.PasswordSignInAsync(userName, password, false, false);

            if (result.Succeeded)
            {
                var userFound = await _userManager.FindByNameAsync(user.UserName);
                var token = await _userService.GenerateJWT(userFound);
                return Ok(new { token });
            }

            return Unauthorized(user);
        }

    }
}
