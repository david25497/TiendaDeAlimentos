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
    [Authorize(Policy = "AdminPolicy")]
    [Produces("application/json")]
    [Route("api/TiendaDeAlimentos/[controller]/[action]")]
    [ApiController]
    public class GestionProductosController : ControllerBase
    {
        private readonly IGestionProductosServices service;    
    

        public GestionProductosController(IGestionProductosServices _service)
        {
            service = _service;
        }


        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(IResult<IEnumerable<ListarProductosDisponiblesDetaDTO>>))]
        public async Task<IActionResult> GetListarProductosDisponibles()
        {
            bool mostrarTodo = false;
            var response = await service.GetListarProductosDisponiblesDeta(mostrarTodo);

            return Ok(response);
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(IResult<IEnumerable<ListarProductosDisponiblesDetaDTO>>))]
        public async Task<IActionResult> GetListarProductos()
        {
            bool mostrarTodo = true;
            var response = await service.GetListarProductosDisponiblesDeta(mostrarTodo);

            return Ok(response);
        }

        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(IResult<string>))]
        public async Task<IActionResult> SetActualizarProducto(ActualizarProductoDTO _actualizarProductoDTO)
        {
            var response = await service.SetActualizarProducto(_actualizarProductoDTO);

            return Ok(response);
        }


        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(IResult<string>))]
        public async Task<IActionResult> SetInsertarProducto(InsertarProductoDTO _insertarProductoDTO)
        {
            var response = await service.SetInsertarProducto(_insertarProductoDTO);

            return Ok(response);
        }


        [HttpDelete]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(IResult<string>))]
        public async Task<IActionResult> SetEliminarProducto(int _id)
        {
            var response = await service.SetEliminarProducto(_id);

            return Ok(response);
        }
        

    }
}
