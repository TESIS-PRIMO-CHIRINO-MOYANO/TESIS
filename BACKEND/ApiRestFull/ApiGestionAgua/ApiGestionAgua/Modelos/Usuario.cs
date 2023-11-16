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

        [ForeignKey("IdRol")]
        public int IdRol { get; set; }

        public Rol Rol { get; set; }

    }
}
