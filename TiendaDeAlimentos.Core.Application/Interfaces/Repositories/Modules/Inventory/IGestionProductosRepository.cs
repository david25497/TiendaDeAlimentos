using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TiendaDeAlimentos.Core.Application.DTOs.Modules.Inventory;
using TiendaDeAlimentos.Core.Entities.Stored_Procedure.Modules.Inventory;
using TiendaDeAlimentos.Core.Entities.Stored_Procedure.SystemConfig.Login;

namespace TiendaDeAlimentos.Core.Application.Interfaces.Repositories.Modules.Inventory
{
    public interface IGestionProductosRepository
    {
        /// <summary>
        /// Lista los productos disponible
        /// </summary>
        Task<IEnumerable<sp_getListarProductosDisponiblesDeta>> GetListarProductosDisponiblesDeta(bool _mostrarTodo);

        /// <summary>
        /// Actualiza el producto
        /// </summary>
        Task<string> SetActualizarProducto(int _id, string _nombre, string _descripcion, decimal _precio, int _cantidad);

        /// <summary>
        /// Inserta un nuevo producto
        /// </summary>
        Task<string> SetInsertarProducto(string _nombre, string _descripcion, decimal _precio, int _cantidad);
        
        /// <summary>
        /// Elimina un producto
        /// </summary>
        Task<string> SetEliminarProducto(int _id);

    }
}
