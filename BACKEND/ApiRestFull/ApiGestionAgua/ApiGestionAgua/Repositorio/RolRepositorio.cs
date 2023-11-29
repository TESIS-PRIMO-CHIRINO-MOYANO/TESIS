using ApiGestionAgua.Data;
using ApiGestionAgua.Modelos;
using ApiGestionAgua.Repositorio.IRepositorio;

namespace ApiGestionAgua.Repositorio
{
    public class RolRepositorio : IRolRepositorio
    {
        private readonly AppDbContext _bd;

        public RolRepositorio(AppDbContext db)
        {
            _bd = db;
        }

        public bool ActualizarRol(Rol rol)
        {
            _bd.Rol.Update(rol);
            return Guardar();
        }

        public bool BorrarRol(Rol rol)
        {
            _bd.Rol.Remove(rol);
            return Guardar();
        }

        public bool CrearRol(Rol rol)
        {
            _bd.Rol.Add(rol);
            return Guardar();
        }

        public bool ExisteRol(string Nombre)
        {
            bool valor = _bd.Rol.Any(p => p.Nombre.ToLower().Trim() == Nombre.ToLower().Trim());

            return valor;
        }

        public bool ExisteRol(int IdRol)
        {
            return _bd.Rol.Any(p => p.IdRol == IdRol);
        }

        public Rol GetRol(int id)
        {
            return _bd.Rol.FirstOrDefault(p => p.IdRol == id);
        }

        public ICollection<Rol> GetRoles()
        {
            return _bd.Rol.OrderBy(p => p.IdRol).ToList();
        }

        public bool Guardar()
        {
            return _bd.SaveChanges() >= 0 ? true : false;
        }
    }
}
