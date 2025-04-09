using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistemas_de_inventario.Data;
using Sistemas_de_inventario.Models;
using System.Security.Claims;

namespace Sistemas_de_inventario.Controllers
{
    public class LoginController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LoginController(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        // GET: /Login/Login
        [HttpGet]
        public IActionResult Login()
        {
            return View(); // Busca la vista en: Views/Login/Login.cshtml
        }

        // POST: /Login/Login
        [HttpPost]
        public async Task<IActionResult> Login(string Email, string Password)
        {
            // Validar que se hayan enviado datos
            if (string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Password))
            {
                ModelState.AddModelError("", "Debe ingresar correo y contraseña.");
                return View();
            }

            // Buscar el usuario en la base de datos
            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(u => u.Email == Email && u.Password == Password);

            if (usuario == null)
            {
                ModelState.AddModelError("", "Credenciales inválidas.");
                return View();
            }

            // Crear lista de Claims
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, usuario.Email),
                new Claim("UserId", usuario.Id.ToString()),
                new Claim(ClaimTypes.Role, usuario.Role ?? "User")
            };

            // Crear la identidad y el principal con el esquema de cookies
            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);

            // Firmar (crear) la cookie de autenticación
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
            switch (usuario.Role?.ToLower())
            {
                case "supervisor":
                    return RedirectToAction("Supervisor", "Home");
                case "warehouse":
                    return RedirectToAction("Warehouse", "Home");
                case "production":
                    return RedirectToAction("Production", "Home");
                default:
                    return RedirectToAction("Index", "Home");
            }
        }

        // GET: /Login/Logout
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Login");
        }
    }
}
