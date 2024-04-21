using AutoMapper;
using TiendaDeAlimentos.Core.Application.DTOs.Modules.Inventory;
using TiendaDeAlimentos.Core.Entities.Stored_Procedure.Modules.Inventory;

namespace GestionCampanas.Core.Application.Mappings.Sistema
{
   
    public class InventoryMappings : Profile
    {
        public InventoryMappings()
        {
            CreateMap<sp_getListarProductosDisponibles, ListarProductosDisponiblesDTO>();
            CreateMap<sp_getListarProductosDisponiblesDeta, ListarProductosDisponiblesDetaDTO>();
            CreateMap<sp_getListarProdXPedido, ListarProdXPedidoDTO>();
            
        }

    }



}
