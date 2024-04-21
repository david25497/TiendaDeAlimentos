using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TiendaDeAlimentos.Core.Application.DTOs.Modules.Inventory;
using TiendaDeAlimentos.Core.Application.Interfaces.Repositories.Modules.Inventory;
using TiendaDeAlimentos.Core.Application.Interfaces.Repositories.SystemConfig.Login;
using TiendaDeAlimentos.Core.Entities.Stored_Procedure.Modules.Inventory;
using TiendaDeAlimentos.Core.Entities.Stored_Procedure.SystemConfig.Login;
using TiendaDeAlimentos.Infrastructure.Context;

namespace TiendaDeAlimentos.Infrastructure.Repositories.Modules.Inventory
{
    public class GestionProductosRepository : IGestionProductosRepository
    {
        private readonly TiendaDeAlimentosContext context;

        public GestionProductosRepository(TiendaDeAlimentosContext _context) => context = _context;


        public async Task<IEnumerable<sp_getListarProductosDisponiblesDeta>> GetListarProductosDisponiblesDeta(bool _mostrarTodo)
        {
            var mostrarTodo = new SqlParameter { ParameterName = "@mostrarTodo", Value = _mostrarTodo, SqlDbType = System.Data.SqlDbType.Bit };
            try
            {
                return await Task.Run(() =>
                {
                    return context.Set<sp_getListarProductosDisponiblesDeta>().FromSqlRaw("EXEC [dbo].[sp_getListarProductosDisponiblesDeta]  @mostrarTodo", mostrarTodo).AsEnumerable();
                });
            }
            catch (Exception)
            {
                return null;
            }

        }


        public async Task<string> SetActualizarProducto(int _id, string _nombre, string _descripcion, decimal _precio, int _cantidad)
        {
            List<SqlParameter> parameters = new List<SqlParameter> {
                new SqlParameter { ParameterName = "@id", Value =_id, SqlDbType = System.Data.SqlDbType.Int },
                new SqlParameter { ParameterName = "@nombre", Value =_nombre, SqlDbType = System.Data.SqlDbType.VarChar },
                new SqlParameter { ParameterName = "@descripcion", Value =_descripcion, SqlDbType = System.Data.SqlDbType.VarChar },
                new SqlParameter { ParameterName = "@precio", Value =_precio, SqlDbType = System.Data.SqlDbType.Decimal },
                new SqlParameter { ParameterName = "@cantidad", Value =_cantidad, SqlDbType = System.Data.SqlDbType.Int }

            };

            try
            {

                await context.Database.ExecuteSqlRawAsync("EXEC [dbo].[sp_setActualizarProducto] @id , @nombre , @descripcion , @precio, @cantidad ", parameters);
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


        public async Task<string> SetInsertarProducto(string _nombre, string _descripcion, decimal _precio, int _cantidad)
        {
            List<SqlParameter> parameters = new List<SqlParameter> {
                new SqlParameter { ParameterName = "@nombre", Value =_nombre, SqlDbType = System.Data.SqlDbType.VarChar },
                new SqlParameter { ParameterName = "@descripcion", Value =_descripcion, SqlDbType = System.Data.SqlDbType.VarChar },
                new SqlParameter { ParameterName = "@precio", Value =_precio, SqlDbType = System.Data.SqlDbType.Decimal },
                new SqlParameter { ParameterName = "@cantidad", Value =_cantidad, SqlDbType = System.Data.SqlDbType.Int }
             
            };
            try
            {

                await context.Database.ExecuteSqlRawAsync("EXEC [dbo].[sp_setInsertarProducto] @nombre , @descripcion , @precio, @cantidad ", parameters);
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

       
        public async Task<string> SetEliminarProducto(int _id)
        {
            List<SqlParameter> parameters = new List<SqlParameter> {
                new SqlParameter { ParameterName = "@id", Value =_id, SqlDbType = System.Data.SqlDbType.Int }

            };
            try
            {

                await context.Database.ExecuteSqlRawAsync("EXEC [dbo].[sp_setEliminarProducto] @id ", parameters);
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



    }
}