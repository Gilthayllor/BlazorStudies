using BookStore.API.Contracts.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.API.Implementations.Services
{
    public class UserService : IUserservice
    {
        private IConfiguration _config;
        private UserManager<IdentityUser> _userManager;

        public UserService(IConfiguration config, UserManager<IdentityUser> userManager)
        {
            _config = config;
            _userManager = userManager;
        }

        public async Task<string> GenerateJWT(IdentityUser user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Id)
            };

            var roles = await _userManager.GetRolesAsync(user);
            claims.AddRange(roles.Select(x => new Claim(ClaimsIdentity.DefaultRoleClaimType, x)));

            var token = new JwtSecurityToken(_config["JWT:Issuer"], 
                _config["JWT:Issuer"], 
                claims, 
                null,
                expires: DateTime.Now.AddMinutes(5),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
