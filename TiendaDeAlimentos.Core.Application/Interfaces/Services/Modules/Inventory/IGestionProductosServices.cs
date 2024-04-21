using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TiendaDeAlimentos.Core.Application.DTOs.Modules.Inventory;
using TiendaDeAlimentos.Core.Application.DTOs.SystemConfig.Config;
using TiendaDeAlimentos.Core.Application.DTOs.SystemConfig.Login;
using TiendaDeAlimentos.Core.Application.Interfaces.Services.SystemConfig.ApiResult;
using TiendaDeAlimentos.Core.Entities.Stored_Procedure.Modules.Inventory;

namespace TiendaDeAlimentos.Core.Application.Interfaces.Services.Modules.Inventory
{
    public interface IGestionProductosServices
    {       
        Task<IResult<IEnumerable<ListarProductosDisponiblesDetaDTO>>> GetListarProductosDisponiblesDeta(bool _mostrarTodo);

        Task<IResult<string>> SetActualizarProducto(ActualizarProductoDTO _actualizarProductoDTO);

        Task<IResult<string>> SetInsertarProducto(InsertarProductoDTO _insertarProductoDTO);

        Task<IResult<string>> SetEliminarProducto(int _id);

    }
}
