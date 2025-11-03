using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AntiforgeryTokensAPI.Controllers
{
    [ApiController]
    [Route("api")]
    public class AccountController : ControllerBase
    {
        private readonly IAntiforgery _antiforgery;

        public AccountController(IAntiforgery antiforgery)
        {
            _antiforgery = antiforgery;
        }

        // Endpoint de login simulado para establecer la cookie de autenticación
        [HttpPost("login")]
        public async Task<IActionResult> Login()
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, "testuser")
            };
            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity));

            return Ok(new { message = "Login successful" });
        }


        // Implementa este método. Debe usar '_antiforgery.GetAndStoreTokens'
        [Authorize]
        [HttpGet("csrf-token")]
        public IActionResult GetCsrfToken()
        {

            return Ok(new { message = "Endpoint no implementado" });
        }


        // Protege este endpoint contra ataques CSRF.
        [Authorize]
        [HttpPost("protected-action")]
        public IActionResult ProtectedAction()
        {
            return Ok(new { message = "¡Acción protegida ejecutada exitosamente!" });
        }
    }
}
