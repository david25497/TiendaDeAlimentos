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
    [Produces("application/json")]
    [Route("api/TiendaDeAlimentos/[controller]/[action]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUserServices _service;
        IConfiguration Configuration;
    

        public LoginController(IConfiguration Config, IUserServices service)
        {
            this.Configuration = Config;
            _service = service;
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(IResult<string>))]
        public async Task<IActionResult> Login(LoginDTO _loginDTO)
        {
            TokenConfigDTO _TokenConfigDTO = new TokenConfigDTO();
            _TokenConfigDTO.key = Configuration["AuthSettings:key"];
            _TokenConfigDTO.durationInMinutes= Configuration["AuthSettings:DurationInMinutes"];
            _TokenConfigDTO.issuer = Configuration["AuthSettings:Issuer"];
            _TokenConfigDTO.audience = Configuration["AuthSettings:Audience"];
            var response = await _service.LoginAsync(_loginDTO, _TokenConfigDTO);

            return Ok(response);
        }


        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(IResult<IEnumerable<ListarUsuariosDTO>>))]
        public async Task<IActionResult> GetListarUsuariosPrueba()
        {

            var response = await _service.GetListarUsuarios();

            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(IResult<string>))]
        public async Task<IActionResult> SetInsertarUsuarioAdminPrueba(InsertarUsuariosDTO _insertarUsuarioDTO)
        {
           
            var response = await _service.SetInsertarUsuario(_insertarUsuarioDTO, 1);

            return Ok(response);
        }


        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(IResult<string>))]
        public async Task<IActionResult> SetInsertarUsuarioEstandarPrueba(InsertarUsuariosDTO _insertarUsuarioDTO)
        {

            var response = await _service.SetInsertarUsuario(_insertarUsuarioDTO, 2);

            return Ok(response);
        }




    }
}
