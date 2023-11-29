using System.ComponentModel.DataAnnotations;

namespace ApiGestionAgua.Modelos.Dtos
{
    public class VehiculoDTO
    {
        public int IdPatente { get; set; }
        [Required]
        public string Patente { get; set; }
        [Required]
        public string Nombre { get; set; }

    }
}
