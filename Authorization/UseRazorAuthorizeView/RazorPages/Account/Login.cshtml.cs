using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace UseRazor.RazorPages.Account;

public class LoginModel : PageModel
{
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly ILogger<LoginModel> _logger;

    public LoginModel(SignInManager<IdentityUser> signInManager, ILogger<LoginModel> logger)
    {
        _signInManager = signInManager;
        _logger = logger;
    }

    [BindProperty]
    public InputModel Input { get; set; } = new()
    {
        UsernameOrEmail = string.Empty,
        Password = string.Empty
    };

    public string ErrorMessage { get; set; } = "";

    public class InputModel
    {
        [Required(ErrorMessage = "El usuario o email es requerido")]
        [Display(Name = "Usuario o Email")]
        public required string UsernameOrEmail { get; set; }

        [Required(ErrorMessage = "La contraseña es requerida")]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public required string Password { get; set; }

        [Display(Name = "Recuérdame")]
        public bool RememberMe { get; set; }
    }

    public void OnGet()
    {
        if (User?.Identity?.IsAuthenticated == true)
        {
            Redirect("/");
        }
    }

    public async Task<IActionResult> OnPostAsync()
    {
      
        if (!ModelState.IsValid)
        {
            _logger.LogWarning("ModelState no válido");
            return Page();
        }

        var result = await _signInManager.PasswordSignInAsync(
            Input.UsernameOrEmail,
            Input.Password,
            Input.RememberMe,
            lockoutOnFailure: false);

        if (result.Succeeded)
        {
            return LocalRedirect("/");
        }
        else
        {
            ErrorMessage = "Usuario o contraseña incorrectos.";
            _logger.LogWarning("Login fallido para usuario: " + Input.UsernameOrEmail);
        }

        return Page();
    }
}