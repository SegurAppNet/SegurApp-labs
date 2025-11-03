using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UseRazor.RazorPages.Account
{
    public class RegisterModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public RegisterModel(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [BindProperty]
        public InputModel Input { get; set; } = new();

        [TempData]
        public string? ErrorMessage { get; set; }

        [TempData]
        public string? SuccessMessage { get; set; }

        public class InputModel
        {
            [Required(ErrorMessage = "El email es obligatorio")]
            [EmailAddress(ErrorMessage = "El formato del email no es válido")]
            public string? Email { get; set; }

            [Required(ErrorMessage = "El nombre de usuario es obligatorio")]
            [StringLength(20, MinimumLength = 3, ErrorMessage = "Debe tener entre 3 y 20 caracteres")]
            public string? Username { get; set; }

            [Required(ErrorMessage = "La contraseña es obligatoria")]
            [StringLength(100, MinimumLength = 6, ErrorMessage = "Debe tener al menos 6 caracteres")]
            [DataType(DataType.Password)]
            public string? Password { get; set; }

            [Required(ErrorMessage = "Debe confirmar la contraseña")]
            [Compare("Password", ErrorMessage = "Las contraseñas no coinciden")]
            [DataType(DataType.Password)]
            public string? ConfirmPassword { get; set; }
        }

        public void OnGet()
        {
        }


        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                ErrorMessage = "Por favor completa todos los campos correctamente.";
                return Page();
            }

            try
            {
                var user = new IdentityUser
                {
                    UserName = Input.Username,
                    Email = Input.Email
                };

                var result = await _userManager.CreateAsync(user, Input.Password!);

                if (result.Succeeded)
                {
                    SuccessMessage = "Cuenta creada correctamente. Redirigiendo...";
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToPage("/Account/Login");
                }
                else
                {
                    ErrorMessage = string.Join(". ", result.Errors.Select(e => e.Description));
                }
            }
            catch (Exception ex)
            {
                ErrorMessage = $"Error durante el registro: {ex.Message}";
            }

            return Page();
        }

        
    }
}
