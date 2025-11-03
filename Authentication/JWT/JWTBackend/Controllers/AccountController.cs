using JWTBackend.Models;
using Microsoft.AspNetCore.Mvc;

namespace JWTBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public AccountController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // Generar y Firmar Token en el Login
        // Completa la lógica de este método.
        [HttpPost]
        [Route("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            // Valida las credenciales del usuario (puedes usar el 'admin'/'1234' del ejemplo)
            if (request.Username != "admin" || request.Password != "1234")
                return Unauthorized(new { message = "Credenciales inválidas" });


            return Ok(new { token = "GENERAR_TOKEN_AQUI" });
        }
    }
}
