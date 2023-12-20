using ApiGestionAgua.Data;
using ApiGestionAgua.Modelos;
using ApiGestionAgua.Repositorio.IRepositorio;
using System.Text.RegularExpressions;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace ApiGestionAgua.Repositorio
{
    public class ZonaRepositorio : IZonaRepositorio
    {
        private readonly AppDbContext _bd;
        public ZonaRepositorio(AppDbContext db)
        {
            _bd = db;
        }
        public bool ActualizarZona(Zona zona)
        {
            _bd.Zona.Update(zona);
            return Guardar();
        }

        public bool BorrarZonar(Zona zona)
        {
            _bd.Zona.Remove(zona);
            return Guardar();

        }

        public bool CrearZona(Zona zona)
        {
            _bd.Zona.Add(zona);
            return Guardar();
        }
        public bool ExisteZona(string Nombre)
        {
            bool valor = _bd.Zona.Any(z => z.Nombre.ToLower().Trim() == Nombre.ToLower().Trim());
            return valor;
        }

        public bool ExisteZona(int IdZona)
        {
            return _bd.Zona.Any(z => z.IdZona == IdZona);
        }

        public Zona GetZona(int id)
        {
            return _bd.Zona.FirstOrDefault(z => z.IdZona == id);
        }

        public ICollection<Zona> GetZonas()
        {
            return _bd.Zona.OrderBy(z => z.IdZona).ToList();
        }

        public bool Guardar()
        {
            return _bd.SaveChanges() >= 0 ? true : false;
        }
    }
}
