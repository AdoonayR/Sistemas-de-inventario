using System;
using System.ComponentModel.DataAnnotations;

namespace Sistemas_de_inventario.Models
{
    public class Solicitud
    {
        [Key]
        public int SolicitudId { get; set; }

        [Required]
        public DateTime Fecha { get; set; } = DateTime.Now;

        [Required]
        [StringLength(50)]
        public string Tipo { get; set; }  // Ejemplo: "Pedido", "Traslado"

        [Required]
        [StringLength(200)]
        public string MaterialSolicitado { get; set; }

        [Range(1, int.MaxValue)]
        public int Cantidad { get; set; }

        [StringLength(100)]
        public string Solicitante { get; set; }

        [Required]
        [StringLength(50)]
        public string Estado { get; set; }  // "Pendiente", "En proceso", "Completada", "Rechazada"
    }
}
