using System.ComponentModel.DataAnnotations;

namespace Sistemas_de_inventario.Models.ViewModels
{
    public class MoverMaterialViewModel
    {
        [Required]
        [Display(Name = "Número de Parte")]
        public string ParteMover { get; set; }

        [Required]
        [Display(Name = "Lote/Serie")]
        public string LoteMover { get; set; }

        [Display(Name = "Ubicación Actual")]
        public string UbicacionActual { get; set; }

        [Required]
        [Display(Name = "Nueva Ubicación")]
        public string NuevaUbicacion { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Debe ingresar al menos 1.")]
        [Display(Name = "Cantidad a Mover")]
        public int CantidadMover { get; set; }
    }
}
