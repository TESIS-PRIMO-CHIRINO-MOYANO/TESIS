using ApiGestionAgua.Repositorio.IRepositorio;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ApiGestionAgua.Modelos;
using ApiGestionAgua.Modelos.Dtos;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ApiGestionAgua.Controllers
{
    [Route("api/vehiculo")]
    [ApiController]
    public class VehiculoController : ControllerBase
    {

        private readonly IMapper _mapper;
        private readonly IVehiculoRepositorio _vRepo;
        public VehiculoController(IVehiculoRepositorio vRepo,IMapper mapper)
        {
            _vRepo = vRepo;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public IActionResult GetVehiculos()
        {
            var ListaVehiculo = _vRepo.GetVehiculos();

            var ListaVehiculoDTO = new List<VehiculoDTO>();

            foreach (var lista in ListaVehiculo)
            {
                ListaVehiculoDTO.Add(_mapper.Map<VehiculoDTO>(lista));
            }
            return Ok(ListaVehiculoDTO);

        }

        [HttpGet("{IdVehiculo:int}", Name = "GetVehiculo")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public IActionResult GetVehiculo(int IdVehiculo)
        {
            var itemVehiculo = _vRepo.GetVehiculo(IdVehiculo);

            if (itemVehiculo == null)
            {
                return NotFound();
            }
            var itemVehiculoDTO = _mapper.Map<VehiculoDTO>(itemVehiculo);
            return Ok(itemVehiculoDTO);

        }

        [HttpPost]
        [ProducesResponseType(201, Type = typeof(VehiculoDTO))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public IActionResult CrearProducto([FromBody] VehiculoDTO vehiculoDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (vehiculoDTO == null)
            {
                return BadRequest(ModelState);
            }
            if (_vRepo.ExisteVehiculo(vehiculoDTO.Nombre))
            {
                ModelState.AddModelError("", "El vehiculo ya existe");
                return BadRequest(ModelState);
            }

            var vehiculo = _mapper.Map<Vehiculo>(vehiculoDTO);
            if (!_vRepo.CrearVehiculo(vehiculo))
            {
                ModelState.AddModelError("", $"Algo salió mal guardando el registro {vehiculo.Nombre}");
                return StatusCode(500, ModelState);
            }
            var vehiculoCreadoDTO = _mapper.Map<VehiculoDTO>(vehiculo);

            return CreatedAtRoute("GetVehiculo", new { IdVehiculo = vehiculo.IdPatente }, vehiculoCreadoDTO);

        }

        [HttpPatch("{IdVehiculo:int}", Name = "ActualizarVehiculo")]//Este te deja actualizar parcialmente el put si osi tenes qu epasar todos los campos
        [ProducesResponseType(201, Type = typeof(VehiculoDTO))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public IActionResult ActualizarProducto(int IdVehiculo, [FromBody] VehiculoDTO vehiculoDTO)
        {

            if (!ModelState.IsValid || vehiculoDTO == null || vehiculoDTO.IdPatente != IdVehiculo)
            {
                return BadRequest(ModelState);
            }


            var vehiculo = _mapper.Map<Vehiculo>(vehiculoDTO);
            if (!_vRepo.ActualizarVehiculo(vehiculo))
            {
                ModelState.AddModelError("", $"Algo salió mal guardando el registro {vehiculo.Nombre}");
                return StatusCode(500, ModelState);
            }
            var vehiculoCreadoDTO = _mapper.Map<VehiculoDTO>(vehiculo);

            return NoContent();

        }
        [HttpDelete("{IdVehiculo:int}", Name = "BorrarVehiculo")]
        [ProducesResponseType(201, Type = typeof(VehiculoDTO))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public IActionResult BorrarVehiculo(int IdVehiculo)
        {
            if (!_vRepo.ExisteVehiculo(IdVehiculo))
            {
                return NotFound();
            }
            var vehiculo = _vRepo.GetVehiculo(IdVehiculo);
            if (!_vRepo.BorrarVehiculo(vehiculo))
            {
                ModelState.AddModelError("", $"Algo salió mal borrando el registro {vehiculo.Nombre}");
                return StatusCode(500, ModelState);
            }         
            return NoContent();
        }

    }
}
