using System.ComponentModel.DataAnnotations;

namespace ApiGestionAgua.Modelos
{
    public class Vehiculo
    {

        [Key]
        public int IdPatente { get; set; }

        [Required]
        public string Nombre { get; set; }

    }
}
