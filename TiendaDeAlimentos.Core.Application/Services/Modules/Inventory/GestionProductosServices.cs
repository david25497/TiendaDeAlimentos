using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TiendaDeAlimentos.Core.Application.DTOs.Modules.Inventory;
using TiendaDeAlimentos.Core.Application.Interfaces.Repositories.Modules.Inventory;
using TiendaDeAlimentos.Core.Application.Interfaces.Services.Modules.Inventory;
using TiendaDeAlimentos.Core.Application.Interfaces.Services.SystemConfig.ApiResult;
using TiendaDeAlimentos.Core.Application.Services.SystemConfig.ApiResult;

namespace TiendaDeAlimentos.Core.Application.Services.Modules.Inventory
{
    public class GestionProductosServices : IGestionProductosServices
    {
        private readonly IGestionProductosRepository repository;
        private readonly IMapper mapper;

        public GestionProductosServices(IGestionProductosRepository _repository, IMapper _mapper)
        {
            repository = _repository;
            mapper = _mapper;

        }

        public async Task<IResult<IEnumerable<ListarProductosDisponiblesDetaDTO>>> GetListarProductosDisponiblesDeta(bool _mostrarTodo)
        {
            try
            {
                var result = await repository.GetListarProductosDisponiblesDeta( _mostrarTodo);

                if (result == null)
                    return Result<IEnumerable<ListarProductosDisponiblesDetaDTO>>.Fail("Se ha producido un error al recuperar la información", new List<ListarProductosDisponiblesDetaDTO>());

                var rolesDTO = mapper.Map<IEnumerable<ListarProductosDisponiblesDetaDTO>>(result);

                return Result<IEnumerable<ListarProductosDisponiblesDetaDTO>>.Success(rolesDTO);

            }
            catch (Exception e)
            {

                return Result<IEnumerable<ListarProductosDisponiblesDetaDTO>>.Fail("Se ha producido un error al convertir la información", new List<ListarProductosDisponiblesDetaDTO>());
            }
        }
              
        public async Task<IResult<string>> SetActualizarProducto(ActualizarProductoDTO _actualizarProductoDTO)
        {
            try
            {
                var result = await repository.SetActualizarProducto(_actualizarProductoDTO.id, _actualizarProductoDTO.nombre, _actualizarProductoDTO.descripcion, _actualizarProductoDTO.precio, _actualizarProductoDTO.cantidad);

                if (result == null)
                    return Result<string>.Fail("Se ha producido un error al recuperar la información");

                if (!result.Equals("OK"))
                {
                    return Result<string>.Fail(result);
                }

                return Result<string>.Success("Producto Actualizado");

            }
            catch (Exception e)
            {

                return Result<string>.Fail("Se ha producido un error en el proceso");
            }
        }

        public async Task<IResult<string>> SetInsertarProducto(InsertarProductoDTO _insertarProductoDTO)
        {
            try
            {
                var result = await repository.SetInsertarProducto(_insertarProductoDTO.nombre, _insertarProductoDTO.descripcion, _insertarProductoDTO.precio, _insertarProductoDTO.cantidad);

                if (result == null)
                    return Result<string>.Fail("Se ha producido un error al recuperar la información");

                if (!result.Equals("OK"))
                {
                    return Result<string>.Fail(result);
                }

                return Result<string>.Success("Producto Agregado");

            }
            catch (Exception e)
            {

                return Result<string>.Fail("Se ha producido un error en el proceso");
            }
        }

        public async Task<IResult<string>> SetEliminarProducto(int _id)
        {
            try
            {
                var result = await repository.SetEliminarProducto(_id);

                if (result == null)
                    return Result<string>.Fail("Se ha producido un error al recuperar la información");

                if (!result.Equals("OK"))
                {
                    return Result<string>.Fail(result);
                }

                return Result<string>.Success("Producto Eliminado");

            }
            catch (Exception e)
            {

                return Result<string>.Fail("Se ha producido un error en el proceso");
            }
        }



     



    }
}
