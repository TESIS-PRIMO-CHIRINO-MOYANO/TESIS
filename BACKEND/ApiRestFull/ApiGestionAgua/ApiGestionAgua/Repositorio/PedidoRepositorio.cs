using ApiGestionAgua.Data;
using ApiGestionAgua.Modelos;
using ApiGestionAgua.Modelos.Dtos;
using ApiGestionAgua.Repositorio.IRepositorio;

namespace ApiGestionAgua.Repositorio
{
    public class PedidoRepositorio : IPedidoRepositorio
    {
        private readonly AppDbContext _bd;

        public PedidoRepositorio(AppDbContext bd)
        {
            _bd = bd;
        }

        public Pedido GetPedido(int IdPedido)
        {
            return _bd.Pedido.FirstOrDefault(p => p.IdPedido == IdPedido);
        }

        public PedidoDTO GetPedidoCompleto(int IdPedido)
        {
            throw new NotImplementedException();
        }

        public PedidoDTO GetPedidoCliente(int IdCliente)
        {
            throw new NotImplementedException();
        }

        public async Task<Pedido> CrearPedido(PedidoDTO pedidoDTO)
        {

            Pedido pedido = new Pedido()
            {
                
                FechaPedido=pedidoDTO.FechaPedido,
                ImporteTotal= pedidoDTO.ImporteTotal,
                IdCliente=pedidoDTO.IdCliente,
                IdPatente=pedidoDTO.IdPatente,
                IdEstado=pedidoDTO.IdEstado,
                IdBarrio=pedidoDTO.IdBarrio,
                
            };

            _bd.Pedido.Add(pedido);
            await _bd.SaveChangesAsync();

            foreach (ProductosPedidoDTO productoDTO in pedidoDTO.productosPedidoDTO)
            {
                // Crear una instancia de ProductoPedido y asignar propiedades
                ProductoPedido productoPedido = new ProductoPedido()
                {
                    IdPedido = pedido.IdPedido,
                    IdProducto = productoDTO.IdProducto,
                    Cantidad = productoDTO.Cantidad,
                    Total = productoDTO.Total,
                    EsExtra = false,
                    // Asignar otras propiedades del productoDTO según tu modelo
                    // productoPedido.Propiedad = productoDTO.Propiedad,
                };

                // Agregar el productoPedido a la colección en el contexto de la base de datos
                _bd.ProductoPedido.Add(productoPedido);
            }

            await _bd.SaveChangesAsync();
            return pedido;
        }

        public bool borrarPedido(int IdPedido)
        {
            throw new NotImplementedException();
        }

        public bool Guardar()
        {
            throw new NotImplementedException();
        }

        public bool ModificarPedido(PedidoDTO pedidoDTO)
        {
            throw new NotImplementedException();
        }
    }
}
