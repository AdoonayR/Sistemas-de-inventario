using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sistemas_de_inventario.Models
{
    public enum EstadoSolicitud
    {
        Pendiente,
        Aprobada,
        Rechazada,
        Completada,
        Cancelada
    }

    public enum TipoSolicitud
    {
        Pedido,
        Traslado,
        Devolucion,
        Ajuste
    }

    [Table("Solicitudes")]
    [Index(nameof(NumeroSolicitud), IsUnique = true)]
    public class Solicitud
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Número de Solicitud")]
        [StringLength(20)]
        [Column(TypeName = "varchar(20)")]
        public string NumeroSolicitud { get; set; } = $"SOL-{DateTime.UtcNow:yyyyMMddHHmmss}";

        [Required]
        [Display(Name = "Tipo de Solicitud")]
        [Column(TypeName = "varchar(20)")]
        public TipoSolicitud Tipo { get; set; }

        [Required]
        [Display(Name = "Fecha de Solicitud")]
        [Column(TypeName = "datetime2")]
        public DateTime FechaSolicitud { get; set; } = DateTime.UtcNow;

        [Display(Name = "Fecha de Respuesta")]
        [Column(TypeName = "datetime2")]
        public DateTime? FechaRespuesta { get; set; }

        [Required]
        [Display(Name = "Solicitante")]
        [StringLength(100)]
        [Column(TypeName = "nvarchar(100)")]
        public string Solicitante { get; set; }

        [Display(Name = "Área/Departamento")]
        [StringLength(50)]
        [Column(TypeName = "nvarchar(50)")]
        public string Departamento { get; set; }

        [Required]
        [Display(Name = "Estado")]
        [Column(TypeName = "varchar(20)")]
        public EstadoSolicitud Estado { get; set; } = EstadoSolicitud.Pendiente;

        [StringLength(500)]
        [Column(TypeName = "nvarchar(500)")]
        public string Comentarios { get; set; }

        [Display(Name = "Procesado Por")]
        [StringLength(50)]
        [Column(TypeName = "nvarchar(50)")]
        public string UsuarioProcesamiento { get; set; }

        // Relaciones
        [InverseProperty("Solicitud")]
        public virtual ICollection<DetalleSolicitud> Detalles { get; set; } = new HashSet<DetalleSolicitud>();

        [InverseProperty("Solicitud")]
        public virtual ICollection<Movimiento> Movimientos { get; set; } = new HashSet<Movimiento>();
    }

    [Table("DetallesSolicitud")]
    public class DetalleSolicitud
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [ForeignKey("Solicitud")]
        public int SolicitudId { get; set; }

        [InverseProperty("Detalles")]
        public virtual Solicitud Solicitud { get; set; }

        [Required]
        [ForeignKey("Material")]
        public int MaterialId { get; set; }

        [InverseProperty("DetallesSolicitud")]
        public virtual Material Material { get; set; }

        [Required]
        [Display(Name = "Cantidad Solicitada")]
        [Range(1, int.MaxValue)]
        public int Cantidad { get; set; }

        [Display(Name = "Cantidad Aprobada")]
        [Range(0, int.MaxValue)]
        public int? CantidadAprobada { get; set; }

        [Display(Name = "Ubicación Origen")]
        [StringLength(50)]
        [Column(TypeName = "varchar(50)")]
        public string UbicacionOrigen { get; set; }

        [Display(Name = "Ubicación Destino")]
        [StringLength(50)]
        [Column(TypeName = "varchar(50)")]
        public string UbicacionDestino { get; set; }

        [Display(Name = "Lote/Serie")]
        [StringLength(50)]
        [Column(TypeName = "varchar(50)")]
        public string Lote { get; set; }

        [StringLength(200)]
        [Column(TypeName = "nvarchar(200)")]
        public string Comentarios { get; set; }
    }
}