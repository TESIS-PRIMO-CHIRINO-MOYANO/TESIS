using System.ComponentModel.DataAnnotations;

namespace ApiGestionAgua.Modelos.Dtos
{
    public class RegistroClienteDTO
    {


        [Required(ErrorMessage = "El Dni es obligatorio.")]
        public string Dni { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El apellido es obligatorio.")]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "El mail es obligatorio.")]
        public string Mail { get; set; }

        [Required(ErrorMessage = "La Contraseña es obligatoria.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "La fecha de nacimiento es obligatoria.")]
        public DateTime? FechaNacimiento { get; set; }

        [Required(ErrorMessage = "El IdRol es obligatorio.")]
        public int IdRol { get; set; }

        [Required(ErrorMessage = "La calle es obligatoria.")]
        public string Calle { get; set; }

        [Required(ErrorMessage = "El piso es obligatorio.")]
        public string Piso { get; set; }

        [Required(ErrorMessage = "El depto es obligatorio.")]
        public string Depto { get; set; }

        [Required(ErrorMessage = "El telefono es obligatorio.")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "El IdBarrio es obligatorio.")]
        public int IdBarrio { get; set; }


    }
}
