using ApiGestionAgua.Modelos;
using ApiGestionAgua.Repositorio.IRepositorio;
using ApiGestionAgua.Data;

namespace ApiGestionAgua.Repositorio
{
    public class EstadoRepositorio : IEstadoRepositorio
    {
        private readonly AppDbContext _bd;
        public EstadoRepositorio(AppDbContext bd)
        {
            _bd = bd;
        }
        public bool ActualizarEstado(Estado estado)
        {
            _bd.Estado.Update(estado);
            return Guardar();
        }

        public bool BorrarEstado(Estado estado)
        {
            _bd.Estado.Remove(estado);
            return Guardar();
        }

        public bool CrearEstado(Estado estado)
        {
            _bd.Estado.Add(estado);
            return Guardar();
        }

        public bool ExisteEstado(string Nombre)
        {
            bool valor = _bd.Estado.Any(e => e.Nombre.ToLower().Trim() == Nombre.ToLower().Trim());
            return valor;
        }

        public bool ExisteEstado(int idEstado)
        {
            return _bd.Estado.Any(e => e.IdEstado == idEstado);
        }

        public Estado GetEstado(int id)
        {
            return _bd.Estado.FirstOrDefault(e => e.IdEstado == id);
        }

        public ICollection<Estado> GetEstados()
        {
           return _bd.Estado.OrderBy(e => e.IdEstado).ToList();
        }

        public bool Guardar()
        {
            return _bd.SaveChanges() >= 0 ? true : false;
        }
    }
}
