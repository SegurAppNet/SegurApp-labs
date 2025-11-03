// Añadir el espacio de nombres de DataAnnotations 

namespace ValidacionEntradas.Models
{
    public class LoginViewModel
    {
        // Añadir validaciones de datos a las propiedades según sea necesario
        public string Email { get; set; } = null!;

        public string Password { get; set; } = null!;
    }
}