using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Sistemas_de_inventario.Models;
using System.Diagnostics;
using System.Threading.Tasks;

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

        // Acción Index: página principal o dashboard tras el login.
        public IActionResult Index()
        {
            var userRole = User.IsInRole("Almacen"); // Verifica si el usuario es parte de "Almacen"
            ViewData["ShowAlmacenOptions"] = userRole;
            return View();
        }

        // Acción para usuarios con rol "Supervisor"
        public IActionResult Supervisor()
        {
            return View(); // Vista: Views/Home/Supervisor.cshtml
        }

        // Acción para usuarios con rol "Warehouse"
        public IActionResult Warehouse()
        {
            return View(); // Vista: Views/Home/Warehouse.cshtml
        }

        // Acción para usuarios con rol "Production"
        public IActionResult Production()
        {
            return View(); // Vista: Views/Home/Production.cshtml
        }

        // Acción opcional Privacy
        public IActionResult Privacy()
        {
            return View(); // Vista: Views/Home/Privacy.cshtml
        }

        // Acción de Error
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            // Se asume que tienes la clase ErrorViewModel definida en tu proyecto
            return View(new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            });
        }

        // Acción para cerrar sesión
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            // Cierra la sesión del usuario autenticado
            await HttpContext.SignOutAsync();

            // Redirige a la página de Login
            return RedirectToAction("Login", "Login");
        }
    }
}

