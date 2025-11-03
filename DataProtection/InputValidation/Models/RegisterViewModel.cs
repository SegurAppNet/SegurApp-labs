//using System.ComponentModel.DataAnnotations;

namespace ValidacionEntradas.Models
{
    public class RegisterViewModel
    {
        //[Required(ErrorMessage = "El correo electrónico es obligatorio")]
        //[EmailAddress(ErrorMessage = "Formato de correo electrónico inválido")]
        //[MaxLength(100, ErrorMessage = "El email no puede exceder 100 caracteres")]
        //[RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Formato de email inválido")]
        //[Display(Name = "Correo Electrónico")]
        public string Email { get; set; } = null!;

        //[Required(ErrorMessage = "La contraseña es obligatoria")]
        //[StringLength(100, ErrorMessage = "La contraseña debe tener entre {2} y {1} caracteres", MinimumLength = 8)]
        //[DataType(DataType.Password)]
        //[Display(Name = "Contraseña")]
        //[RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$", ErrorMessage = "La contraseña debe contener mayúsculas, minúsculas, números y al menos un símbolo")]
        public string Password { get; set; } = null!;

        //[Required(ErrorMessage = "Confirmar contraseña es obligatorio")]
        //[DataType(DataType.Password)]
        //[Display(Name = "Confirmar Contraseña")]
        //[Compare("Password", ErrorMessage = "Las contraseñas no coinciden")]
        public string ConfirmPassword { get; set; } = null!;

    }
}