using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ApiGestionAgua.Modelos.Dtos
{
    public class ProductoDTO
    {

        
        public int IdProducto { get; set; }

        [Required(ErrorMessage ="El nombre es obligatorio.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El numero de Stock es obligatorio.")]
        public int Stock { get; set; }


        [Required(ErrorMessage = "El precio es obligatorio.")]
        public decimal Precio { get; set; }

        [Required(ErrorMessage = "La UrlImagen es obligatoria.")]
        public string UrlImagen { get; set; }

        [Required(ErrorMessage = "El estado es obligatorio.")]
        public int Estado { get; set; }

        [Required(ErrorMessage = "La linea es obligatoria.")]
        public int IdLinea { get; set; }

    }
}
