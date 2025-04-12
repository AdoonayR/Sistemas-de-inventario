using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sistemas_de_inventario.Models
{
    public class Material
    {
        [Key]
        public int MaterialId { get; set; }

        [Required]
        [StringLength(50)]
        public string NumeroParte { get; set; }

        [StringLength(50)]
        public string Lote { get; set; }

        [Required]
        [StringLength(200)]
        public string Descripcion { get; set; }

        [StringLength(50)]
        public string Ubicacion { get; set; }

        [StringLength(100)]
        public string Proveedor { get; set; }

        [Range(0, int.MaxValue)]
        public int Cantidad { get; set; }

        [Required]
        public CategoriasMaterial Categoria { get; set; }

        [Required]
        public UnidadesMedida UnidadMedida { get; set; }
    }
}
