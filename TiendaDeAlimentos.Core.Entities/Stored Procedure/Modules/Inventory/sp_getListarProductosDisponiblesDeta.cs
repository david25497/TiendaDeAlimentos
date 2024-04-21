namespace TiendaDeAlimentos.Core.Entities.Stored_Procedure.Modules.Inventory
{
    public class sp_getListarProductosDisponiblesDeta
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public decimal precio { get; set; }
        public int cantidadDisponible { get; set; }
    }
}
