using ApiGestionAgua.Modelos;
using ApiGestionAgua.Modelos.Dtos;
using ApiGestionAgua.Repositorio.IRepositorio;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ApiGestionAgua.Controllers
{
    [ApiController]
    [Route("api/linea")]
    public class LineaController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ILineaRepositorio _lRepo;

        public LineaController(ILineaRepositorio lRepo, IMapper mapper)
        {
            _lRepo = lRepo;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetProductos()
        {
            var ListaLineas = _lRepo.GetLineas();

            var ListaLineasDTO = new List<LineaDTO>();

            foreach (var lista in ListaLineas)
            {
                ListaLineasDTO.Add(_mapper.Map<LineaDTO>(lista));
            }
            return Ok(ListaLineasDTO);

        }

        [HttpGet("{IdLinea:int}", Name = "GetLinea")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public IActionResult GetLinea(int IdLinea)
        {
            var itemLinea = _lRepo.GetLinea(IdLinea);

            if (itemLinea == null)
            {
                return NotFound();
            }
            var itemLineaDTO = _mapper.Map<LineaDTO>(itemLinea);
            return Ok(itemLineaDTO);

        }
        
        [HttpPost]
        [ProducesResponseType(201, Type = typeof(LineaDTO))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public IActionResult CrearLinea([FromBody] LineaDTO lineaDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (lineaDTO == null)
            {
                return BadRequest(ModelState);
            }
            if (_lRepo.ExisteLinea(lineaDTO.Nombre))
            {
                ModelState.AddModelError("", "El producto ya existe");
                return BadRequest(ModelState);
            }

            var linea = _mapper.Map<Linea>(lineaDTO);
            if (!_lRepo.CrearLinea(linea))
            {
                ModelState.AddModelError("", $"Algo salió mal guardando el registro {linea.Nombre}");
                return StatusCode(500, ModelState);
            }
            var lineaCreadaDTO = _mapper.Map<LineaDTO>(linea);

            return CreatedAtRoute("GetLinea", new { IdLinea = linea.IdLinea }, lineaCreadaDTO);

        }
        [HttpPatch("{idLinea:int}", Name = "ActualizarLinea")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public IActionResult ActualizarLinea(int idLinea, [FromBody] LineaDTO lineaDTO)
        {
            if (!ModelState.IsValid || lineaDTO == null || lineaDTO.IdLinea != idLinea)
            {
                return BadRequest(ModelState);
            }

            var linea = _mapper.Map<Linea>(lineaDTO);

            if (!_lRepo.ActualizarLinea(linea))
            {
                ModelState.AddModelError("", $"Algo salió mal guardando el registro {linea.Nombre}");
                return StatusCode(StatusCodes.Status500InternalServerError, ModelState);
            }

            return NoContent();
        }

        [HttpDelete("{idLinea:int}", Name = "BorrarLinea")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public IActionResult BorrarLinea(int idLinea)
        {
            if (!_lRepo.ExisteLinea(idLinea))
            {
                return NotFound();
            }

            var linea = _lRepo.GetLinea(idLinea);

            if (!_lRepo.BorrarLinea(linea))
            {
                ModelState.AddModelError("", $"Algo salió mal borrando el registro {linea.Nombre}");
                return StatusCode(StatusCodes.Status500InternalServerError, ModelState);
            }

            return NoContent();
        }


    }
}
