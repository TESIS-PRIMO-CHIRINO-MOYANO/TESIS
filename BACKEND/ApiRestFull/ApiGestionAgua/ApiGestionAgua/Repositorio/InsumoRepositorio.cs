using ApiGestionAgua.Data;
using ApiGestionAgua.Modelos;
using ApiGestionAgua.Repositorio.IRepositorio;

namespace ApiGestionAgua.Repositorio
{
    public class InsumoRepositorio : IInsumoRepositorio
    {
        private readonly AppDbContext _bd;

        public InsumoRepositorio(AppDbContext db)
        {
            _bd = db;
        }

        public bool ActualizarInsumo(Insumo insumo)
        {
            _bd.Insumo.Update(insumo);
            return Guardar();
        }

        public bool BorrarInsumo(Insumo insumo)
        {
            _bd.Insumo.Remove(insumo);
            return Guardar();
        }

        public bool CrearInsumo(Insumo insumo)
        {
            _bd.Insumo.Add(insumo);
            return Guardar();
        }

        public bool ExisteInsumo(string Nombre)
        {
            bool valor = _bd.Insumo.Any(p => p.Nombre.ToLower().Trim() == Nombre.ToLower().Trim());

            return valor;
        }

        public bool ExisteInsumo(int IdInsumo)
        {
            return _bd.Insumo.Any(p => p.IdInsumo == IdInsumo);
        }

        public Insumo GetInsumo(int id)
        {
            return _bd.Insumo.FirstOrDefault(p => p.IdInsumo == id);
        }

        public ICollection<Insumo> GetInsumos()
        {
            return _bd.Insumo.OrderBy(p => p.IdInsumo).ToList();
        }

        public bool Guardar()
        {
            return _bd.SaveChanges() >= 0 ? true : false;
        }
    }
}
