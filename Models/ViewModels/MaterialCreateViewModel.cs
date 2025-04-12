using System.ComponentModel.DataAnnotations;
using Sistemas_de_inventario.Models;  // Para usar Enumeraciones

namespace Sistemas_de_inventario.Models.ViewModels
{
    public class MaterialCreateViewModel
    {
        [Required(ErrorMessage = "El número de parte es requerido.")]
        [RegularExpression(@"[A-Z0-9-]+", ErrorMessage = "Use solo mayúsculas, dígitos y guiones.")]
        [Display(Name = "Número de Parte")]
        public string NumeroParte { get; set; }

        [Display(Name = "Lote / Serie")]
        public string Lote { get; set; }

        [Required(ErrorMessage = "La descripción es requerida.")]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "La ubicación es requerida.")]
        [Display(Name = "Ubicación")]
        public string Ubicacion { get; set; }

        [Display(Name = "Proveedor")]
        public string Proveedor { get; set; }

        [Required(ErrorMessage = "La cantidad inicial es requerida.")]
        [Range(1, int.MaxValue, ErrorMessage = "La cantidad debe ser al menos 1.")]
        [Display(Name = "Cantidad")]
        public int Cantidad { get; set; }

        [Required(ErrorMessage = "Debe seleccionar una categoría.")]
        [Display(Name = "Categoría")]
        public CategoriasMaterial Categoria { get; set; }

        [Required(ErrorMessage = "Debe seleccionar una unidad de medida.")]
        [Display(Name = "Unidad de Medida")]
        public UnidadesMedida UnidadMedida { get; set; }
    }
}
