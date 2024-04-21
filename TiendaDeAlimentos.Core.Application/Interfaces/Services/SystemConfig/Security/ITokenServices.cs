using System.Threading.Tasks;
using TiendaDeAlimentos.Core.Application.DTOs.SystemConfig.Config;

namespace TiendaDeAlimentos.Core.Application.Interfaces.Services.SystemConfig.Security
{
    public interface ITokenServices
    {
        Task<string> GenerateTokenAsync(string _user, string _email, string _id, string _rol, TokenConfigDTO _TokenConfigDTO);
    }
}
