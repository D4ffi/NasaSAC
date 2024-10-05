using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using NasaSpaceAppChallenge.Models;

namespace NasaSpaceAppChallenge.Controllers;

/*  Esta clase es el controlador principal de la aplicación.
    Contiene las acciones que responden a las peticiones HTTP.
    Las acciones son métodos que se ejecutan cuando se recibe una petición HTTP.
 */
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    
    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }
    
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}