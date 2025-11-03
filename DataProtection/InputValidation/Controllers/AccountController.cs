using ValidacionEntradas.Models;
using Microsoft.AspNetCore.Mvc;

namespace ValidacionEntradas.Controllers
{
    public class AccountController : Controller
    {
         [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            if (model.Email == "adminTest@gmail.com" && model.Password == "Admin123#")
            {
                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("", "Credenciales inválidas");
            return View(model);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Datos inválidos");
                return View(model);
            }
                

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult Logout()
        {
            return RedirectToAction("Login", "Account");
        }

    }

}