using almacen_samplag.Models;
using almacen_samplag.Services.Interfaces;
using ApiCore.Data;
using Microsoft.EntityFrameworkCore;

namespace almacen_samplag.Services.Implementantions
{
    public class PresentacionService : IPresentacionService
    {
        private readonly AppDbContext _context;
        public PresentacionService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Presentacion>> GetPresentacionesAsync()
        {
            try
            {
                return await _context.Presentacion.ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<Presentacion> InsertPresentacionAsync(Presentacion presentacion)
        {
            try
            {
                _context.Presentacion.Add(presentacion);
                presentacion.idPresentacion = await _context.SaveChangesAsync();
                return presentacion;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<bool> UpdatePresentacionAsync(Presentacion PresentacionUpdated)
        {
            try
            {
                var Presentacion = await _context.Presentacion.FindAsync(PresentacionUpdated.idPresentacion);
                if (Presentacion == null)
                {
                    throw new Exception("No hay un Presentacion con el ID enviado");
                }

                Presentacion.nombrePresentacion = PresentacionUpdated.nombrePresentacion;
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<bool> DeletePresentacionAsync(int id)
        {
            try
            {
                var Presentacion = await _context.Presentacion.FindAsync(id);
                if (Presentacion == null)
                {
                    throw new Exception("ID no existe");
                }

                _context.Presentacion.Remove(Presentacion);
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
