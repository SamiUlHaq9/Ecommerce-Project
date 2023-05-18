using Ecommerce_Project.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
namespace Ecommerce_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IConfiguration _config;

        public  LoginController(IConfiguration config)
        {
            _config = config;
        }
        [AllowAnonymous]
        [HttpPost]
        [Route("Login")]     
        public IActionResult Login([FromBody] UserLogin userLogin)
        {
            var user = Authenticate(userLogin);

            if (user != null)
            {
                var token = Generate(user);

                if(user.Role.ToString() == "Admin")
                {
                    return RedirectToAction("Admin", "User", token);
                }
                else
                {
                    return RedirectToAction("user", "User", token);
                } 
            }
            else
            {
                return NotFound("User not found");
            }
        }
        private string Generate(UserModel user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(ClaimTypes.Email, user.EmailAddress),
                new Claim(ClaimTypes.GivenName, user.GivenName),
                new Claim(ClaimTypes.Role, user.Role)
            };
            var token = new JwtSecurityToken(
              _config["Jwt:Issuer"],
              _config["Jwt:Audience"],
              claims,
              expires: DateTime.Now.AddMinutes(1),
              signingCredentials: credentials);
            var encryptToken = new  JwtSecurityTokenHandler().WriteToken(token);
            HttpContext.Response.Cookies.Append("token", encryptToken,
            new CookieOptions
            {
                Expires = DateTime.Now.AddMinutes(10),
                HttpOnly = true,
                Secure = true,
                IsEssential = true,
                SameSite = SameSiteMode.None
            });
            return encryptToken;
        }
        private UserModel Authenticate(UserLogin userLogin)
        {
            UserModel UserModel = new UserModel();
            UserModel.Id = userLogin.Id;
            UserModel.EmailAddress = userLogin.EmailAddress;
            UserModel.Password = userLogin.Password;
            DataTable dt = UserModel.UsersAuthenticate();
            UserModel newUser = new UserModel();
            newUser.EmailAddress = dt.Rows[0]["EmailAddress"].ToString();
            newUser.GivenName = dt.Rows[0]["GivenName"].ToString();
            newUser.Role = dt.Rows[0]["Role"].ToString();
            var currentUser = newUser;
            if (currentUser != null)
            {
                return currentUser;
            }
            else
            {
            return null;
            }
        }

        public IActionResult Logout()
        {
            HttpContext.Response.Cookies.Delete("token");
            return RedirectToAction("Login", "Account");
        }
    }
}
