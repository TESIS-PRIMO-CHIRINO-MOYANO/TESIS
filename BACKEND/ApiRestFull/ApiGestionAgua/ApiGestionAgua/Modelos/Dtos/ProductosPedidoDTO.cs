namespace ApiGestionAgua.Modelos.Dtos
{
    public class ProductosPedidoDTO
    {

        public int IdPedido { get; set; }

        public int IdProducto { get; set; }

        public int Cantidad { get; set; }

        public bool EsExtra { get; set; }

        public decimal Total { get; set; }

    }
}
