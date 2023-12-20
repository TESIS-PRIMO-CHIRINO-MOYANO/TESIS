using ApiGestionAgua.Modelos;

namespace ApiGestionAgua.Repositorio.IRepositorio
{
    public interface ICompraRepositorio
    {

        ICollection<Compra> GetCompras();

        Compra GetCompra(int id);

        bool ExisteCompra(int IdCompra);

        bool CrearCompra(Compra compra);

        bool ActualizarCompra(Compra compra);

        bool BorrarCompra(Compra compra);

        bool Guardar();

    }
}
