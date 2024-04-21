using AutoMapper;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TiendaDeAlimentos.Core.Application.DTOs.Modules.Inventory;
using TiendaDeAlimentos.Core.Application.Interfaces.Repositories.Modules.Inventory;
using TiendaDeAlimentos.Core.Application.Interfaces.Services.Modules.Inventory;
using TiendaDeAlimentos.Core.Application.Interfaces.Services.SystemConfig.ApiResult;
using TiendaDeAlimentos.Core.Application.Services.SystemConfig.ApiResult;
using TiendaDeAlimentos.Core.Application.Interfaces.Services.SystemConfig.Email;

namespace TiendaDeAlimentos.Core.Application.Services.Modules.Inventory
{
    public class GestionPedidosServices : IGestionPedidosServices
    {
        private readonly IGestionPedidosRepository repository;
        private readonly IEmailServices serviceEmail;
        private readonly IMapper mapper;

        public GestionPedidosServices(IGestionPedidosRepository _repository, IMapper _mapper , IEmailServices _serviceEmail)
        {
            repository = _repository;
            mapper = _mapper;
            serviceEmail = _serviceEmail;

        }

        public async Task<IResult<IEnumerable<ListarProductosDisponiblesDTO>>> GetListarProductosDisponibles()
        {
            try
            {
                var result = await repository.GetListarProductosDisponibles();

                if (result == null)
                    return Result<IEnumerable<ListarProductosDisponiblesDTO>>.Fail("Se ha producido un error al recuperar la información", new List<ListarProductosDisponiblesDTO>());

                var rolesDTO = mapper.Map<IEnumerable<ListarProductosDisponiblesDTO>>(result);

                return Result<IEnumerable<ListarProductosDisponiblesDTO>>.Success(rolesDTO);


            }
            catch (Exception e)
            {

                return Result<IEnumerable<ListarProductosDisponiblesDTO>>.Fail("Se ha producido un error al convertir la información", new List<ListarProductosDisponiblesDTO>());

            }
        }

        public async Task<IResult<string>> SetAgregarProductoAPedido(InsertarProductoAPedidoDTO _insertarProductoAPedidoDTO, int _usuario)
        {
            if (!(_insertarProductoAPedidoDTO.cantidad>0))
                return Result<string>.Fail("La cantidad del pedido debe ser mayor a 0");


            try
            {
                var result = await repository.SetProcesarProductoAPedido(_insertarProductoAPedidoDTO.idProducto, _insertarProductoAPedidoDTO.cantidad, _usuario);

                if (result == null)
                    return Result<string>.Fail("Se ha producido un error al recuperar la información");

                if (!result.Equals("OK"))
                    return Result<string>.Fail(result);
                

                return Result<string>.Success("Producto Procesado");

            }
            catch (Exception e)
            {

                return Result<string>.Fail("Se ha producido un error en el proceso");
            }
        }


        public async Task<IResult<string>> SetEliminarProductoAPedido(InsertarProductoAPedidoDTO _insertarProductoAPedidoDTO, int _usuario)
        {          

            try
            {
                var result = await repository.SetProcesarProductoAPedido(_insertarProductoAPedidoDTO.idProducto, _insertarProductoAPedidoDTO.cantidad, _usuario);

                if (result == null)
                    return Result<string>.Fail("Se ha producido un error al recuperar la información");

                if (!result.Equals("OK"))
                    return Result<string>.Fail(result);


                return Result<string>.Success("Producto Procesado");

            }
            catch (Exception e)
            {

                return Result<string>.Fail("Se ha producido un error en el proceso");
            }
        }

        public async Task<IResult<string>> SetConfirmacionDePedido(int _idUsuario , string _usuario, string _emailDestino)
        {
            try
            {
                var result = await repository.SetConfirmarPedido(_idUsuario);

                if (result == null)
                    return Result<string>.Fail("Se ha producido un error al confirmar el envio");

                if (!result.Equals("OK"))
                    return Result<string>.Fail(result);
                

                //Proceso de enviar email
                bool emailEnviado= serviceEmail.EnviarEmailDePedidoConfirmado(_usuario, _emailDestino);
                //Fin proceso de enviar email

                if(!emailEnviado)
                    return Result<string>.Fail("El pedido ha sido confirmado pero no se ha podido enviar el email de confirmación ni la confirmación de envio");

                var result2 = await repository.SetConfirmarEnvioPedido(_idUsuario);
                
                if (result2 == null)
                    return Result<string>.Fail("El pedido ha sido confirmado, pero no se ha confirmado el envio");

                if (!result2.Equals("OK"))
                    return Result<string>.Fail(result2);
                               


                return Result<string>.Success("Pedido y Envio Confirmado");

            }
            catch (Exception e)
            {

                return Result<string>.Fail("Se ha producido un error en el proceso");
            }
        }


        public async Task<IResult<IEnumerable<ListarProdXPedidoDTO>>> GetListarProdXPedido(int _idUsuario)
        {
            try
            {
                var result = await repository.GetListarProdXPedido(_idUsuario);

                if (result == null)
                    return Result<IEnumerable<ListarProdXPedidoDTO>>.Fail("Se ha producido un error al recuperar la información", new List<ListarProdXPedidoDTO>());

                var rolesDTO = mapper.Map<IEnumerable<ListarProdXPedidoDTO>>(result);

                return Result<IEnumerable<ListarProdXPedidoDTO>>.Success(rolesDTO);


            }
            catch (Exception e)
            {

                return Result<IEnumerable<ListarProdXPedidoDTO>>.Fail("Se ha producido un error al convertir la información", new List<ListarProdXPedidoDTO>());

            }
        }

       

    }
}
