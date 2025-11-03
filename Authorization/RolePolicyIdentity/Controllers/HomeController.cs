using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PoliticaDeRolesIdentity.Models;
using Microsoft.AspNetCore.Authorization;

namespace PoliticaDeRolesIdentity.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }



    [Authorize(Roles = "User,Manager")]
    public IActionResult Index()
    {
        return View();
    }

    [Authorize(Roles = "User,Manager")]
    public IActionResult Privacy()
    {
        return View();
    }

    //Definir las políticas de autorización en los métodos correspondientes, usando la palabra "Policy" y el nombre de la política que hayas definido en Program.cs

    public IActionResult ControlPanelHR()
    {
        return View();
    }


    public IActionResult ManagementTI()
    {
        return View();
    }

    public IActionResult AccessDenied()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
