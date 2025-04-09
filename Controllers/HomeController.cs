using Microsoft.AspNetCore.Mvc;
using Sistemas_de_inventario.Models;
using System.Diagnostics;

namespace Sistemas_de_inventario.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        // Constructor inyecta ILogger.
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // Acci�n Index: p�gina principal o dashboard tras el login.
        public IActionResult Index()
        {
            return View(); // Vista: Views/Home/Index.cshtml
        }

        // Acci�n para usuarios con rol "Supervisor"
        public IActionResult Supervisor()
        {
            return View(); // Vista: Views/Home/Supervisor.cshtml
        }

        // Acci�n para usuarios con rol "Warehouse"
        public IActionResult Warehouse()
        {
            return View(); // Vista: Views/Home/Warehouse.cshtml
        }

        // Acci�n para usuarios con rol "Production"
        public IActionResult Production()
        {
            return View(); // Vista: Views/Home/Production.cshtml
        }

        // Acci�n opcional Privacy
        public IActionResult Privacy()
        {
            return View(); // Vista: Views/Home/Privacy.cshtml
        }

        // Acci�n de Error
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            // Se asume que tienes la clase ErrorViewModel definida en tu proyecto
            return View(new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            });
        }
    }
}
