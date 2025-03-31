using almacen_samplag.Models;

namespace almacen_samplag.Services.Interfaces
{
    public interface IPresentacionService
    {
        public Task<IEnumerable<Presentacion>> GetPresentacionesAsync();
        public Task<Presentacion> InsertPresentacionAsync(Presentacion Presentacion);
        public Task<bool> UpdatePresentacionAsync(Presentacion PresentacionUpdated);
        public Task<bool> DeletePresentacionAsync(int id);
    }
}
