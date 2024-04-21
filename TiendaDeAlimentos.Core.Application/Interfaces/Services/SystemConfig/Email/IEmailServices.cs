using System;
using System.Collections.Generic;
using System.Text;

namespace TiendaDeAlimentos.Core.Application.Interfaces.Services.SystemConfig.Email
{
    public interface IEmailServices
    {
        bool EnviarEmailDePedidoConfirmado(string _usuario, string _emailDestino);
    }
}
