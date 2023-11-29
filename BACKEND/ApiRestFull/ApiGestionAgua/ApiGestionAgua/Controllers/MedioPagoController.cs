using ApiGestionAgua.Modelos;
using ApiGestionAgua.Modelos.Dtos;
using ApiGestionAgua.Repositorio.IRepositorio;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ApiGestionAgua.Controllers
{
    [ApiController]
    [Route("api/medioPago")]

    public class MedioPagoController : ControllerBase
    {

        private readonly IMedioPagoRepositorio _mRepo;
        private readonly IMapper _mapper;

        public MedioPagoController(IMedioPagoRepositorio mRepo, IMapper mapper)
        {
            _mRepo = mRepo;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public IActionResult GetMediosPago()
        {
            var ListaMedioPago = _mRepo.GetMedioPagos();

            var ListaMedioPagoDTO = new List<MedioPagoDTO>();

            foreach (var lista in ListaMedioPago)
            {
                ListaMedioPagoDTO.Add(_mapper.Map<MedioPagoDTO>(lista));
            }
            return Ok(ListaMedioPagoDTO);

        }

        [HttpGet("{IdMedioPago:int}", Name = "GetMedioPago")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public IActionResult GetMedioPago(int IdMedioPago)
        {
            var itemMedioPago = _mRepo.GetMedioPago(IdMedioPago);

            if (itemMedioPago == null)
            {
                return NotFound();
            }
            var itemMedioPagoDTO = _mapper.Map<MedioPagoDTO>(itemMedioPago);
            return Ok(itemMedioPagoDTO);

        }

        [HttpPost]
        [ProducesResponseType(201, Type = typeof(MedioPagoDTO))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public IActionResult CrearMedioPago([FromBody] MedioPago medioPagoDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (medioPagoDTO == null)
            {
                return BadRequest(ModelState);
            }
            if (_mRepo.ExisteMedioPago(medioPagoDTO.Nombre))
            {
                ModelState.AddModelError("", "El producto ya existe");
                return BadRequest(ModelState);
            }

            var medioPago = _mapper.Map<MedioPago>(medioPagoDTO);
            if (!_mRepo.CrearMedioPago(medioPago))
            {
                ModelState.AddModelError("", $"Algo salió mal guardando el registro {medioPago.Nombre}");
                return StatusCode(500, ModelState);
            }
            var medioPagoCreadoDTO = _mapper.Map<MedioPagoDTO>(medioPago);

            return CreatedAtRoute("GetMedioPago", new { IdMedioPago = medioPago.IdMedioPago }, medioPagoCreadoDTO);

        }

        [HttpPatch("{IdMedioPago:int}", Name = "ActualizarMedioPago")]//Este te deja actualizar parcialmente el put si osi tenes qu epasar todos los campos
        [ProducesResponseType(201, Type = typeof(MedioPagoDTO))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public IActionResult ActualizarMedioPago(int IdMedioPago, [FromBody] MedioPagoDTO medioPagoDTO)
        {

            if (!ModelState.IsValid || medioPagoDTO == null || medioPagoDTO.IdMedioPago != IdMedioPago)
            {
                return BadRequest(ModelState);
            }


            var medioPago = _mapper.Map<MedioPago>(medioPagoDTO);
            if (!_mRepo.ActualizarMedioPago(medioPago))
            {
                ModelState.AddModelError("", $"Algo salió mal guardando el registro {medioPago.Nombre}");
                return StatusCode(500, ModelState);
            }
            var medioPagoCreadoDTO = _mapper.Map<MedioPagoDTO>(medioPago);

            return NoContent();

        }

        [HttpDelete("{IdMedioPago:int}", Name = "BorrarMedioPago")]//Este te deja actualizar parcialmente el put si osi tenes qu epasar todos los campos
        [ProducesResponseType(201, Type = typeof(ProductoDTO))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public IActionResult BorrarMedioPago(int IdMedioPago)
        {
            if (!_mRepo.ExisteMedioPago(IdMedioPago))
            {
                return NotFound();
            }
            var medioPago = _mRepo.GetMedioPago(IdMedioPago);
            if (!_mRepo.BorrarMedioPago(medioPago))
            {
                ModelState.AddModelError("", $"Algo salió mal borrando el registro {medioPago.Nombre}");
                return StatusCode(500, ModelState);
            }
            var medioPagoCreadoDTO = _mapper.Map<MedioPagoDTO>(medioPago);

            return NoContent();

        }

    }
}
