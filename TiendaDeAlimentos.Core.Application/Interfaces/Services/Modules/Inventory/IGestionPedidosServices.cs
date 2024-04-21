using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TiendaDeAlimentos.Core.Application.DTOs.Modules.Inventory;
using TiendaDeAlimentos.Core.Application.DTOs.SystemConfig.Config;
using TiendaDeAlimentos.Core.Application.DTOs.SystemConfig.Login;
using TiendaDeAlimentos.Core.Application.Interfaces.Services.SystemConfig.ApiResult;
using TiendaDeAlimentos.Core.Application.Services.SystemConfig.ApiResult;
using TiendaDeAlimentos.Core.Entities.Stored_Procedure.Modules.Inventory;

namespace TiendaDeAlimentos.Core.Application.Interfaces.Services.Modules.Inventory
{
    public interface IGestionPedidosServices
    {       
        Task<IResult<IEnumerable<ListarProductosDisponiblesDTO>>> GetListarProductosDisponibles();

        Task<IResult<string>> SetAgregarProductoAPedido(InsertarProductoAPedidoDTO _insertarProductoAPedidoDTO, int _usuario);


       Task<IResult<string>> SetEliminarProductoAPedido(InsertarProductoAPedidoDTO _insertarProductoAPedidoDTO, int _usuario);

        Task<IResult<string>> SetConfirmacionDePedido(int _idUsuario, string _usuario, string _emailDestino);

        Task<IResult<IEnumerable<ListarProdXPedidoDTO>>> GetListarProdXPedido(int _idUsuario);
        

    }
}
