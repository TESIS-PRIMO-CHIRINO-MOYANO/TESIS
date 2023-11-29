using ApiGestionAgua.Modelos;
using ApiGestionAgua.Modelos.Dtos;
using ApiGestionAgua.Repositorio.IRepositorio;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ApiGestionAgua.Controllers
{
    [ApiController]
    [Route("api/cuentaCorriente")]

    public class CuentaCorrienteController : ControllerBase
    {

        private readonly ICuentaRepositorio _cRepo;
        private readonly IMapper _mapper;

        public CuentaCorrienteController(ICuentaRepositorio cRepo, IMapper mapper)
        {
            _cRepo = cRepo;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public IActionResult GetCuentaCorrientes()
        {
            var ListaCuenta = _cRepo.GetCuentaCorrientes();

            var ListaCuentaDTO = new List<CuentaCorrienteDTO>();

            foreach (var lista in ListaCuenta)
            {
                ListaCuentaDTO.Add(_mapper.Map<CuentaCorrienteDTO>(lista));
            }
            return Ok(ListaCuentaDTO);

        }

        [HttpGet("{IdCuenta:int}", Name = "GetCuentaCorriente")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public IActionResult GetCuentaCorriente(int IdCuenta)
        {
            var itemCuenta = _cRepo.GetCuentaCorriente(IdCuenta);

            if (itemCuenta == null)
            {
                return NotFound();
            }
            var itemCuentaDTO = _mapper.Map<CuentaCorrienteDTO>(itemCuenta);
            return Ok(itemCuentaDTO);

        }

        [HttpPost]
        [ProducesResponseType(201, Type = typeof(CuentaCorrienteDTO))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public IActionResult CrearCuentaCorriente([FromBody] CuentaCorrienteDTO cuentaCorrienteDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (cuentaCorrienteDTO == null)
            {
                return BadRequest(ModelState);
            }
            if (_cRepo.ExisteCuentaCorriente(cuentaCorrienteDTO.IdCuenta))
            {
                ModelState.AddModelError("", "El producto ya existe");
                return BadRequest(ModelState);
            }

            var cuenta = _mapper.Map<CuentaCorriente>(cuentaCorrienteDTO);
            if (!_cRepo.CrearCuentaCorriente(cuenta))
            {
                ModelState.AddModelError("", $"Algo salió mal guardando el registro {cuenta.IdCuenta}");
                return StatusCode(500, ModelState);
            }
            var cuentaCreadaDTO = _mapper.Map<CuentaCorrienteDTO>(cuenta);

            return CreatedAtRoute("GetCuentaCorriente", new { IdCuenta = cuenta.IdCuenta }, cuentaCreadaDTO);

        }

        [HttpPatch("{IdCuenta:int}", Name = "ActualizarCuentaCorriente")]//Este te deja actualizar parcialmente el put si osi tenes qu epasar todos los campos
        [ProducesResponseType(201, Type = typeof(CuentaCorrienteDTO))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public IActionResult ActualizarCuentaCorriente(int IdCuenta, [FromBody] CuentaCorrienteDTO cuentaCorrienteDTO)
        {

            if (!ModelState.IsValid || cuentaCorrienteDTO == null || cuentaCorrienteDTO.IdCuenta != IdCuenta)
            {
                return BadRequest(ModelState);
            }


            var cuenta = _mapper.Map<CuentaCorriente>(cuentaCorrienteDTO);
            if (!_cRepo.ActualizarCuentaCorriente(cuenta))
            {
                ModelState.AddModelError("", $"Algo salió mal guardando el registro {cuenta.IdCuenta}");
                return StatusCode(500, ModelState);
            }
            var cuentaCreadaDTO = _mapper.Map<CuentaCorrienteDTO>(cuenta);

            return NoContent();

        }

        [HttpDelete("{IdCuenta:int}", Name = "BorrarCuentaCorriente")]//Este te deja actualizar parcialmente el put si osi tenes qu epasar todos los campos
        [ProducesResponseType(201, Type = typeof(CuentaCorrienteDTO))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public IActionResult BorrarCuentaCorriente(int IdCuenta)
        {
            if (!_cRepo.ExisteCuentaCorriente(IdCuenta))
            {
                return NotFound();
            }
            var cuenta = _cRepo.GetCuentaCorriente(IdCuenta);
            if (!_cRepo.BorrarCuentaCorriente(cuenta))
            {
                ModelState.AddModelError("", $"Algo salió mal borrando el registro {cuenta.IdCuenta}");
                return StatusCode(500, ModelState);
            }
            var productoCreadoDTO = _mapper.Map<CuentaCorrienteDTO>(cuenta);

            return NoContent();

        }

    }
}
