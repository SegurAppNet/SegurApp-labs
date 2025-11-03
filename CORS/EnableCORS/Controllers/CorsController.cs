using Microsoft.AspNetCore.Mvc;

namespace EnableCORS.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CorsController : ControllerBase
    {
        // Aplicar la Política a Endpoints Específicos
        // Añade el atributo [EnableCors(...)] a este método GET..
        [HttpGet("datos-protegidos-cors")]
        public IActionResult GetDatosConCors()
        {
            return Ok(new { message = "Este endpoint DEBERÍA tener CORS habilitado." });
        }
    }
}
