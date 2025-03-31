using almacen_samplag.Models;

namespace almacen_samplag.Services.Interfaces
{
    public interface IClienteService
    {
        public Task<IEnumerable<Cliente>> GetClienteesAsync();
        public Task<Cliente> InsertClienteAsync(Cliente Cliente);
        public Task<bool> UpdateClienteAsync(Cliente ClienteUpdated);
        public Task<bool> DeleteClienteAsync(int id);
    }
}
