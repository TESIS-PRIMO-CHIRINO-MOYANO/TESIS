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

        public int IdZona { get; set; }

        [ForeignKey("IdZona")]
        public Zona Zona { get; set; }
    }
}
