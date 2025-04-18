﻿using almacen_samplag.Models.Request;
using almacen_samplag.Models.Response;

namespace almacen_samplag.Services.Interfaces
{
    public interface IServicioService
    {
        public Task<ServicioResponse> InsertServicioAsync(ServicioRequest request);
        public Task<List<ServicioResponseList>> GetServicioList();
        public Task<bool> UpdateServicioAsync(ServicioRequest request);
        public Task<bool> DeleteService(int idService);
    }
}
