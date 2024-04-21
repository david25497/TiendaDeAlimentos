using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TiendaDeAlimentos.Core.Application.DTOs.Modules.Inventory;
using TiendaDeAlimentos.Core.Application.DTOs.SystemConfig.Config;
using TiendaDeAlimentos.Core.Application.DTOs.SystemConfig.Login;
using TiendaDeAlimentos.Core.Application.Interfaces.Repositories.SystemConfig.Login;
using TiendaDeAlimentos.Core.Application.Interfaces.Services.Modules.Inventory;
using TiendaDeAlimentos.Core.Application.Interfaces.Services.SystemConfig.ApiResult;
using TiendaDeAlimentos.Core.Application.Interfaces.Services.SystemConfig.Login;

namespace TiendaDeAlimentos.Presentation.API.Controllers
{
    [Authorize(Policy = "UserPolicy")]
    [Produces("application/json")]
    [Route("api/TiendaDeAlimentos/[controller]/[action]")]
    [ApiController]
    public class GestionPedidosController : ControllerBase
    {
      
        private readonly IGestionPedidosServices _service;
    

        public GestionPedidosController(IGestionPedidosServices service)
        {         
            _service = service;
        }
                  

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(IResult<IEnumerable<ListarProductosDisponiblesDTO>>))]
        public async Task<IActionResult> GetListarProductosDisponibles()
        {
                      
            var response = await _service.GetListarProductosDisponibles();

            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(IResult<string>))]
        public async Task<IActionResult> SetInsertarProductoAPedido(InsertarProductoAPedidoDTO _insertarProductoAPedidoDTO)
        {
            var user = HttpContext.User;
            var idUsuario = int.Parse(user.FindFirst("Id").Value);
            var response = await _service.SetAgregarProductoAPedido(_insertarProductoAPedidoDTO, idUsuario);

            return Ok(response);
        }

        [HttpDelete]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(IResult<string>))]
        public async Task<IActionResult> SetEliminarProductoAPedido(int idProducto)
        {
            InsertarProductoAPedidoDTO insertarProductoAPedidoDTO = new InsertarProductoAPedidoDTO();
            insertarProductoAPedidoDTO.idProducto = idProducto;
            insertarProductoAPedidoDTO.cantidad = 0;
            
            var user = HttpContext.User;
            var idUsuario = int.Parse(user.FindFirst("Id").Value);
            var response = await _service.SetEliminarProductoAPedido(insertarProductoAPedidoDTO, idUsuario);

            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(IResult<string>))]
        public async Task<IActionResult> SetConfirmacionDePedido()
        {
            var user = HttpContext.User;
            var idUsuario = int.Parse(user.FindFirst("Id").Value);
            var usuario = user.FindFirst("User").Value;
            var emailDestino = user.FindFirst("Email").Value;

            var response = await _service.SetConfirmacionDePedido(idUsuario, usuario, emailDestino);

            return Ok(response);
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(IResult<IEnumerable<ListarProdXPedidoDTO>>))]
        public async Task<IActionResult> GetListarProdXPedido()
        {
            var user = HttpContext.User;
            var idUsuario = int.Parse(user.FindFirst("Id").Value);
            
            var response = await _service.GetListarProdXPedido(idUsuario);

            return Ok(response);
        }


    }
}
