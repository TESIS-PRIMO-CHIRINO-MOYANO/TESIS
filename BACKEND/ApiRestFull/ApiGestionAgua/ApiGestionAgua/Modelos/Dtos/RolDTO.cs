using System.ComponentModel.DataAnnotations;

namespace ApiGestionAgua.Modelos.Dtos
{
    public class RolDTO
    {

        public int IdRol { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        public string Nombre { get; set; }

    }
}
