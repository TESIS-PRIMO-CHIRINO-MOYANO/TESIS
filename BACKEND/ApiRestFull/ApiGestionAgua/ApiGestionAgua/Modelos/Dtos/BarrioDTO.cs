using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ApiGestionAgua.Modelos.Dtos
{
    public class BarrioDTO
    {
        public int IdBarrio { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public bool Estado { get; set; }
        [Required]
        public int IdZona { get; set; }

     
    }
}
