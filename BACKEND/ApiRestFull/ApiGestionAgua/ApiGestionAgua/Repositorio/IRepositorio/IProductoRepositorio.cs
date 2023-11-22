using ApiGestionAgua.Modelos;

namespace ApiGestionAgua.Repositorio.IRepositorio
{
    public interface IProductoRepositorio
    {

        ICollection<Producto> GetProductos();

        Producto GetProducto(int id);

        bool ExisteProducto(string Nombre);

        bool ExisteProducto(int IdProducto);
        bool CrearProducto(Producto producto);

        bool ActualizarProducto(Producto producto);

        bool BorrarProducto(Producto producto);

        bool Guardar();
    }
}
