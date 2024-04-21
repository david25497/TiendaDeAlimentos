using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TiendaDeAlimentos.Core.Entities.Stored_Procedure.Modules.Inventory;
using TiendaDeAlimentos.Core.Entities.Stored_Procedure.SystemConfig.Login;

namespace TiendaDeAlimentos.Core.Application.Interfaces.Repositories.Modules.Inventory
{
    public interface IGestionPedidosRepository
    {
        /// <summary>
        /// Lista los productos disponible
        /// </summary>
        Task<IEnumerable<sp_getListarProductosDisponibles>> GetListarProductosDisponibles();

        /// <summary>
        /// Marca el pedido como enviado
        /// </summary>
        Task<string> SetConfirmarEnvioPedido(int _IdUsuario);
        
        /// <summary>
        /// Confirma el pedido del cliente
        /// </summary>
        Task<string> SetConfirmarPedido(int _IdUsuario);

        /// <summary>
        /// Inserta o elimina un producto al pedido actualizando su cantidad
        /// </summary>
        Task<string> SetProcesarProductoAPedido(int _idProducto , int _cantidad , int _idUsuario);

        /// <summary>
        /// Lista los productos del pedido del usuario
        /// </summary>
        Task<IEnumerable<sp_getListarProdXPedido>> GetListarProdXPedido(int _idUsuario);


    }
}
