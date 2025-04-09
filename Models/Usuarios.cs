using System.ComponentModel.DataAnnotations;

namespace Sistemas_de_inventario.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "El número de empleado es obligatorio.")]
        public string EmployeeNumber { get; set; }

        [Required(ErrorMessage = "El rol es obligatorio.")]
        public string Role { get; set; } = string.Empty;

        // Nuevas propiedades:
        [Required(ErrorMessage = "El correo es obligatorio.")]
        [EmailAddress(ErrorMessage = "El correo electrónico no es válido.")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "La contraseña es obligatoria.")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;

        public Usuario()
        {
            Name = string.Empty;
            EmployeeNumber = string.Empty;
            Role = string.Empty;
            Email = string.Empty;
            Password = string.Empty;
        }
    }
}
