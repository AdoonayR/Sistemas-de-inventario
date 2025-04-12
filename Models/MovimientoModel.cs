using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sistemas_de_inventario.Models
{
    public class Movimiento
    {
        [Key]
        public int MovimientoId { get; set; }

        [ForeignKey("Material")]
        public int MaterialId { get; set; }
        public Material Material { get; set; }

        [Required]
        public DateTime Fecha { get; set; } = DateTime.Now;

        [Required]
        [StringLength(50)]
        public string Tipo { get; set; }  // Ejemplo: "Entrada", "Salida", "Traslado"

        public int Cantidad { get; set; }

        [StringLength(200)]
        public string OrigenDestino { get; set; }

        [StringLength(50)]
        public string Usuario { get; set; }
    }
}
