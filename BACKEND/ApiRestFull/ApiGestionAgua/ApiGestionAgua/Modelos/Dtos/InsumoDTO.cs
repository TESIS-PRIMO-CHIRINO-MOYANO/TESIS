using System.ComponentModel.DataAnnotations;

namespace ApiGestionAgua.Modelos.Dtos
{
    public class InsumoDTO
    {

        public int IdInsumo { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El precio es obligatorio.")]
        public decimal Precio { get; set; }

    }
}
