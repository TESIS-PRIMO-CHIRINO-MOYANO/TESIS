using ApiGestionAgua.Data;
using ApiGestionAgua.Modelos;
using ApiGestionAgua.Repositorio.IRepositorio;

namespace ApiGestionAgua.Repositorio
{
    public class CuentaCorrienteRepositorio : ICuentaRepositorio
    {
        private readonly AppDbContext _bd;

        public CuentaCorrienteRepositorio(AppDbContext db)
        {
            _bd = db;
        }

        public bool ActualizarCuentaCorriente(CuentaCorriente cuentaCorriente)
        {
            _bd.CuentaCorriente.Update(cuentaCorriente);
            return Guardar();
        }

        public bool BorrarCuentaCorriente(CuentaCorriente cuentaCorriente)
        {
            _bd.CuentaCorriente.Remove(cuentaCorriente);
            return Guardar();
        }

        public bool CrearCuentaCorriente(CuentaCorriente cuentaCorriente)
        {
            _bd.CuentaCorriente.Add(cuentaCorriente);
            return Guardar();
        }

        //aca hay que ver como buscar la cuenta
        public bool ExisteCuentaCorriente(int IdCuenta)
        {
            return _bd.CuentaCorriente.Any(p => p.IdCuenta == IdCuenta);
        }

        public CuentaCorriente GetCuentaCorriente(int id)
        {
            return _bd.CuentaCorriente.FirstOrDefault(p => p.IdCuenta == id);
        }

        public ICollection<CuentaCorriente> GetCuentaCorrientes()
        {
            return _bd.CuentaCorriente.OrderBy(p => p.IdCuenta).ToList();
        }

        public bool Guardar()
        {
            return _bd.SaveChanges() >= 0 ? true : false;
        }
    }
}
