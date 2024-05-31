using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace APIOfertas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IConfiguration _config;

        public AuthController(IConfiguration config)
        {
            _config = config;
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login([FromBody] UserLogin model)
        {
            // Aquí deberías validar las credenciales del usuario
            // Si las credenciales son válidas, genera y retorna un token JWT
            if (model.Username == "admin" && model.Password == "1234")
            {
                var tokenString = GenerateJWTToken();
                return Ok(new { token = tokenString });

            }
            else
            {
                //var tokenString = GenerateJWTToken();
                //return Ok(new { token = tokenString });
                return Unauthorized(new { message = "Usuario y/o claves incorrectos" });
            }
        }

        private string GenerateJWTToken()
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                _config["Jwt:Issuer"],
                _config["Jwt:Issuer"],
                null,
                expires: DateTime.Now.AddSeconds(6),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        [Authorize]
        [HttpGet("checkloginstatus")]
        public IActionResult CheckLoginStatus()
        {
            return Ok(new { message = "User is authenticated" });
        }
    }

    public class UserLogin
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }

}
