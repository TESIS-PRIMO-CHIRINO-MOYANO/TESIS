using System.ComponentModel.DataAnnotations;

namespace ApiGestionAgua.Modelos
{
    public class Zona
    {
        [Key]
        public int IdZona { get; set; }

        [Required]
        public string Nombre { get; set; }

    }
}
