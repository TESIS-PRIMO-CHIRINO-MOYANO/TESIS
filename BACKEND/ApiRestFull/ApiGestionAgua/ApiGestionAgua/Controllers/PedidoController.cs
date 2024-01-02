using ApiGestionAgua.Modelos;
using ApiGestionAgua.Modelos.Dtos;
using ApiGestionAgua.Repositorio.IRepositorio;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ApiGestionAgua.Controllers
{
    [Route("api/pedido")]
    [ApiController]

    public class PedidoController : ControllerBase
    {
        private readonly IMapper _mapper;
        protected RespuestaAPI _respuestaAPI;
        private readonly IPedidoRepositorio _PRepo;

        public PedidoController(IPedidoRepositorio PRepo, IMapper mapper)
        {
            _PRepo = PRepo;
            this._respuestaAPI = new();
            _mapper = mapper;
        }

        [HttpPost("crearPedido")]
        [ProducesResponseType(201, Type = typeof(PedidoDTO))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> CrearPedido([FromBody] PedidoDTO pedidoDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (pedidoDTO == null)
            {
                return BadRequest(ModelState);
            }
            

            var pedido = await _PRepo.CrearPedido(pedidoDTO);
            if (pedido == null)
            {
                _respuestaAPI.statusCode = HttpStatusCode.BadRequest;
                _respuestaAPI.IsSucces = false;
                _respuestaAPI.ErrorMessages.Add("Error en el registro pedido.");
                return BadRequest(_respuestaAPI);
            }


            _respuestaAPI.statusCode = HttpStatusCode.OK;
            _respuestaAPI.IsSucces = true;
            return Ok(_respuestaAPI);

        }
        [HttpGet("ObtenerPedidosPorCliente/{idCliente}")]
        [ProducesResponseType(200, Type = typeof(List<PedidoDTO>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult ObtenerPedidosPorCliente(int idCliente)
        {
            try
            {
                var pedidosDTO = _PRepo.GetPedidoCliente(idCliente);
                if (pedidosDTO == null)
                {
                    _respuestaAPI.statusCode = HttpStatusCode.BadRequest;
                    _respuestaAPI.IsSucces = false;
                    _respuestaAPI.ErrorMessages.Add("Error al obtener pedidos.");
                    return BadRequest(_respuestaAPI);
                }
                _respuestaAPI.statusCode = HttpStatusCode.OK;
                _respuestaAPI.IsSucces = true;
                return Ok(pedidosDTO);
            }
            catch (Exception ex)
            {                
                _respuestaAPI.statusCode = HttpStatusCode.InternalServerError;
                _respuestaAPI.IsSucces = false;
                _respuestaAPI.ErrorMessages.Add("Error interno del servidor");
                return StatusCode(500, _respuestaAPI);
            }
        }
        [HttpGet("ObtenerPedidoPorIdPedido/{idPedido}")]
        [ProducesResponseType(200, Type = typeof(PedidoDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult ObtenerPedidoPorIdPedido(int idPedido)
        {
            try
            {
                var pedidoDTO = _PRepo.GetPedidoPorIdPedido(idPedido);

                if (pedidoDTO == null)
                {
                    _respuestaAPI.statusCode = HttpStatusCode.BadRequest;
                    _respuestaAPI.IsSucces = false;
                    _respuestaAPI.ErrorMessages.Add("No se encontró el pedido con el IdPedido especificado.");
                    return BadRequest(_respuestaAPI);
                }
                _respuestaAPI.statusCode = HttpStatusCode.OK;
                _respuestaAPI.IsSucces = true;
                return Ok(pedidoDTO);
            }
            catch (Exception ex)
            {                
                _respuestaAPI.statusCode = HttpStatusCode.InternalServerError;
                _respuestaAPI.IsSucces = false;
                _respuestaAPI.ErrorMessages.Add("Error interno del servidor");
                return StatusCode(500, _respuestaAPI);
            }
        }


        [HttpPatch("{IdPedido:int}", Name = "ModificarPedidio")]//Este te deja actualizar parcialmente el put si osi tenes qu epasar todos los campos
        [ProducesResponseType(201, Type = typeof(PedidoDTO))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public IActionResult ModificarPedidio(int IdPedido, [FromBody] PedidoDTO pedidoDTO)
        {

            if (!ModelState.IsValid || pedidoDTO == null || pedidoDTO.IdPedido != IdPedido)
            {
                return BadRequest(ModelState);
            }

            var pedidoVerif = _PRepo.GetPedidoPorIdPedido(IdPedido);

            if (pedidoDTO == null)
            {
                ModelState.AddModelError("", $"El pedido con ID {IdPedido} no se encontró o algo salió mal modificándolo.");
                return NotFound(ModelState);

            }
            if (!_PRepo.ModificarPedido(pedidoDTO))
            {
                ModelState.AddModelError("", $"Algo salió mal modificando el pedido");
                return StatusCode(500, ModelState);
            }
          
          

            return NoContent();

        }

        [HttpDelete("{IdPedido:int}", Name = "BorrarPedido")]
        [ProducesResponseType(201, Type = typeof(CompraDTO))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public IActionResult BorrarCompra(int IdPedido)
        {
            try
            {
                var exito = _PRepo.borrarPedido(IdPedido);

                if (!exito)
                {
                    // Puedes retornar un NotFound si el pedido no existe
                    return NotFound($"No se encontró un pedido con IdPedido: {IdPedido}");
                }

                return Ok("Pedido eliminado exitosamente");
            }
            catch (Exception ex)
            {
                // Manejar errores según tus necesidades
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }

        }

    }
}
