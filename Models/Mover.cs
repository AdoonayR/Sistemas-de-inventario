using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sistemas_de_inventario.Models
{
    public enum TipoMovimiento
    {
        Entrada,
        Salida,
        Traslado,
        Ajuste
    }

    [Table("Movimientos")]
    [Index(nameof(MaterialId), nameof(FechaMovimiento))]
    public class Movimiento
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Tipo de Movimiento")]
        [Column(TypeName = "varchar(20)")]
        public TipoMovimiento Tipo { get; set; }

        [Required]
        [Display(Name = "Fecha/Hora")]
        [Column(TypeName = "datetime2")]
        public DateTime FechaMovimiento { get; set; } = DateTime.UtcNow;

        [Required]
        [Display(Name = "Usuario")]
        [StringLength(50)]
        [Column(TypeName = "nvarchar(50)")]
        public string Usuario { get; set; }

        [Required]
        [ForeignKey("Material")]
        public int MaterialId { get; set; }

        [InverseProperty("Movimientos")]
        public virtual Material Material { get; set; }

        [Display(Name = "Lote/Serie")]
        [StringLength(50)]
        [Column(TypeName = "varchar(50)")]
        public string Lote { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "La cantidad debe ser mayor a 0")]
        public int Cantidad { get; set; }

        [Display(Name = "Ubicación Origen")]
        [StringLength(50)]
        [Column(TypeName = "varchar(50)")]
        public string UbicacionOrigen { get; set; }

        [Display(Name = "Ubicación Destino")]
        [StringLength(50)]
        [Column(TypeName = "varchar(50)")]
        public string UbicacionDestino { get; set; }

        [StringLength(200)]
        [Column(TypeName = "nvarchar(200)")]
        public string Comentarios { get; set; }

        [ForeignKey("Solicitud")]
        public int? SolicitudId { get; set; }

        [InverseProperty("Movimientos")]
        public virtual Solicitud Solicitud { get; set; }
    }
}