using almacen_samplag.Models;

namespace almacen_samplag.Services.Interfaces
{
    public interface ISedeService
    {
        public Task<List<Sede>> GetSedesAsync(int idCliente);
        public Task<Sede> InsertSedeAsync(Sede sede);
        public Task<bool> UpdateSedeAsync(Sede sedeUpdated);
        public Task<bool> DeleteSedeAsync(int id);
    }
}
