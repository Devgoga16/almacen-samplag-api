using almacen_samplag.Models;
using almacen_samplag.Services.Interfaces;
using ApiCore.Data;
using Microsoft.EntityFrameworkCore;

namespace almacen_samplag.Services.Implementantions
{
    public class ColaboradorService : IColaboradorService
    {
        private readonly AppDbContext _context;
        public ColaboradorService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Colaborador>> GetColaboradoresAsync()
        {
            try
            {
                return await _context.Colaborador.ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<Colaborador> InsertColaboradorAsync(Colaborador colaborador)
        {
            try
            {
                _context.Colaborador.Add(colaborador);
                colaborador.idColaborador = await _context.SaveChangesAsync();
                return colaborador;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<bool> UpdateColaboradorAsync(Colaborador colaboradorUpdated)
        {
            try
            {
                var colaborador = await _context.Colaborador.FindAsync(colaboradorUpdated.idColaborador);
                if (colaborador == null)
                {
                    throw new Exception("No hay un colaborador con el ID enviado");
                }

                colaborador.nombreColaborador = colaboradorUpdated.nombreColaborador;
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<bool> DeleteColaboradorAsync(int id)
        {
            try
            {
                var colaborador = await _context.Colaborador.FindAsync(id);
                if (colaborador == null)
                {
                    throw new Exception("ID no existe");
                }

                _context.Colaborador.Remove(colaborador);
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
