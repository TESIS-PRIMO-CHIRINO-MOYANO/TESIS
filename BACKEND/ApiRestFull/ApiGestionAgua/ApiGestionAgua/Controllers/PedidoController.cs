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


    }
}
