using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ApiGestionAgua.Modelos
{
    public class ProductoPedido
    {

        public int Cantidad { get; set; }

        public bool EsExtra { get; set; }

        [Required]
        [Column(TypeName = "decimal(11,2)")]
        public decimal Total { get; set; }

        public int IdPedido { get; set; }
        public Pedido Pedido { get; set; }

        public int IdProducto { get; set; }
        public Producto Producto { get; set; }

    }
}
