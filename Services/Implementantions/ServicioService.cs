using System.ComponentModel;
using almacen_samplag.Models;
using almacen_samplag.Models.Request;
using almacen_samplag.Models.Response;
using almacen_samplag.Services.Interfaces;
using ApiCore.Data;
using Microsoft.EntityFrameworkCore;

namespace almacen_samplag.Services.Implementantions
{
    public class ServicioService : IServicioService
    {
        private readonly AppDbContext _context;

        public ServicioService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<ServicioResponseList>> GetServicioList()
        {
            try
            {
                List<ServicioResponseList> response = new List<ServicioResponseList>();

                response = await _context.Database.SqlQueryRaw<ServicioResponseList>("EXEC spGetServicios").ToListAsync() ?? new List<ServicioResponseList>();

                foreach (var item in response) 
                {
                    item.colaboradores = await _context.Database.SqlQueryRaw<Colaborador>("EXEC spGetColaboradoresByServicio @p0", item.idServicio).ToListAsync() ?? new List<Colaborador>();
                    item.productos = await _context.Database.SqlQueryRaw<ProductoMovimientoDto>("EXEC spGetProductosByServicio @p0", item.idServicio).ToListAsync() ?? new List<ProductoMovimientoDto>();
                }

                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<ServicioResponse> InsertServicioAsync(ServicioRequest request)
        {
            try
            {
                ServicioResponse response = new ServicioResponse();

                Servicio servicio = new Servicio();

                servicio.idCliente = request.idCliente;
                servicio.descripcionServicio = request.descripcionServicio;
                servicio.fecha = request.fecha;

                _context.Servicio.Add(servicio);

                await _context.SaveChangesAsync();

                var idServicio = servicio.idServicio;

                foreach (var item in request.idColaboradores ?? new List<int>())
                {
                    ServicioColaborador servicioColaborador = new ServicioColaborador();
                    servicioColaborador.idColaborador = item;
                    servicioColaborador.idServicio = idServicio;

                    _context.ServicioColaborador.Add(servicioColaborador);
                }

                await _context.SaveChangesAsync();

                response.idServicio = idServicio;
                response.idCliente = request.idCliente;
                response.fecha = request.fecha;
                response.descripcionServicio = request.descripcionServicio ?? "";

                return response;
            }
            catch (Exception) 
            {
                throw;
            }
        }

        public async Task<bool> UpdateServicioAsync(ServicioRequest request)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                var colaboradoresByServicio = _context.ServicioColaborador.Where(x => x.idServicio == request.idServicio).ToList();

                foreach (var item in colaboradoresByServicio)
                {
                    _context.Remove(item);
                }
                await _context.SaveChangesAsync();

                foreach (var item in request.idColaboradores ?? new List<int>())
                {
                    ServicioColaborador servicioColaborador = new ServicioColaborador();
                    servicioColaborador.idColaborador = item;
                    servicioColaborador.idServicio = request.idServicio;

                    _context.ServicioColaborador.Add(servicioColaborador);
                }

                await _context.SaveChangesAsync();

                Servicio servicioForUpdate = new Servicio();

                servicioForUpdate.idServicio = request.idServicio;
                servicioForUpdate.idCliente = request.idCliente;
                servicioForUpdate.descripcionServicio = request.descripcionServicio;
                servicioForUpdate.fecha = request.fecha;

                _context.Update(servicioForUpdate);
                await _context.SaveChangesAsync();

                await transaction.CommitAsync();

                return true;
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task<bool> DeleteService(int idService)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                var productosByServicio = _context.Movimiento.Where(x => x.idServicio == idService).ToList();
                if (productosByServicio.Count > 0) {
                    throw new Exception("Este servicio no se puede eliminar porque cuenta con productos asociados");
                }
                else
                {
                    var colaboradoresByServicio = _context.ServicioColaborador.Where(x => x.idServicio == idService).ToList();

                    foreach(var item in colaboradoresByServicio)
                    {
                        _context.Remove(item);
                    }
                    await _context.SaveChangesAsync();

                    var service = _context.Servicio.FirstOrDefault(x => x.idServicio == idService);

                    if (service != null)
                    {
                        _context.Remove(service);
                    }
                    await _context.SaveChangesAsync();

                    await transaction.CommitAsync();
                }
                return true;
            }
            catch(Exception)
            {
                await transaction.RollbackAsync();
                throw;
            }
        }
    }
}
