using ApiGestionAgua.Data;
using ApiGestionAgua.Modelos;
using ApiGestionAgua.Repositorio.IRepositorio;

namespace ApiGestionAgua.Repositorio
{
    public class MedioPagoRepositorio : IMedioPagoRepositorio
    {
        private readonly AppDbContext _bd;

        public MedioPagoRepositorio(AppDbContext db)
        {
            _bd = db;
        }

        public bool ActualizarMedioPago(MedioPago medioPago)
        {
            _bd.MedioPago.Update(medioPago);
            return Guardar();
        }

        public bool BorrarMedioPago(MedioPago medioPago)
        {
            _bd.MedioPago.Remove(medioPago);
            return Guardar();
        }

        public bool CrearMedioPago(MedioPago medioPago)
        {
            _bd.MedioPago.Add(medioPago);
            return Guardar();
        }

        public bool ExisteMedioPago(string Nombre)
        {
            bool valor = _bd.MedioPago.Any(p => p.Nombre.ToLower().Trim() == Nombre.ToLower().Trim());

            return valor;
        }

        public bool ExisteMedioPago(int IdMedioPago)
        {
            return _bd.MedioPago.Any(p => p.IdMedioPago == IdMedioPago);
        }

        public ICollection<MedioPago> GetMedioPagos()
        {
            return _bd.MedioPago.OrderBy(p => p.IdMedioPago).ToList();
        }

        public MedioPago GetMedioPago(int id)
        {
            return _bd.MedioPago.FirstOrDefault(p => p.IdMedioPago == id);
        }

        public bool Guardar()
        {
            return _bd.SaveChanges() >= 0 ? true : false;
        }
    }
}
