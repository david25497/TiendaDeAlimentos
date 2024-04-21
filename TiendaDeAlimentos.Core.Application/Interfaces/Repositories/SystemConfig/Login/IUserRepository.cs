
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TiendaDeAlimentos.Core.Entities.Stored_Procedure.SystemConfig.Login;

namespace TiendaDeAlimentos.Core.Application.Interfaces.Repositories.SystemConfig.Login
{
    public interface IUserRepository
    {
        /// <summary>
        /// Verifica que el usuario sea correcto
        /// </summary>
        Task<IEnumerable<sp_getUsuarioAcceso>> GetUsuarioAcceso(string _usuario, string _clave);

        /// <summary>
        /// Obtiene el rol del usuario
        /// </summary>
        Task<IEnumerable<sp_getUsuario>> GetUsuarioRol(string _usuario);

        /// <summary>
        /// Obtiene la lista de usuarios
        /// </summary>
        Task<IEnumerable<sp_getListarUsuarios>> GetListarUsuarios();

        /// <summary>
        /// Agrega un usuario
        /// </summary>
        Task<string> SetInsertarUsuario(string _usuario, string _clave, string _email, int _idRol);

    }
}


