using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiendaDeAlimentos.Core.Application.Interfaces.Repositories.Modules.Inventory;
using TiendaDeAlimentos.Core.Application.Interfaces.Repositories.SystemConfig.Login;
using TiendaDeAlimentos.Core.Entities.Stored_Procedure.Modules.Inventory;
using TiendaDeAlimentos.Core.Entities.Stored_Procedure.SystemConfig.Login;
using TiendaDeAlimentos.Infrastructure.Context;

namespace TiendaDeAlimentos.Infrastructure.Repositories.Modules.Inventory
{
    public class GestionPedidosRepository : IGestionPedidosRepository
    {
        private readonly TiendaDeAlimentosContext context;

        public GestionPedidosRepository(TiendaDeAlimentosContext _context) => context = _context;

        public async Task<IEnumerable<sp_getListarProductosDisponibles>> GetListarProductosDisponibles()
        {
            try
            {
                return await Task.Run(() =>
                {
                    return context.Set<sp_getListarProductosDisponibles>().FromSqlRaw("EXEC [dbo].[sp_getListarProductosDisponibles]").AsEnumerable();
                });
            }
            catch (Exception)
            {
                return null;
            }

        }
        
        public async Task<string> SetConfirmarEnvioPedido(int _IdUsuario)
        {
            List<SqlParameter> parameters = new List<SqlParameter> {
                new SqlParameter { ParameterName = "@IdUsuario", Value =_IdUsuario, SqlDbType = System.Data.SqlDbType.Int }
            };

            try
            {

                await context.Database.ExecuteSqlRawAsync("EXEC [dbo].[sp_setConfirmarEnvioPedido] @IdUsuario", parameters);
                return "OK";
            }
            catch (SqlException e)
            {
                return e.Message;
            }
            catch (Exception)
            {
                return null;
            }
        }

        
        public async Task<string> SetConfirmarPedido(int _IdUsuario)
        {
            List<SqlParameter> parameters = new List<SqlParameter> {
                new SqlParameter { ParameterName = "@IdUsuario", Value =_IdUsuario, SqlDbType = System.Data.SqlDbType.Int }
            };

            try
            {

                await context.Database.ExecuteSqlRawAsync("EXEC [dbo].[sp_setConfirmarPedido] @IdUsuario", parameters);
                return "OK";
            }
            catch (SqlException e)
            {
                return e.Message;
            }
            catch (Exception)
            {
                return null;
            }
        }


        public async Task<string> SetProcesarProductoAPedido(int _idProducto, int _cantidad, int _idUsuario)
        {
            List<SqlParameter> parameters = new List<SqlParameter> {
                new SqlParameter { ParameterName = "@idProducto", Value =_idProducto, SqlDbType = System.Data.SqlDbType.Int },
                new SqlParameter { ParameterName = "@cantidad", Value =_cantidad, SqlDbType = System.Data.SqlDbType.Int },
                new SqlParameter { ParameterName = "@idUsuario", Value =_idUsuario, SqlDbType = System.Data.SqlDbType.Int }
            };

            try
            {
                await context.Database.ExecuteSqlRawAsync("EXEC [dbo].[sp_setInsertarProductoAPedido] @idProducto , @cantidad , @IdUsuario", parameters);
                return "OK";
            }
            catch (SqlException e)
            {
                return e.Message;
            }
            catch (Exception)
            {
                return null;
            }
        }


       
        public async Task<IEnumerable<sp_getListarProdXPedido>> GetListarProdXPedido(int _idUsuario)
        {
            var idUsuario = new SqlParameter { ParameterName = "@idUsuario", Value = _idUsuario, SqlDbType = System.Data.SqlDbType.Int };
            try
            {
                return await Task.Run(() =>
                {
                    return context.Set<sp_getListarProdXPedido>().FromSqlRaw("EXEC [dbo].[sp_getListarProdXPedido]  @idUsuario", idUsuario).AsEnumerable();
                });
            }
            catch (Exception)
            {
                return null;
            }

        }



    }
}