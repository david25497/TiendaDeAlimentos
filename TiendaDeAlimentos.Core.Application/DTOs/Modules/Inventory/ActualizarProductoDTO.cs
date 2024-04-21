using System;
using System.Collections.Generic;
using System.Text;

namespace TiendaDeAlimentos.Core.Application.DTOs.Modules.Inventory
{
    public class ActualizarProductoDTO
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public decimal precio { get; set; }
        public int cantidad { get; set; }

    }
}
