using System;
using System.ComponentModel.DataAnnotations;

namespace Sistemas_de_inventario.Models.ViewModels
{
    public class SolicitudViewModel
    {
        public int SolicitudId { get; set; }

        [Required]
        [Display(Name = "Fecha de la Solicitud")]
        public DateTime Fecha { get; set; } = DateTime.Now;

        [Required]
        [StringLength(50)]
        public string Tipo { get; set; }  // Pedido, Traslado, etc.

        [Required]
        [StringLength(200)]
        [Display(Name = "Material Solicitado")]
        public string MaterialSolicitado { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int Cantidad { get; set; }

        [Display(Name = "Solicitante")]
        public string Solicitante { get; set; }

        [Required]
        [Display(Name = "Estado")]
        [StringLength(50)]
        public string Estado { get; set; } // Pendiente, En proceso, Completada, Rechazada
    }
}
