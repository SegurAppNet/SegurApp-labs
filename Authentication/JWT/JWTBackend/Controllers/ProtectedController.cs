using Microsoft.AspNetCore.Mvc;

namespace JWTBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProtectedController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetProtectedData()
        {
            var userName = User.Identity?.Name;

            return Ok(new
            {
                message = $"Hola {userName}, a accedido",
                timestamp = DateTime.UtcNow
            });
        }
    }
}
