using ApiGestionAgua.Modelos;
using ApiGestionAgua.Modelos.Dtos;

namespace ApiGestionAgua.Repositorio.IRepositorio
{
    public interface IPedidoRepositorio
    {

        Pedido GetPedido(int IdPedido);

        PedidoDTO GetPedidoPorIdPedido(int IdPedido);

        List<PedidoDTO> GetPedidoCliente(int IdCliente);

        Task<Pedido> CrearPedido(PedidoDTO pedidoDTO);

        bool borrarPedido (int IdPedido);

        bool ModificarPedido(PedidoDTO pedidoDTO);

        bool Guardar();

    }
}
