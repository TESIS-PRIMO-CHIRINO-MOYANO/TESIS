using ApiGestionAgua.Modelos;

namespace ApiGestionAgua.Repositorio.IRepositorio
{
    public interface IProveedorRepositorio
    {

        ICollection<Proveedor> GetProveedores();

        Proveedor GetProveedor(int id);

        bool ExisteProveedor(string Nombre);

        bool ExisteProveedor(int IdProveedor);
        bool CrearProveedor(Proveedor Proveedor);

        bool ActualizarProveedor(Proveedor Proveedor);

        bool BorrarProveedor(Proveedor Proveedor);

        bool Guardar();

    }
}
