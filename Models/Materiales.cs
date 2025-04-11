using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sistemas_de_inventario.Models
{
    public enum UnidadesMedida
    {
        Pieza,
        Metro,
        Litro,
        Kilogramo,
        Caja
    }

    public enum CategoriasMaterial
    {
        Tornilleria,
        Herramientas,
        Materiales,
        Electricos,
        Empaques
    }

    [Table("Materiales")]
    [Index(nameof(NumeroParte), IsUnique = true)]
    public class Material
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "El número de parte es obligatorio")]
        [Display(Name = "Número de Parte")]
        [StringLength(50, ErrorMessage = "Máximo 50 caracteres")]
        [RegularExpression(@"^[A-Z0-9-]+$", ErrorMessage = "Solo mayúsculas, números y guiones")]
        [Column(TypeName = "varchar(50)")]
        public string NumeroParte { get; set; }

        [Required(ErrorMessage = "La descripción es obligatoria")]
        [StringLength(200, ErrorMessage = "Máximo 200 caracteres")]
        [Column(TypeName = "nvarchar(200)")]
        public string Descripcion { get; set; }

        [Required]
        [Column(TypeName = "varchar(30)")]
        public CategoriasMaterial Categoria { get; set; }

        [Required]
        [Column(TypeName = "varchar(20)")]
        [Display(Name = "Unidad de Medida")]
        public UnidadesMedida UnidadMedida { get; set; }

        [Required]
        [Display(Name = "Ubicación Principal")]
        [RegularExpression(@"^ZONA[1-9]-EST[1-9]-BIN[1-9]$", ErrorMessage = "Formato: ZONA#-EST#-BIN#")]
        [Column(TypeName = "varchar(20)")]
        public string Ubicacion { get; set; }

        [Display(Name = "Fecha de Creación")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(TypeName = "datetime2")]
        public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;

        [Display(Name = "Última Actualización")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [Column(TypeName = "datetime2")]
        public DateTime FechaActualizacion { get; set; } = DateTime.UtcNow;

        [Display(Name = "Proveedor")]
        [StringLength(100)]
        [Column(TypeName = "nvarchar(100)")]
        public string Proveedor { get; set; }

        // Relaciones
        [InverseProperty("Material")]
        public virtual ICollection<Lote> Lotes { get; set; } = new HashSet<Lote>();

        [InverseProperty("Material")]
        public virtual ICollection<Movimiento> Movimientos { get; set; } = new HashSet<Movimiento>();

        [InverseProperty("Material")]
        public virtual ICollection<DetalleSolicitud> DetallesSolicitud { get; set; } = new HashSet<DetalleSolicitud>();

        [NotMapped]
        public int CantidadTotal => Lotes?.Sum(l => l.Cantidad) ?? 0;
    }

    [Table("Lotes")]
    [Index(nameof(NumeroLote), nameof(MaterialId))]
    public class Lote
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Número de Lote")]
        [StringLength(50)]
        [Column(TypeName = "varchar(50)")]
        public string NumeroLote { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "La cantidad debe ser mayor a 0")]
        public int Cantidad { get; set; }

        [Required]
        [StringLength(50)]
        [Column(TypeName = "varchar(50)")]
        public string Ubicacion { get; set; }

        [Required]
        [ForeignKey("Material")]
        public int MaterialId { get; set; }

        [InverseProperty("Lotes")]
        public virtual Material Material { get; set; }
    }
}