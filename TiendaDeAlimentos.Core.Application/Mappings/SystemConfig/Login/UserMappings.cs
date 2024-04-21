using AutoMapper;
using TiendaDeAlimentos.Core.Application.DTOs.SystemConfig.Login;
using TiendaDeAlimentos.Core.Entities.Stored_Procedure.SystemConfig.Login;

namespace TiendaDeAlimentos.Core.Application.Mappings.SystemConfig.Login
{
    public class UserMappings : Profile
    {
        public UserMappings()
        {
            CreateMap<sp_getListarUsuarios, ListarUsuariosDTO>();
        }

    }
}
