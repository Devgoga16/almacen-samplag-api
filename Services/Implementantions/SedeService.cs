using almacen_samplag.Models;
using almacen_samplag.Services.Interfaces;
using ApiCore.Data;
using Microsoft.EntityFrameworkCore;

namespace almacen_samplag.Services.Implementantions
{
    public class SedeService : ISedeService
    {
        private readonly AppDbContext _context;
        public SedeService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<Sede>> GetSedesAsync(int idCliente)
        {
            try
            {
                return await _context.Sede.Where(x => x.idCliente == idCliente).ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<Sede> InsertSedeAsync(Sede sede)
        {
            try
            {
                _context.Sede.Add(sede);
                await _context.SaveChangesAsync();
                return sede;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<bool> UpdateSedeAsync(Sede sedeUpdated)
        {
            try
            {
                var sede = await _context.Sede.FindAsync(sedeUpdated.idSede);
                if (sede == null)
                {
                    throw new Exception("No hay una Sede con el ID enviado");
                }

                sede.idCliente = sedeUpdated.idCliente;
                sede.nombreSede = sedeUpdated.nombreSede;
                sede.rucSede = sedeUpdated.rucSede;
                sede.direccionSede = sedeUpdated.direccionSede;
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<bool> DeleteSedeAsync(int id)
        {
            try
            {
                var Sede = await _context.Sede.FindAsync(id);
                if (Sede == null)
                {
                    throw new Exception("ID no existe");
                }

                _context.Sede.Remove(Sede);
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
