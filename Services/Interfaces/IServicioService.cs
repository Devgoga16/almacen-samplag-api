using almacen_samplag.Models.Request;
using almacen_samplag.Models.Response;

namespace almacen_samplag.Services.Interfaces
{
    public interface IServicioService
    {
        public Task<ServicioResponse> InsertServicioAsync(ServicioRequest request);
        public Task<List<ServicioResponseList>> GetServicioList();
    }
}
