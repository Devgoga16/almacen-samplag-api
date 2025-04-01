using almacen_samplag.Models;
using almacen_samplag.Services.Interfaces;
using ApiCore.Data;
using Microsoft.EntityFrameworkCore;

namespace almacen_samplag.Services.Implementantions
{
    public class ClienteService : IClienteService
    {
        private readonly AppDbContext _context;
        public ClienteService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Cliente>> GetClienteesAsync()
        {
            try
            {
                return await _context.Cliente.ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<Cliente> InsertClienteAsync(Cliente cliente)
        {
            try
            {
                _context.Cliente.Add(cliente);
                await _context.SaveChangesAsync();
                return cliente;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<bool> UpdateClienteAsync(Cliente ClienteUpdated)
        {
            try
            {
                var Cliente = await _context.Cliente.FindAsync(ClienteUpdated.idCliente);
                if (Cliente == null)
                {
                    throw new Exception("No hay un Cliente con el ID enviado");
                }

                Cliente.nombreCliente = ClienteUpdated.nombreCliente;
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<bool> DeleteClienteAsync(int id)
        {
            try
            {
                var Cliente = await _context.Cliente.FindAsync(id);
                if (Cliente == null)
                {
                    throw new Exception("ID no existe");
                }

                _context.Cliente.Remove(Cliente);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
