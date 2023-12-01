using ApiGestionAgua.Data;
using ApiGestionAgua.Modelos;
using ApiGestionAgua.Repositorio.IRepositorio;

namespace ApiGestionAgua.Repositorio
{
    public class CompraRepositorio : ICompraRepositorio
    {
        private readonly AppDbContext _bd;

        public CompraRepositorio(AppDbContext db)
        {
            _bd = db;
        }

        public bool ActualizarCompra(Compra compra)
        {
            _bd.Compra.Update(compra);
            return Guardar();
        }

        public bool BorrarCompra(Compra compra)
        {
            _bd.Compra.Remove(compra);
            return Guardar();
        }

        public bool CrearCompra(Compra compra)
        {
            compra.Fecha = DateTime.Now;
            _bd.Compra.Add(compra);
            return Guardar();
        }

        public bool ExisteCompra(int IdCompra)
        {
            return _bd.Compra.Any(p => p.IdCompra == IdCompra);
        }

        public Compra GetCompra(int id)
        {
            return _bd.Compra.FirstOrDefault(p => p.IdCompra == id);
        }

        public ICollection<Compra> GetCompras()
        {
            return _bd.Compra.OrderBy(p => p.IdCompra).ToList();
        }

        public bool Guardar()
        {
            return _bd.SaveChanges() >= 0 ? true : false;
        }
    }
}
