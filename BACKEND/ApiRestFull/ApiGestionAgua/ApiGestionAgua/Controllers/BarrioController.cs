using ApiGestionAgua.Modelos;
using ApiGestionAgua.Modelos.Dtos;
using ApiGestionAgua.Repositorio.IRepositorio;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiGestionAgua.Controllers
{
    [Route("api/barrio")]
    [ApiController]
    public class BarrioController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IBarrioRepositorio _bRepo;
        public BarrioController(IBarrioRepositorio bRepo, IMapper mapper)
        {
            _bRepo = bRepo;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public IActionResult GetBarrios()
        {
            var ListaBarrios = _bRepo.GetBarrios();

            var ListaBarriosDTO = new List<BarrioDTO>();

            foreach (var lista in ListaBarrios)
            {
                ListaBarriosDTO.Add(_mapper.Map<BarrioDTO>(lista));
            }
            return Ok(ListaBarriosDTO);

        }

        [HttpGet("{IdBarrio:int}", Name = "GetBarrio")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public IActionResult GetBarrio(int IdBarrio)
        {
            var itemBarrio = _bRepo.GetBarrio(IdBarrio);

            if (itemBarrio == null)
            {
                return NotFound();
            }
            var itemBarrioDto = _mapper.Map<BarrioDTO>(itemBarrio);
            return Ok(itemBarrioDto);

        }
        [HttpPost]
        [ProducesResponseType(201, Type = typeof(BarrioDTO))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public IActionResult CrearProducto([FromBody] BarrioDTO barrioDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (barrioDTO == null)
            {
                return BadRequest(ModelState);
            }
            if (_bRepo.ExisteBarrio(barrioDTO.Nombre))
            {
                ModelState.AddModelError("", "El barrio ya existe");
                return BadRequest(ModelState);
            }

            var barrio = _mapper.Map<Barrio>(barrioDTO);
            if (!_bRepo.CrearBarrio(barrio))
            {
                ModelState.AddModelError("", $"Algo salió mal guardando el registro {barrio.Nombre}");
                return StatusCode(500, ModelState);
            }
            var barrioCreadoDTO = _mapper.Map<BarrioDTO>(barrio);

            return CreatedAtRoute("GetBarrio", new { IdBarrio = barrio.IdBarrio}, barrioCreadoDTO);

        }
        [HttpPatch("{IdBarrio:int}", Name = "ActualizarBarrio")]//Este te deja actualizar parcialmente el put si osi tenes qu epasar todos los campos
        [ProducesResponseType(201, Type = typeof(VehiculoDTO))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public IActionResult ActualizarBarrio(int IdBarrio, [FromBody] BarrioDTO barrioDTO)
        {

            if (!ModelState.IsValid || barrioDTO == null || barrioDTO.IdBarrio != IdBarrio)
            {
                return BadRequest(ModelState);
            }


            var barrio = _mapper.Map<Barrio>(barrioDTO);
            if (!_bRepo.ActualizarBarrio(barrio))
            {
                ModelState.AddModelError("", $"Algo salió mal guardando el registro {barrio.Nombre}");
                return StatusCode(500, ModelState);
            }          
            return Ok();
        }
        [HttpDelete("{IdBarrio:int}", Name = "BorrarBarrio")]
        [ProducesResponseType(201, Type = typeof(VehiculoDTO))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public IActionResult BorrarBarrio(int IdBarrio)
        {
            if (!_bRepo.ExisteBarrio(IdBarrio))
            {
                return NotFound();
            }
            var barrio = _bRepo.GetBarrio(IdBarrio);
            if (!_bRepo.BorrarBarrio(barrio))
            {
                ModelState.AddModelError("", $"Algo salió mal borrando el registro {barrio.Nombre}");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }

    }
}
