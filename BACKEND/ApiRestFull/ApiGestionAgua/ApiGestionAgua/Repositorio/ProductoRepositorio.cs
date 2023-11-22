using ApiGestionAgua.Data;
using ApiGestionAgua.Modelos;
using ApiGestionAgua.Repositorio.IRepositorio;
using System.Text.RegularExpressions;

namespace ApiGestionAgua.Repositorio
{
    public class ProductoRepositorio : IProductoRepositorio
    {

        private readonly AppDbContext _bd;

        public ProductoRepositorio(AppDbContext db)
        {
            _bd = db;
        }

        public bool ActualizarProducto(Producto producto)
        {

            _bd.Producto.Update(producto);
            return Guardar();
        }

        public bool BorrarProducto(Producto producto)
        {
            _bd.Producto.Remove(producto);
            return Guardar();
        }

        public bool CrearProducto(Producto producto)
        {
            _bd.Producto.Update(producto);
            return Guardar();
        }

        public bool ExisteProducto(string Nombre)
        {

            bool valor = _bd.Producto.Any(p => p.Nombre.ToLower().Trim() == Nombre.ToLower().Trim());

            return valor;

        }

        public bool ExisteProducto(int IdProducto)
        {
            return _bd.Producto.Any(p=> p.IdProducto == IdProducto);    
        }

        public Producto GetProducto(int id)
        {
            return _bd.Producto.FirstOrDefault(p=>p.IdProducto == id);
        }

        public ICollection<Producto> GetProductos()
        {
            return _bd.Producto.OrderBy(p=>p.IdProducto).ToList();
        }

        public bool Guardar()
        {
            //si guardo algo va a ser mayor a cero retorna true indicando que hubo cambios
            //si no hubo cambios es igual a cero y retorna false
            return _bd.SaveChanges()>=0? true: false;
        }
    }
}
