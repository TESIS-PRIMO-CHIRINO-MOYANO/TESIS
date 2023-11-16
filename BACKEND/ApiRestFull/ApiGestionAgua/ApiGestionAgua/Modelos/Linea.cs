using System.ComponentModel.DataAnnotations;

namespace ApiGestionAgua.Modelos
{
    public class Linea
    {

        [Key]
        public int IdLinea { get; set; }

        [Required]
        public string Nombre { get; set; }
    }
}
