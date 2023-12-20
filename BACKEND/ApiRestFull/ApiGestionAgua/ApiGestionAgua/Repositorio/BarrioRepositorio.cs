using ApiGestionAgua.Data;
using ApiGestionAgua.Modelos;
using ApiGestionAgua.Repositorio.IRepositorio;

namespace ApiGestionAgua.Repositorio
{
    public class BarrioRepositorio : IBarrioRepositorio
    {
        private readonly AppDbContext _bd;
        public BarrioRepositorio(AppDbContext bd)
        {
            _bd = bd;
        }
        public bool ActualizarBarrio(Barrio barrio)
        {
           _bd.Barrio.Update(barrio);
            return Guardar();
        }

        public bool BorrarBarrio(Barrio barrio)
        {
            _bd.Barrio.Remove(barrio);
            return Guardar();
        }

        public bool CrearBarrio(Barrio barrio)
        {
            _bd.Barrio.Add(barrio);
            return Guardar();
        }

        public bool ExisteBarrio(string Nombre)
        {
            bool valor = _bd.Barrio.Any(b => b.Nombre.ToLower().Trim() == Nombre.ToLower().Trim());

            return valor;
        }

        public bool ExisteBarrio(int IdBarrio)
        {
            return _bd.Barrio.Any(b => b.IdBarrio == IdBarrio);
        }

        public Barrio GetBarrio(int id)
        {
            return _bd.Barrio.FirstOrDefault(b => b.IdBarrio == id);
        }

        public ICollection<Barrio> GetBarrios()
        {
            return _bd.Barrio.OrderBy(b=> b.IdBarrio).ToList();
        }

        public bool Guardar()
        {
            return _bd.SaveChanges() >= 0 ? true : false;
        }
    }
}
