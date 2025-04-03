using almacen_samplag.Models;

namespace almacen_samplag.Services.Interfaces
{
    public interface ISedeService
    {
        public Task<IEnumerable<Sede>> GetSedesAsync();
        public Task<Sede> InsertSedeAsync(Sede sede);
        public Task<bool> UpdateSedeAsync(Sede sedeUpdated);
        public Task<bool> DeleteSedeAsync(int id);
    }
}
