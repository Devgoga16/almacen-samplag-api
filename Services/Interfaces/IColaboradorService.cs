using almacen_samplag.Models;

namespace almacen_samplag.Services.Interfaces
{
    public interface IColaboradorService
    {
        public Task<IEnumerable<Colaborador>> GetColaboradoresAsync();
        public Task<Colaborador> InsertColaboradorAsync(Colaborador colaborador);
        public Task<bool> UpdateColaboradorAsync(Colaborador colaboradorUpdated);
        public Task<bool> DeleteColaboradorAsync(int id);

    }
}
