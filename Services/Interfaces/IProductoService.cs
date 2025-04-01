using almacen_samplag.Models;
using almacen_samplag.Models.Response;

namespace almacen_samplag.Services.Interfaces
{
    public interface IProductoService
    {
        public Task<IEnumerable<ProductoResponse>> GetProductosAsync();
        public Task<Producto> InsertProductoAsync(Producto producto);
        public Task<bool> UpdateProductoAsync(Producto productoUpdated);
        public Task<bool> DeleteProductoAsync(int id);
    }
}
