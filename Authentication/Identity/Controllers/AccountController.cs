using IdentityProject.Models;
using Microsoft.AspNetCore.Mvc;
//Agregar import de Identity 

namespace IdentityProject.Controllers
{ 
    // Inyectar dependencias de UserManager y SignInManager
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        

        // Modificar para usar SignInManager de Identity
        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        // Modificar para usar UserManager de Identity
        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            return RedirectToAction("Index", "Home");
        }

        // Modificar para usar SignOut de Identity
        [HttpPost]
        public IActionResult Logout()
        {
            return RedirectToAction("Login", "Account");
        }

    }

}