using ApiGestionAgua.Data;
using ApiGestionAgua.Modelos;
using ApiGestionAgua.Repositorio.IRepositorio;
using System.Text.RegularExpressions;
namespace ApiGestionAgua.Repositorio
{
    public class VehiculoRepositorio : IVehiculoRepositorio
    {
        private readonly AppDbContext _bd;
        public VehiculoRepositorio(AppDbContext db)
        {
            _bd = db;
        }

        public bool ActualizarVehiculo(Vehiculo vehiculo)
        {
            _bd.Vehiculo.Update(vehiculo);
            return Guardar();
        }

        public bool BorrarVehiculo(Vehiculo vehiculo)
        {
            _bd.Vehiculo.Remove(vehiculo);
            return Guardar();
        }

        public bool CrearVehiculo(Vehiculo vehiculo)
        {
            _bd.Vehiculo.Add(vehiculo);
            return Guardar();
        }

        public bool ExisteVehiculo(string Nombre)
        {
            bool valor = _bd.Vehiculo.Any(v => v.Nombre.ToLower().Trim() == Nombre.ToLower().Trim());
            return valor;

        }

        public bool ExisteVehiculo(int IdVehiculo)
        {
            return _bd.Vehiculo.Any(v => v.IdPatente == IdVehiculo);
        }

        public ICollection<Vehiculo> GetVehiculos()
        {
            return _bd.Vehiculo.OrderBy( v=> v.IdPatente).ToList();
        }

        public Vehiculo GetVehiculo(int id)
        {
           return _bd.Vehiculo.FirstOrDefault(v=> v.IdPatente ==id);
        }

        public bool Guardar()
        {
            return _bd.SaveChanges() >= 0 ? true : false;
        }

      
    }
}
