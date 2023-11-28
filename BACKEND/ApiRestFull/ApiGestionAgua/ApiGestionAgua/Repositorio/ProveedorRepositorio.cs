using ApiGestionAgua.Data;
using ApiGestionAgua.Modelos;
using ApiGestionAgua.Repositorio.IRepositorio;

namespace ApiGestionAgua.Repositorio
{
    public class ProveedorRepositorio : IProveedorRepositorio
    {
        private readonly AppDbContext _bd;

        public ProveedorRepositorio(AppDbContext db)
        {
            _bd = db;
        }

        public bool ActualizarProveedor(Proveedor Proveedor)
        {
            _bd.Proveedor.Update(Proveedor);
            return Guardar();
        }

        public bool BorrarProveedor(Proveedor Proveedor)
        {
            _bd.Proveedor.Remove(Proveedor);
            return Guardar();
        }

        public bool CrearProveedor(Proveedor Proveedor)
        {
            _bd.Proveedor.Add(Proveedor);
            return Guardar();
        }

        public bool ExisteProveedor(string Nombre)
        {
            bool valor = _bd.Proveedor.Any(p => p.Nombre.ToLower().Trim() == Nombre.ToLower().Trim());

            return valor;
        }

        public bool ExisteProveedor(int IdProveedor)
        {
            return _bd.Proveedor.Any(p => p.IdProveedor == IdProveedor);
        }

        public Proveedor GetProveedor(int id)
        {
            return _bd.Proveedor.FirstOrDefault(p => p.IdProveedor == id);
        }

        public ICollection<Proveedor> GetProveedores()
        {
            return _bd.Proveedor.OrderBy(p => p.IdProveedor).ToList();
        }

        public bool Guardar()
        {
            return _bd.SaveChanges() >= 0 ? true : false;
        }


    }
}
