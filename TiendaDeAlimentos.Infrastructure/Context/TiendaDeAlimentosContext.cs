using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TiendaDeAlimentos.Core.Entities.Stored_Procedure.Modules.Inventory;
using TiendaDeAlimentos.Core.Entities.Stored_Procedure.SystemConfig.Login;

namespace TiendaDeAlimentos.Infrastructure.Context
{
    public class TiendaDeAlimentosContext:DbContext
    {
        public TiendaDeAlimentosContext(DbContextOptions<TiendaDeAlimentosContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            builder.Entity<sp_getUsuarioAcceso>().HasNoKey().ToView(null);
            builder.Entity<sp_getUsuario>().HasNoKey().ToView(null);
            builder.Entity<sp_getListarProductosDisponibles>().HasNoKey().ToView(null);
            builder.Entity<sp_getListarProductosDisponiblesDeta>().HasNoKey().ToView(null);
            builder.Entity<sp_getListarUsuarios>().HasNoKey().ToView(null);
            builder.Entity<sp_getListarProdXPedido>().HasNoKey().ToView(null);
            
            //Aplicamos de forma automatica las configuraciones que se encuentran en la carpeta CONFIGURACIONES
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

    }
}
