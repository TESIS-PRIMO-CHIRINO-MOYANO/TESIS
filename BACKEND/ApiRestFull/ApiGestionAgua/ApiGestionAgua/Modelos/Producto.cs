using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiGestionAgua.Modelos
{
    public class Producto
    {
        [Key]
        public int IdProducto { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public int Stock { get; set; }

        [Required]
        [Column(TypeName = "decimal(11,2)")]
        public decimal Precio { get; set; }

        [Required]
        public string UrlImagen { get; set; }

        [ForeignKey("IdLinea")]
        public int IdLinea { get; set; }

        public Linea Linea { get; set; }    

    }
}
