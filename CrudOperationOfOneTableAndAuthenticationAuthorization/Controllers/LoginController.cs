using CrudOperationOfOneTableAndAuthenticationAuthorization.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace CrudOperationOfOneTableAndAuthenticationAuthorization.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IConfiguration _config;
        public LoginController(IConfiguration configuration)
        {
            _config = configuration;
        }
        private User AuthenticateUser(User user)
        {
            User _user = null;
            if (user.username == "admin" && user.password == "123")
            {
                _user = new User { username = "MuhammadSaad" };
            }
            return _user;
        }
        private string GenerateToken(User users)
        {
            var securitykey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securitykey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(_config["Jwt:Issuer"], _config["Jwt:Audience"], null,
                expires: DateTime.Now.AddMinutes(100),
                signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        [HttpPost]
        public IActionResult Login(User user)
        {
            IActionResult response = Unauthorized();
            var user_ = AuthenticateUser(user);
            if (user_ != null)
            {
                var token = GenerateToken(user_);
                response = Ok(new { token = token });
            }
            return response;
        }

    }

    }
