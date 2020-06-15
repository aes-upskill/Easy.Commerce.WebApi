using Easy.Commerce.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Easy.Commerce.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IConfiguration configuration;
        private readonly List<User> userList;
        public TokenController(IConfiguration config)
        {
            configuration = config;
            userList = new List<User>()
            {
                new User { UserName = "admin", FirstName = "Admin", LastName = "Role", Email = "admin@domain.com", UserRole="Admin" },
                new User { UserName = "customer", FirstName = "Customer", LastName = "Role", Email = "customer@domain.com", UserRole="Customer" }
            };
        }

        [HttpPost]
        public ActionResult Post(string userID, string password)
        {
            if (!(string.IsNullOrWhiteSpace(userID) && string.IsNullOrWhiteSpace(password)))
            {
                var user = userList.SingleOrDefault(x => x.UserName.ToLowerInvariant() == userID?.ToLowerInvariant() && password?.ToLowerInvariant() == "q");
                if (user != null)
                {

                    var claims = new[] {
                    new Claim(JwtRegisteredClaimNames.Sub, configuration["Jwt:Subject"]),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                    new Claim("id", user.UserID.ToString()),
                    new Claim("firstName", user.FirstName),
                    new Claim("lastName", user.LastName),
                    new Claim("userName", user.UserName),
                    new Claim("email", user.Email),
                    new Claim("role", user.UserRole)
                };
                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(configuration["Jwt:Issuer"], configuration["Jwt:Audience"], claims, expires: DateTime.UtcNow.AddMinutes(20), signingCredentials: signIn);
                    return Ok(new JwtSecurityTokenHandler().WriteToken(token));
                }
                else
                {
                    return BadRequest();
                }
            }
            else
            {
                return BadRequest();
            }
        }
    }
}