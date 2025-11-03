using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HeadersConfiguration.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    // La política CORS se aplica globalmente en Program.cs.
    // [Authorize] // Descomenta si configuraste autenticación y AllowCredentials
    public class HeadersController : ControllerBase 
    {
        [HttpGet("datos-privados")]
        public IActionResult GetDatosPrivados()
        {
            // Observa cómo añadimos cabeceras personalizadas a la RESPUESTA.
            // Para que el cliente pueda LEER estas cabeceras, debes haberlas
            // configurado con '.WithExposedHeaders(...)' en Program.cs.
            Response.Headers.Append("X-Total-Paginas", "10");
            Response.Headers.Append("X-Token-Expirado", "false");

            return Ok(new { message = $"Datos privados entregados. Autenticado" });
        }
    }
}
