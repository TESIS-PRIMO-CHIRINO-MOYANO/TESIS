using ApiGestionAgua.Modelos;
using ApiGestionAgua.Modelos.Dtos;
using ApiGestionAgua.Repositorio.IRepositorio;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ApiGestionAgua.Controllers
{
    [ApiController]
    [Route("api/insumo")]

    public class InsumoController : ControllerBase
    {

        private readonly IInsumoRepositorio _iRepo;
        private readonly IMapper _mapper;

        public InsumoController(IInsumoRepositorio iRepo, IMapper mapper)
        {
            _iRepo = iRepo;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public IActionResult GetInsumos()
        {
            var ListaInsumo = _iRepo.GetInsumos();

            var ListaInsumoDTO = new List<InsumoDTO>();

            foreach (var lista in ListaInsumo)
            {
                ListaInsumoDTO.Add(_mapper.Map<InsumoDTO>(lista));
            }
            return Ok(ListaInsumoDTO);

        }

        [HttpGet("{IdInsumo:int}", Name = "GetInsumo")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public IActionResult GetInsumo(int IdInsumo)
        {
            var itemInsumo = _iRepo.GetInsumo(IdInsumo);

            if (itemInsumo == null)
            {
                return NotFound();
            }
            var itemInsumoDTO = _mapper.Map<InsumoDTO>(itemInsumo);
            return Ok(itemInsumoDTO);

        }

        [HttpPost]
        [ProducesResponseType(201, Type = typeof(InsumoDTO))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public IActionResult CrearInsumo([FromBody] InsumoDTO insumoDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (insumoDTO == null)
            {
                return BadRequest(ModelState);
            }
            if (_iRepo.ExisteInsumo(insumoDTO.Nombre))
            {
                ModelState.AddModelError("", "El producto ya existe");
                return BadRequest(ModelState);
            }

            var insumo = _mapper.Map<Insumo>(insumoDTO);
            if (!_iRepo.CrearInsumo(insumo))
            {
                ModelState.AddModelError("", $"Algo salió mal guardando el registro {insumo.Nombre}");
                return StatusCode(500, ModelState);
            }
            var insumoCreadoDTO = _mapper.Map<InsumoDTO>(insumo);

            return CreatedAtRoute("GetInsumo", new { IdInsumo = insumo.IdInsumo }, insumoCreadoDTO);

        }

        [HttpPatch("{IdInsumo:int}", Name = "ActualizarInsumo")]//Este te deja actualizar parcialmente el put si osi tenes qu epasar todos los campos
        [ProducesResponseType(201, Type = typeof(InsumoDTO))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public IActionResult ActualizarInsumo(int IdInsumo, [FromBody] InsumoDTO insumoDTO)
        {

            if (!ModelState.IsValid || insumoDTO == null || insumoDTO.IdInsumo != IdInsumo)
            {
                return BadRequest(ModelState);
            }


            var insumo = _mapper.Map<Insumo>(insumoDTO);
            if (!_iRepo.ActualizarInsumo(insumo))
            {
                ModelState.AddModelError("", $"Algo salió mal guardando el registro {insumo.Nombre}");
                return StatusCode(500, ModelState);
            }
            var productoCreadoDTO = _mapper.Map<ProductoDTO>(insumo);

            return NoContent();

        }

        [HttpDelete("{IdInsumo:int}", Name = "BorrarInsumo")]//Este te deja actualizar parcialmente el put si osi tenes qu epasar todos los campos
        [ProducesResponseType(201, Type = typeof(InsumoDTO))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public IActionResult BorrarInsumo(int IdInsumo)
        {
            if (!_iRepo.ExisteInsumo(IdInsumo))
            {
                return NotFound();
            }
            var insumo = _iRepo.GetInsumo(IdInsumo);
            if (!_iRepo.BorrarInsumo(insumo))
            {
                ModelState.AddModelError("", $"Algo salió mal borrando el registro {insumo.Nombre}");
                return StatusCode(500, ModelState);
            }
            var insumoCreadoDTO = _mapper.Map<InsumoDTO>(insumo);

            return NoContent();

        }

    }
}
