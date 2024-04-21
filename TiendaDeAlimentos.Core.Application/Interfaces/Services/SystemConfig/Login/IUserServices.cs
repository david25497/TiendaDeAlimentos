using System.Collections.Generic;
using System.Threading.Tasks;
using TiendaDeAlimentos.Core.Application.DTOs.SystemConfig.Config;
using TiendaDeAlimentos.Core.Application.DTOs.SystemConfig.Login;
using TiendaDeAlimentos.Core.Application.Interfaces.Services.SystemConfig.ApiResult;

namespace TiendaDeAlimentos.Core.Application.Interfaces.Services.SystemConfig.Login
{
    public interface IUserServices
    {
        Task<IResult<string>> LoginAsync(LoginDTO _loginDTO, TokenConfigDTO _TokenConfigDTO);

        Task<IResult<IEnumerable<ListarUsuariosDTO>>> GetListarUsuarios();

        Task<IResult<string>> SetInsertarUsuario(InsertarUsuariosDTO _insertarUsuarioDTO, int _idRol);


    }
}
