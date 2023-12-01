using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ApiGestionAgua.Modelos
{
    public class Usuario
    {

        [Key]
        public int IdUsuario { get; set; }

        [Required]
        public String Dni { get; set; }

        [Required]
        public String Nombre { get; set; }

        [Required]
        public String Apellido { get; set; }

        [Required]
        public String Mail { get; set; }

        [Required]
        public DateTime FechaNacimiento { get; set; }

        public int IdRol { get; set; }

        [ForeignKey("IdRol")]
        public Rol Rol { get; set; }

    }
}
