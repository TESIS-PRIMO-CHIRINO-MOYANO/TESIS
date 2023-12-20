using System.ComponentModel.DataAnnotations;

namespace ApiGestionAgua.Modelos.Dtos
{
    public class ClienteLoginDTO
    {

        [Required(ErrorMessage = "El mail es obligatorio.")]
        public string Mail { get; set; }

        [Required(ErrorMessage = "La contraseña es obligatoria.")]
        public string Password { get; set; }

    }
}
