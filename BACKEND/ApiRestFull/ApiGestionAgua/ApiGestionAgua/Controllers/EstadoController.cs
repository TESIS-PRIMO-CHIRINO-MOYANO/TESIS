using ApiGestionAgua.Modelos;
using ApiGestionAgua.Modelos.Dtos;
using ApiGestionAgua.Repositorio.IRepositorio;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;


namespace ApiGestionAgua.Controllers
{
    [Route("api/estado")]
    [ApiController]
    public class EstadoController : ControllerBase
    {
        private readonly IEstadoRepositorio _eRepo;
        private readonly IMapper _mapper;

        public EstadoController(IEstadoRepositorio eRepo, IMapper mapper)
        {
            _eRepo = eRepo;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public IActionResult GetEstados()
        {
            var ListaEstado = _eRepo.GetEstados();

            var ListaEstadoDTO = new List<EstadoDTO>();

            foreach (var lista in ListaEstado)
            {
                ListaEstadoDTO.Add(_mapper.Map<EstadoDTO>(lista));
            }
            return Ok(ListaEstadoDTO);

        }

        [HttpGet("{IdEstado:int}", Name = "GetEstado")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public IActionResult GetEstado(int IdEstado)
        {
            var itemEstado = _eRepo.GetEstado(IdEstado);
            if (itemEstado == null)
            {
                return NotFound();
            }
            var itemEstadoDTO = _mapper.Map<EstadoDTO>(itemEstado);
            return Ok(itemEstadoDTO);
        }
        [HttpPost]
        [ProducesResponseType(201, Type = typeof(EstadoDTO))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult CrearEstado([FromBody] EstadoDTO estadoDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (estadoDTO == null)
            {
                return BadRequest(ModelState);
            }
            if (_eRepo.ExisteEstado(estadoDTO.Nombre))
            {
                ModelState.AddModelError("", "El estado ya existe");
                return BadRequest(ModelState);
            }
            var estado = _mapper.Map<Estado>(estadoDTO);
            if (!_eRepo.CrearEstado(estado))
            {
                ModelState.AddModelError("", $"Algo salió mal guardando el registro {estado.Nombre}");
                return StatusCode(500, ModelState);
            }
            var estadoCreadoDTO = _mapper.Map<EstadoDTO>(estado);
            return CreatedAtRoute("GetEstado", new { IdEstado = estado.IdEstado }, estadoCreadoDTO);
        }
        [HttpPatch("{IdEstado:int}", Name = "ActualizarEstado")]//Este te deja actualizar parcialmente el put si osi tenes qu epasar todos los campos
        [ProducesResponseType(201, Type = typeof(InsumoDTO))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult ActualizarEstado(int IdEstado, [FromBody] EstadoDTO estadoDTO)
        {
            if (!ModelState.IsValid || estadoDTO == null || estadoDTO.IdEstado != IdEstado)
            {
                return BadRequest(ModelState);
            }
            var estado = _mapper.Map<Estado>(estadoDTO);
            if (!_eRepo.ActualizarEstado(estado))
            {
                ModelState.AddModelError("", $"Algo salió mal guardando el registro {estado.Nombre}");
                return StatusCode(500, ModelState);
            }
            var estadoCreadoDTO = _mapper.Map<EstadoDTO>(estado);
            return NoContent();
        }
        [HttpDelete("{IdEstado:int}", Name = "BorrarEstado")]//Este te deja actualizar parcialmente el put si osi tenes qu epasar todos los campos
        [ProducesResponseType(201, Type = typeof(EstadoDTO))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public IActionResult BorrarEstado(int IdEstado)
        {
            if (!_eRepo.ExisteEstado(IdEstado))
            {
                return NotFound();
            }
            var estado = _eRepo.GetEstado(IdEstado);
            if (!_eRepo.BorrarEstado(estado))
            {
                ModelState.AddModelError("", $"Algo salió mal borrando el registro {estado.Nombre}");
                return StatusCode(500, ModelState);
            }
            var estadoCreadoDTO = _mapper.Map<EstadoDTO>(estado);

            return NoContent();

        }
    }
}
