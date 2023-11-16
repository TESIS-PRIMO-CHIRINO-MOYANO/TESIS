using System.ComponentModel.DataAnnotations;

namespace ApiGestionAgua.Modelos
{
    public class Modulo
    {
        [Key]
        public int IdModulo { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public bool Estado { get; set; }
    }
}
