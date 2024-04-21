using System;
using System.Collections.Generic;
using System.Text;

namespace TiendaDeAlimentos.Core.Application.DTOs.Modules.Inventory
{
    public class InsertarProductoDTO
    {
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public decimal precio { get; set; }
        public int cantidad { get; set; }

    }
}
