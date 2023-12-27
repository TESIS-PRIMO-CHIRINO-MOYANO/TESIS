using System.ComponentModel.DataAnnotations.Schema;

namespace ApiGestionAgua.Modelos.Dtos
{
    public class PedidoDTO
    {
        
        public int IdPedido { get; set; }

        public DateTime FechaPedido { get; set; }


        public decimal ImporteTotal { get; set; }

        public int IdCliente { get; set; }

        public int? IdPatente { get; set; }

        public int IdBarrio { get; set; }

        public int IdEstado { get; set; }

        public ProductosPedidoDTO[] productosPedidoDTO { get; set; }


    }
}
