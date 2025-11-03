using Microsoft.AspNetCore.Mvc;

namespace EncryptConfigFiles.Controllers
{

    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly IConfiguration _config;
        public TestController(IConfiguration config)
        {
            _config = config;
        }

        [HttpGet("/get-connection-string")]
        public IActionResult GetConnectionString()
        {
            var connectionString = _config.GetConnectionString("DefaultConnection");

            if (string.IsNullOrEmpty(connectionString))
            {
                return NotFound("Cadena de conexión no encontrada. ¿Olvidaste cifrar el archivo o implementar el descifrado?");
            }

            return Ok(new { DecryptedConnectionString_Demo = connectionString });
        }
    }
}