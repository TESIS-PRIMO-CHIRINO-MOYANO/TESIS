using System.ComponentModel.DataAnnotations;

namespace ApiGestionAgua.Modelos.Dtos
{
    public class EstadoDTO
    {
        public int IdEstado { get; set; }
        [Required]
        public string Nombre { get; set; }
    }
}
