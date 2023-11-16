using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiGestionAgua.Modelos
{
    public class Barrio
    {
        [Key]
        public int IdBarrio { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public bool Estado { get; set; }

        [ForeignKey("IdZona")]
        public int IdZona { get; set; }

        public Zona Zona { get; set; }
    }
}
