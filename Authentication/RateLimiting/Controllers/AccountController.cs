using Microsoft.AspNetCore.Mvc;

namespace RateLimiting.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {

        // Aplicar política "PerIP"
        // Añade el atributo [EnableRateLimiting] para proteger este endpoint
        [HttpGet("login")] 
        public IActionResult GetWithPerIPLimit()
        {
            var clientIP = HttpContext.Connection.RemoteIpAddress?.ToString() ?? "unknown";
            return Ok(new
            {
                message = "Éxito (Endpoint de Login - Límite por IP)",
                clientIP = clientIP,
                timestamp = DateTime.UtcNow
            });
        }

        [HttpGet("global")]
        public IActionResult GetWithGlobalLimit()
        {
            // Este endpoint usará automáticamente la política "Global ya que no tiene un atributo específico.
            var clientIP = HttpContext.Connection.RemoteIpAddress?.ToString() ?? "unknown";
            return Ok(new
            {
                message = "Éxito (Endpoint de Perfil - Límite Global)",
                clientIP = clientIP,
                timestamp = DateTime.UtcNow
            });
        }

        // Desactivar límite
        // Añade el atributo [DisableRateLimiting] para que este endpoint.
        [HttpGet("no-limit")]
        public IActionResult GetUnlimited()
        {
            var clientIP = HttpContext.Connection.RemoteIpAddress?.ToString() ?? "unknown";
            return Ok(new
            {
                message = "Éxito (Endpoint de Salud - Sin Límite)",
                clientIP = clientIP,
                timestamp = DateTime.UtcNow
            });
        }
    }
}
