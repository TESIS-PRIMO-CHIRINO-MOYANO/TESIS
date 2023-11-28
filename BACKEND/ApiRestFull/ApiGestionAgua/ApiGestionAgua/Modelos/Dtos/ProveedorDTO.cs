using System.ComponentModel.DataAnnotations;

namespace ApiGestionAgua.Modelos.Dtos
{
    public class ProveedorDTO
    {

        public int IdProveedor { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [MaxLength(50, ErrorMessage = "La longitud del nombre no puede superar 50 caracteres.")]
        public string Nombre { get; set; }

    }
}
