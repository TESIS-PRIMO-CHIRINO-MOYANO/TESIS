using ApiGestionAgua.Data;
using ApiGestionAgua.Modelos;
using ApiGestionAgua.Repositorio.IRepositorio;

namespace ApiGestionAgua.Repositorio
{
    public class LineaRepositorio : ILineaRepositorio
    {
        private readonly AppDbContext _bd;


        public LineaRepositorio(AppDbContext bd)
        {
            _bd = bd;
        }

        public bool ActualizarLinea(Linea linea)
        {
            _bd.Linea.Update(linea);
            return Guardar();
        }
        public bool BorrarLinea(Linea linea)
        {
            _bd.Linea.Remove(linea);
            return Guardar();
        }

        public bool CrearLinea(Linea linea)
        {
            _bd.Linea.Add(linea);
            return Guardar();
        }

        public bool ExisteLinea(string Nombre)
        {
            bool valor = _bd.Linea.Any(p => p.Nombre.ToLower().Trim() == Nombre.ToLower().Trim());

            return valor;
        }

        public bool ExisteLinea(int IdLinea)
        {
            return _bd.Linea.Any(l => l.IdLinea == IdLinea);
        }

        public Linea GetLinea(int id)
        {
            return _bd.Linea.FirstOrDefault(l => l.IdLinea == id);
        }

        public ICollection<Linea> GetLineas()
        {
          return _bd.Linea.OrderBy(l => l.IdLinea).ToList();
        }

        public bool Guardar()
        {
            return _bd.SaveChanges() >= 0 ? true : false;

        }
    }
}
