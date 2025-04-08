using System.ComponentModel.DataAnnotations;

namespace Sistemas_de_inventario.Models
{
  
    public class Usuario
    {
        // Identificador único del auditor
        [Key]
        public int Id { get; set; }

        // Nombre del auditor
        [Required]
        public string Name { get; set; }
        
        //Numero de empleado unico en base de datos
        [Required]
        public string EmployeeNumber { get; set; }

        //Rol de usuario (Produccion o supervisor)
        [Required]
        public string Role { get; set; }
    }
}
