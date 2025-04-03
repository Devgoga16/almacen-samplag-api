using almacen_samplag.Models;

namespace almacen_samplag.Services.Interfaces
{
    public interface IMovimientoService
    {
        public Task<bool> AddIngreso(List<Movimiento> movimientoList);
        public Task<bool> AddSalida(List<Movimiento> movimientoList);
        public Task<bool> AddRetorno(List<Movimiento> movimientoList);
    }
}
