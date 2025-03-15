    using Microsoft.AspNetCore.Mvc;
    using Sistemas_de_inventario.Models;
    using System.Diagnostics;

    namespace Sistemas_de_inventario.Controllers
    {
        public class HomeController : Controller
        {
            private readonly ILogger<HomeController> _logger;

            public HomeController(ILogger<HomeController> logger)
            {
                _logger = logger;
            }
            public IActionResult Login()
            {

                return View();
            }
            public IActionResult Supervisor()
            {
                return View();
            }

            public IActionResult Privacy()
            {
                return View();
            }
        
            public IActionResult Production()
            {
                return View();
            }

        public IActionResult Warehouse()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
            public IActionResult Error()
            {
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
        }
    }
