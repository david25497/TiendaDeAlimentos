using System;
using System.Linq;
using System.Threading.Tasks;
using TiendaDeAlimentos.Core.Application.DTOs.SystemConfig.Login;
using TiendaDeAlimentos.Core.Application.Interfaces.Repositories.SystemConfig.Login;
using TiendaDeAlimentos.Core.Application.Interfaces.Services.SystemConfig.ApiResult;
using TiendaDeAlimentos.Core.Application.Interfaces.Services.SystemConfig.Login;
using TiendaDeAlimentos.Core.Application.Services.SystemConfig.ApiResult;
using TiendaDeAlimentos.Core.Application.DTOs.SystemConfig.Config;
using TiendaDeAlimentos.Core.Application.Interfaces.Services.SystemConfig.Security;
using System.Collections.Generic;
using AutoMapper;
using TiendaDeAlimentos.Core.Application.Interfaces.Services.SystemConfig.Email;

namespace TiendaDeAlimentos.Core.Application.Services.SystemConfig.Login
{
    public class UserServices:IUserServices
    {
        private readonly IUserRepository repository;
        private readonly IMapper mapper;
        private readonly ITokenServices service;
        public UserServices(IUserRepository _repository, IMapper _mapper, ITokenServices _service )
        {
            repository = _repository;
            mapper = _mapper;
            service = _service;
        }
        
        public async Task<IResult<string>> LoginAsync(LoginDTO _loginDTO, TokenConfigDTO _TokenConfigDTO)
        {
            try
            {
                var result = await repository.GetUsuarioAcceso(_loginDTO.usuario, _loginDTO.clave);

                if (result == null)
                    return Result<string>.Fail("Se ha producido un error al recuperar la información");

                if (!result.FirstOrDefault().accesoConcedido)
                {
                    return Result<string>.Fail("Usuario o clave invalido");
                }
                
                var  result2 = await repository.GetUsuarioRol(_loginDTO.usuario);
                if (result == null)
                    return Result<string>.Fail("Se ha producido un error al recuperar la información");


                string id = result2.FirstOrDefault().id.ToString();
                string rol = result2.FirstOrDefault().nombreRol;
                string email = result2.FirstOrDefault().email;
                string token =  await service.GenerateTokenAsync(_loginDTO.usuario, id, rol, email,_TokenConfigDTO) ;
                
                return Result<string>.Success("TOKEN", token);
            }
            catch (Exception e)
            {

                return Result<string>.Fail("Se ha producido un error");

            }
        }

   
        public async Task<IResult<IEnumerable<ListarUsuariosDTO>>> GetListarUsuarios()
        {
          
            try
            {
                var result = await repository.GetListarUsuarios();

                if (result == null)
                    return Result<IEnumerable<ListarUsuariosDTO>>.Fail("Se ha producido un error al recuperar la información", new List<ListarUsuariosDTO>());

                var rolesDTO = mapper.Map<IEnumerable<ListarUsuariosDTO>>(result);

                return Result<IEnumerable<ListarUsuariosDTO>>.Success(rolesDTO);

            }
            catch (Exception e)
            {

                return Result<IEnumerable<ListarUsuariosDTO>>.Fail("Se ha producido un error al convertir la información", new List<ListarUsuariosDTO>());
            }
        }

        public async Task<IResult<string>> SetInsertarUsuario(InsertarUsuariosDTO _insertarUsuarioDTO , int _idRol)
        {
            try
            {
                var result = await repository.SetInsertarUsuario(_insertarUsuarioDTO.usuario, _insertarUsuarioDTO.clave, _insertarUsuarioDTO.email, _idRol);

                if (result == null)
                    return Result<string>.Fail("Se ha producido un error al recuperar la información");

                if (!result.Equals("OK"))
                {
                    return Result<string>.Fail(result);
                }

                return Result<string>.Success("Usuario Agregado");

            }
            catch (Exception e)
            {

                return Result<string>.Fail("Se ha producido un error en el proceso");
            }
        }
        
    }
}
