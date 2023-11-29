using ApiGestionAgua.Data;
using ApiGestionAgua.Modelos;
using ApiGestionAgua.Repositorio.IRepositorio;

namespace ApiGestionAgua.Repositorio
{
    public class ModuloRepositorio : IModuloRepositorio
    {

        private readonly AppDbContext _bd;

        public ModuloRepositorio(AppDbContext db)
        {
            _bd = db;
        }

        public bool ActualizarModulo(Modulo modulo)
        {
            _bd.Modulo.Update(modulo);
            return Guardar();
        }

        public bool BorrarModulo(Modulo modulo)
        {
            _bd.Modulo.Remove(modulo);
            return Guardar();
        }

        public bool CrearModulo(Modulo modulo)
        {
            _bd.Modulo.Add(modulo);
            return Guardar();
        }

        public bool ExisteModulo(string Nombre)
        {
            bool valor = _bd.Modulo.Any(p => p.Nombre.ToLower().Trim() == Nombre.ToLower().Trim());

            return valor;
        }

        public bool ExisteModulo(int IdModulo)
        {
            return _bd.Modulo.Any(p => p.IdModulo == IdModulo);
        }

        public Modulo GetModulo(int id)
        {
            return _bd.Modulo.FirstOrDefault(p => p.IdModulo == id);
        }

        public ICollection<Modulo> GetModulos()
        {
            return _bd.Modulo.OrderBy(p => p.IdModulo).ToList();
        }

        public bool Guardar()
        {
            return _bd.SaveChanges() >= 0 ? true : false;
        }
    }
}
