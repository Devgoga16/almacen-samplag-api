using almacen_samplag.Models;
using almacen_samplag.Services.Interfaces;
using ApiCore.Data;

namespace almacen_samplag.Services.Implementantions
{
    public class MovimientoService : IMovimientoService
    {
        private readonly AppDbContext _context;
        public MovimientoService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<bool> AddIngreso(List<Movimiento> movimientoList)
        {
            try
            {
                foreach(var item in movimientoList)
                {
                    item.tipoMovimiento = 1;
                    item.idServicio = 0;
                    _context.Add(item);
                }
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> AddSalida(List<Movimiento> movimientoList)
        {
            try
            {
                foreach (var item in movimientoList)
                {
                    item.tipoMovimiento = 2;
                    _context.Add(item);
                }
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<bool> AddRetorno(List<Movimiento> movimientoList)
        {
            try
            {
                foreach (var item in movimientoList)
                {
                    item.tipoMovimiento = 3;
                    _context.Add(item);
                }
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
