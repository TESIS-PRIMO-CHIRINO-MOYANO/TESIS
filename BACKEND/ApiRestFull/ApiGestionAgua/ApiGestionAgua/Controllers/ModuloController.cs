using ApiGestionAgua.Modelos;
using ApiGestionAgua.Modelos.Dtos;
using ApiGestionAgua.Repositorio.IRepositorio;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ApiGestionAgua.Controllers
{
    [ApiController]
    [Route("api/modulo")]

    public class ModuloController : ControllerBase
    {

        private readonly IModuloRepositorio _mRepo;
        private readonly IMapper _mapper;

        public ModuloController(IModuloRepositorio mRepo,IMapper mapper)
        {

            _mRepo = mRepo;
            _mapper = mapper;

        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public IActionResult GetModulos()
        {
            var ListaModulo = _mRepo.GetModulos();

            var ListaModuloDTO = new List<ModuloDTO>();

            foreach (var lista in ListaModulo)
            {
                ListaModuloDTO.Add(_mapper.Map<ModuloDTO>(lista));
            }
            return Ok(ListaModuloDTO);

        }

        [HttpGet("{IdModulo:int}", Name = "GetModulo")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public IActionResult GetModulo(int IdModulo)
        {
            var itemModulo = _mRepo.GetModulo(IdModulo);

            if (itemModulo == null)
            {
                return NotFound();
            }
            var itemModuloDTO = _mapper.Map<ModuloDTO>(itemModulo);
            return Ok(itemModuloDTO);

        }

        [HttpPost]
        [ProducesResponseType(201, Type = typeof(ModuloDTO))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public IActionResult CrearModulo([FromBody] ModuloDTO moduloDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (moduloDTO == null)
            {
                return BadRequest(ModelState);
            }
            if (_mRepo.ExisteModulo(moduloDTO.Nombre))
            {
                ModelState.AddModelError("", "El producto ya existe");
                return BadRequest(ModelState);
            }

            var modulo = _mapper.Map<Modulo>(moduloDTO);
            if (!_mRepo.CrearModulo(modulo))
            {
                ModelState.AddModelError("", $"Algo salió mal guardando el registro {modulo.Nombre}");
                return StatusCode(500, ModelState);
            }
            var moduloCreadoDTO = _mapper.Map<ModuloDTO>(modulo);

            return CreatedAtRoute("GetProducto", new { IdModulo = modulo.IdModulo }, moduloCreadoDTO);

        }

        [HttpPatch("{IdModulo:int}", Name = "ActualizarModulo")]//Este te deja actualizar parcialmente el put si osi tenes qu epasar todos los campos
        [ProducesResponseType(201, Type = typeof(ModuloDTO))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public IActionResult ActualizarModulo(int IdModulo, [FromBody] ModuloDTO moduloDTO)
        {

            if (!ModelState.IsValid || moduloDTO == null || moduloDTO.IdModulo != IdModulo)
            {
                return BadRequest(ModelState);
            }


            var modulo = _mapper.Map<Modulo>(moduloDTO);
            if (!_mRepo.ActualizarModulo(modulo))
            {
                ModelState.AddModelError("", $"Algo salió mal guardando el registro {modulo.Nombre}");
                return StatusCode(500, ModelState);
            }
            var moduloCreadoDTO = _mapper.Map<ModuloDTO>(modulo);

            return NoContent();

        }

        [HttpDelete("{IdModulo:int}", Name = "BorrarModulo")]//Este te deja actualizar parcialmente el put si osi tenes qu epasar todos los campos
        [ProducesResponseType(201, Type = typeof(ModuloDTO))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public IActionResult BorrarModulo(int IdModulo)
        {
            if (!_mRepo.ExisteModulo(IdModulo))
            {
                return NotFound();
            }
            var modulo = _mRepo.GetModulo(IdModulo);
            if (!_mRepo.BorrarModulo(modulo))
            {
                ModelState.AddModelError("", $"Algo salió mal borrando el registro {modulo.Nombre}");
                return StatusCode(500, ModelState);
            }
            var moduloCreadoDTO = _mapper.Map<ModuloDTO>(modulo);

            return NoContent();

        }

    }
}
