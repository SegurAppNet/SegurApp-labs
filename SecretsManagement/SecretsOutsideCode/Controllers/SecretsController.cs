using Microsoft.AspNetCore.Mvc;
using SecretsOutsideCode.Service;

namespace SecretsOutsideCode.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SecretsController : ControllerBase
    {
        private readonly ISecretService _secretService;

        public SecretsController(ISecretService secretService)
        {
            _secretService = secretService;
        }

        // Endpoint de prueba para verificar la implementación
        [HttpGet("show-secrets")]
        public IActionResult ShowSecrets()
        {
            try
            {
                var secrets = _secretService.GetSecrets();

                // Devuelve los secretos (para demostración - ¡No hagas esto en producción!)
                // En una app real, el servicio USARÍA los secretos, no los devolvería.
                return Ok(new
                {
                    message = "Secretos recuperados (¡Solo para demostración!)",
                    //retrievedApiKey = secrets.ApiKey, // Asume que existe la propiedad ApiKey en Settings
                    //retrievedAddress = secrets.Address // Asume que existe la propiedad Address en Settings
                });
            }
            catch (NotImplementedException nie)
            {
                return Problem($"Parece que el constructor de SecretService no está implementado: {nie.Message}");
            }
            catch (InvalidOperationException ioe)
            {
                return Problem($"El objeto de secretos es nulo. {ioe.Message}");
            }
            catch (Exception ex) 
            {
                return Problem($"Ocurrió un error.{ex.Message}");
            }
        }
    }
}