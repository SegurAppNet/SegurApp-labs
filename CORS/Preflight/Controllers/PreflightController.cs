using Microsoft.AspNetCore.Mvc;

namespace Preflight.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    // No se necesita el atributo [EnableCors] aquí
    // porque la política "PoliticaPreflight" se aplicó globalmente.
    public class PreflightController : ControllerBase
    {
        // Crear Endpoint que Maneje Métodos Complejos
        [HttpPut("actualizar-recurso")]
        public IActionResult ActualizarRecurso([FromBody] DataModel data)
        {
            return Ok(new { message = $"Recurso actualizado con datos: {data?.Value ?? "ninguno"}" });
        }

        // Endpoint simple para probar GET (no requiere preflight)
        [HttpGet("obtener-recurso")]
        public IActionResult ObtenerRecurso()
        {
            return Ok(new { message = "Recurso obtenido" });
        }
    }

    public class DataModel
    {
        public string? Value { get; set; }
    }
}
