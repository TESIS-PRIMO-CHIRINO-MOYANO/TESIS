using System.ComponentModel.DataAnnotations;

namespace ApiGestionAgua.Modelos
{
    public class Linea
    {

        [Key]
        public int IdLinea { get; set; }

        [Required]
        [MaxLength(50)]
        public string Nombre { get; set; }
    }
}
