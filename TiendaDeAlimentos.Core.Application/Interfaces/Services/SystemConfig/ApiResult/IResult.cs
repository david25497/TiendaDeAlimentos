using System.Collections.Generic;

namespace TiendaDeAlimentos.Core.Application.Interfaces.Services.SystemConfig.ApiResult
{
    public interface IResult
    {
        bool Failed { get; }
        List<string> Messages { get; set; }
        bool Successed { get; set; }
    }

    public interface IResult<out T> : IResult
    {
        T Data { get; }
    }
}