using System.ComponentModel.DataAnnotations;

namespace PoliticaDeRolesIdentity.Models
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [Required]
        [StringLength(100, MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Las contraseñas no coinciden")]
        public string ConfirmPassword { get; set; } = null!;

        [Required]
        public string Role { get; set; } = null!;


        //Atributo adicional correspondiente al claim que creaste en la carpeta Services, y ahora forma prate del registro de usuario
    }
}