using PoliticaDeRolesIdentity.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using PoliticaDeRolesIdentity.Services;
using System.Threading.Tasks;
using PoliticaDeRolesIdentity.Data;
using Microsoft.EntityFrameworkCore;

namespace PoliticaDeRolesIdentity.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public AccountController(
            SignInManager<IdentityUser> signInManager,
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            this.roleManager = roleManager;
        }

        [HttpGet]
        public async Task<IActionResult> Login()
        {
            await EnsureRolesExist();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model, string? returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;

            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(
                    model.Email, model.Password, isPersistent: false, lockoutOnFailure: true);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else if (result.IsLockedOut)
                {
                    ModelState.AddModelError(string.Empty, "Cuenta bloqueada. Inténtelo más tarde.");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Credenciales inválidas");
                }


            }

            return View(model);
        }

        //Este método asegura que los roles definidos en UserRoles existan en la base de datos, si estas seguro de que ya existen puedes eliminar este método

        private async Task EnsureRolesExist()
        {
            string[] roles = UserRoles.GetAllRoles();

            foreach (var roleName in roles)
            {
                if (!await roleManager.RoleExistsAsync(roleName))
                {
                    await roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model, string? returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;

            if (ModelState.IsValid)
            {

                if (await _userManager.FindByEmailAsync(model.Email) != null)
                {
                    ModelState.AddModelError(string.Empty, "Usuario registrado previamente.");
                    return View(model);
                }

                var user = new IdentityUser { UserName = model.Email, Email = model.Email };

                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {

                    var roleResult = await _userManager.AddToRoleAsync(user, model.Role);
                    

                    if (roleResult.Succeeded)
                    {
                        // Aquí puedes agregar la lógica para asignar el claim adicional basado en el rol seleccionado

                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        await _userManager.DeleteAsync(user);
                        foreach (var error in roleResult.Errors)
                        {
                            ModelState.AddModelError(string.Empty, $"Error asignando rol: {error.Description}");
                        }
                    }
                }
                //

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }

    }

}