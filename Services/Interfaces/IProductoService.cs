using almacen_samplag.Models;

namespace almacen_samplag.Services.Interfaces
{
    public interface IProductoService
    {
        public Task<IEnumerable<Producto>> GetProductosAsync();
        public Task<Producto> InsertProductoAsync(Producto producto);
        public Task<bool> UpdateProductoAsync(Producto productoUpdated);
        public Task<bool> DeleteProductoAsync(int id);
    }
}
