using almacen_samplag.Models;
using almacen_samplag.Models.Request;
using almacen_samplag.Models.Response;
using almacen_samplag.Services.Interfaces;
using ApiCore.Data;

namespace almacen_samplag.Services.Implementantions
{
    public class ServicioService : IServicioService
    {
        private readonly AppDbContext _context;

        public ServicioService(AppDbContext context)
        {
            _context = context;
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

                foreach(var item in request.idColaboradores)
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
                response.descripcionServicio = request.descripcionServicio;

                return response;
            }
            catch (Exception) 
            {
                throw;
            }
        }
    }
}
