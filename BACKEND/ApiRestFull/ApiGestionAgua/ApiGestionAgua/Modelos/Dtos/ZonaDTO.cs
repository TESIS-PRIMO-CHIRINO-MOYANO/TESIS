using System.ComponentModel.DataAnnotations;

namespace ApiGestionAgua.Modelos.Dtos
{
    public class ZonaDTO
    {
        public int IdZona { get; set; }

        [Required]
        public string Nombre { get; set; }
    }
}
