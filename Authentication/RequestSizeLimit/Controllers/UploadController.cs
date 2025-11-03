using Microsoft.AspNetCore.Mvc;

namespace RequestSizeLimit.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UploadController : ControllerBase 
    {
        // Configuración por Endpoint
        // Añade el atributo [RequestSizeLimit(...)] a este método para establecer un límite específico para este endpoint,
        // Este límite anulará el límite global que configuraste en Program.cs.
        [HttpPost("upload-limited")]
        public IActionResult UploadFileLimited(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest(new { error = "No se proporcionó archivo." });
            }

            return Ok(new
            {
                message = "Archivo subido exitosamente (con límite de 5MB).",
                fileName = file.FileName,
                fileSize = file.Length,
                limitApplied = "5 MB"
            });
        }

        // OPCIONAL
        // Añade el atributo [DisableRequestSizeLimit] a este método para permitir subidas de archivos sin límite de tamaño,
        // ignorando cualquier límite global. 
        [HttpPost("upload-unlimited")]
        public IActionResult UploadFileUnlimited(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest(new { error = "No se proporcionó archivo." });
            }

            return Ok(new
            {
                message = "Archivo subido exitosamente (sin límite de tamaño).",
                fileName = file.FileName,
                fileSize = file.Length,
                limitApplied = "Ninguno (Deshabilitado)"
            });
        }
    }
}
