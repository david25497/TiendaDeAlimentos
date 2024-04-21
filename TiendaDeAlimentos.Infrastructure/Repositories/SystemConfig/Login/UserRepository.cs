using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TiendaDeAlimentos.Core.Application.Interfaces.Repositories.SystemConfig.Login;
using TiendaDeAlimentos.Core.Entities.Stored_Procedure.SystemConfig.Login;
using TiendaDeAlimentos.Infrastructure.Context;

namespace TiendaDeAlimentos.Infrastructure.Repositories.SystemConfig.Login
{
    public class UserRepository : IUserRepository
    {
        private readonly TiendaDeAlimentosContext context;

        public UserRepository(TiendaDeAlimentosContext _context) => context = _context;

        public async Task<IEnumerable<sp_getUsuarioAcceso>> GetUsuarioAcceso(string _usuario, string _clave)
        {
            try
            {
                var usuario = new SqlParameter { ParameterName = "@usuario", Value = _usuario, SqlDbType = System.Data.SqlDbType.NVarChar };
                var clave = new SqlParameter { ParameterName = "@clave", Value = _clave, SqlDbType = System.Data.SqlDbType.NVarChar };
                return await Task.Run(() =>
                {
                    return context.Set<sp_getUsuarioAcceso>().FromSqlRaw("EXEC sp_getUsuarioAcceso @usuario , @clave", usuario, clave).AsEnumerable();
                });
            }
            catch (Exception)
            {
                return null;
            }

        }

        public async Task<IEnumerable<sp_getUsuario>> GetUsuarioRol(string _usuario)
        {
            try
            {
                var usuario = new SqlParameter { ParameterName = "@usuario", Value = _usuario, SqlDbType = System.Data.SqlDbType.NVarChar };
                return await Task.Run(() =>
                {
                    return context.Set<sp_getUsuario>().FromSqlRaw("EXEC [dbo].[sp_getUsuario] @usuario ", usuario).AsEnumerable();
                });
            }
            catch (Exception)
            {
                return null;
            }

        }

        public async Task<IEnumerable<sp_getListarUsuarios>> GetListarUsuarios()
        {
            try
            {              
                return await Task.Run(() =>
                {
                    return context.Set<sp_getListarUsuarios>().FromSqlRaw("EXEC [dbo].[sp_getListarUsuarios] ").AsEnumerable();
                });
            }
            catch (Exception)
            {
                return null;
            }

        }


        public async Task<string> SetInsertarUsuario(string _usuario, string _clave, string _email, int _idRol)
        {
            List<SqlParameter> parameters = new List<SqlParameter> {
                new SqlParameter { ParameterName = "@usuario", Value =_usuario, SqlDbType = System.Data.SqlDbType.VarChar },
                new SqlParameter { ParameterName = "@clave", Value =_clave, SqlDbType = System.Data.SqlDbType.VarChar },                
                new SqlParameter { ParameterName = "@idRol", Value =_idRol, SqlDbType = System.Data.SqlDbType.Int },
                new SqlParameter { ParameterName = "@email", Value =_email, SqlDbType = System.Data.SqlDbType.VarChar }

            };
            try
            {
                await context.Database.ExecuteSqlRawAsync("EXEC [dbo].[sp_setInsertarUsuario] @usuario , @clave , @idRol ,@email ", parameters);
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
