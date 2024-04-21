using System;
using System.Collections.Generic;
using System.Text;

namespace TiendaDeAlimentos.Core.Application.DTOs.Modules.Inventory
{
    public class ListarProdXPedidoDTO
    {
        public string nombreProducto { get; set; }
        public int cantidadEnPedido { get; set; }
    }
}
