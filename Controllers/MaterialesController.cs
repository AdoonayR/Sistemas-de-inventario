using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Sistemas_de_inventario.Data;
using Sistemas_de_inventario.Models;
using Sistemas_de_inventario.Models.ViewModels;

namespace Sistemas_de_inventario.Controllers
{
    public class MaterialesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MaterialesController(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// GET: Carga la vista Warehouse.cshtml (u otra vista) para Agregar Material
        /// </summary>
        [HttpGet]
        public IActionResult Warehouse()
        {
            // Si deseas retornar un modelo inicial, puedes hacer:
            // return View(new MaterialCreateViewModel());
            // o simplemente return View() si tu vista no requiere datos previos.
            return View();
        }

        /// <summary>
        /// POST: Recibe el formulario de "MaterialCreateViewModel" y guarda en BD.
        /// Devuelve JSON con "success" o errores de validación.
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Warehouse(MaterialCreateViewModel model)
        {
            // Validamos el modelo
            if (!ModelState.IsValid)
            {
                var errores = ModelState.Values
                                        .SelectMany(v => v.Errors)
                                        .Select(e => e.ErrorMessage)
                                        .ToList();

                // Retornamos 400 con JSON de errores
                return BadRequest(new
                {
                    success = false,
                    errors = errores
                });
            }

            // Si no hay errores, construimos la entidad Material
            var material = new Material
            {
                NumeroParte = model.NumeroParte,
                Lote = model.Lote,
                Descripcion = model.Descripcion,
                Ubicacion = model.Ubicacion,
                Proveedor = model.Proveedor,
                Cantidad = model.Cantidad,
                Categoria = model.Categoria,
                UnidadMedida = model.UnidadMedida
            };

            // Guardamos en la base de datos
            _context.Materiales.Add(material);
            _context.SaveChanges();

            // Retornamos 200 OK con un JSON de éxito
            return Ok(new
            {
                success = true,
                message = "¡Material guardado exitosamente!"
            });
        }


        [HttpGet]
        public IActionResult Buscar(string partNumber)
        {
            if (string.IsNullOrWhiteSpace(partNumber))
            {
                // No se ingresó nada
                return Json(new
                {
                    success = false,
                    message = "No se ingresó un número de parte."
                });
            }

            // Buscamos el material en la BD
            var material = _context.Materiales
                .FirstOrDefault(m => m.NumeroParte == partNumber);

            if (material == null)
            {
                // No encontrado
                return Json(new
                {
                    success = false
                });
            }

            // Si se encuentra, devolvemos la info relevante
            return Json(new
            {
                success = true,
                data = new
                {
                    numeroParte = material.NumeroParte,
                    descripcion = material.Descripcion,
                    categoria = material.Categoria.ToString(),
                    unidadMedida = material.UnidadMedida.ToString(),
                    cantidad = material.Cantidad,
                    ubicacion = material.Ubicacion,
                    proveedor = material.Proveedor,
                    codigoBarras = "1234567890123" // por ejemplo, si lo tienes
                }
            });
        }

    }
}
