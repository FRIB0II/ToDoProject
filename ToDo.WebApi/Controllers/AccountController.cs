using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ToDo.WebApi.Entities.Models;

namespace ToDo.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        [AllowAnonymous]
        [HttpPost("Login")]
        public IActionResult Login(LoginModel login)
        {
            if (login.Nome == "admin" || login.Senha == "admin") 
            {
                var token = GerarTokenJWT();
                return Ok(new { token });
            }

            return BadRequest(new { message = "Falha na autenticação!" });
        }

        private string GerarTokenJWT()
        {
            string chaveSecreta = "5e8d9382-2bf7-4f3a-a03e-25494b8b3d31";

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(chaveSecreta));

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim("nome", "admin"),
                new Claim("admin", "administrador")
            };

            var token = new JwtSecurityToken(
                issuer: "sua_empresa",
                audience: "sua_aplicacao",
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
