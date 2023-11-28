using ApiGestionAgua.Modelos;
using ApiGestionAgua.Modelos.Dtos;
using ApiGestionAgua.Repositorio.IRepositorio;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ApiGestionAgua.Controllers
{
    [ApiController]
    [Route("api/proveedor")]
    public class ProveedorController : ControllerBase
    {

        private readonly IMapper _mapper;
        private readonly IProveedorRepositorio _pRepo;

        public ProveedorController(IProveedorRepositorio pRepo, IMapper mapper)
        {
            _pRepo = pRepo;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetProveedores()
        {
            var ListaProveedores = _pRepo.GetProveedores();

            var ListaProveedoresDTO = new List<ProveedorDTO>();

            foreach (var lista in ListaProveedores)
            {
                ListaProveedoresDTO.Add(_mapper.Map<ProveedorDTO>(lista));
            }
            return Ok(ListaProveedoresDTO);

        }

        [HttpGet("{IdProveedor:int}", Name = "GetProveedor")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public IActionResult GetProveedor(int IdProveedor)
        {
            var itemProveedor = _pRepo.GetProveedor(IdProveedor);

            if (itemProveedor == null)
            {
                return NotFound();
            }
            var itemProveedorDTO = _mapper.Map<ProveedorDTO>(itemProveedor);
            return Ok(itemProveedorDTO);

        }

        [HttpPost]
        [ProducesResponseType(201, Type = typeof(ProveedorDTO))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public IActionResult CrearProveedor([FromBody] ProveedorDTO proveedorDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (proveedorDTO == null)
            {
                return BadRequest(ModelState);
            }
            if (_pRepo.ExisteProveedor(proveedorDTO.Nombre))
            {
                ModelState.AddModelError("", "El producto ya existe");
                return BadRequest(ModelState);
            }

            var proveedor = _mapper.Map<Proveedor>(proveedorDTO);
            if (!_pRepo.CrearProveedor(proveedor))
            {
                ModelState.AddModelError("", $"Algo salió mal guardando el registro {proveedor.Nombre}");
                return StatusCode(500, ModelState);
            }
            var proveedorCreadoDTO = _mapper.Map<ProveedorDTO>(proveedor);

            return CreatedAtRoute("GetProveedor", new { IdProveedor = proveedor.IdProveedor }, proveedorCreadoDTO);

        }

        [HttpPatch("{IdProveedor:int}", Name = "ActualizarProveedor")]//Este te deja actualizar parcialmente el put si osi tenes qu epasar todos los campos
        [ProducesResponseType(201, Type = typeof(ProveedorDTO))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public IActionResult ActualizarProveedor(int IdProveedor, [FromBody] ProveedorDTO proveedorDTO)
        {

            if (!ModelState.IsValid || proveedorDTO == null || proveedorDTO.IdProveedor != IdProveedor)
            {
                return BadRequest(ModelState);
            }


            var proveedor = _mapper.Map<Proveedor>(proveedorDTO);
            if (!_pRepo.ActualizarProveedor(proveedor))
            {
                ModelState.AddModelError("", $"Algo salió mal guardando el registro {proveedor.Nombre}");
                return StatusCode(500, ModelState);
            }
            var proveedorCreadoDTO = _mapper.Map<ProveedorDTO>(proveedor);

            return NoContent();

        }

        [HttpDelete("{IdProveedor:int}", Name = "BorrarProveedor")]//Este te deja actualizar parcialmente el put si osi tenes qu epasar todos los campos
        [ProducesResponseType(201, Type = typeof(ProductoDTO))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public IActionResult BorrarProveedor(int IdProveedor)
        {
            if (!_pRepo.ExisteProveedor(IdProveedor))
            {
                return NotFound();
            }
            var proveedor = _pRepo.GetProveedor(IdProveedor);
            if (!_pRepo.BorrarProveedor(proveedor))
            {
                ModelState.AddModelError("", $"Algo salió mal borrando el registro {proveedor.Nombre}");
                return StatusCode(500, ModelState);
            }
            var proveedorCreadoDTO = _mapper.Map<ProveedorDTO>(proveedor);

            return NoContent();

        }

    }
}
