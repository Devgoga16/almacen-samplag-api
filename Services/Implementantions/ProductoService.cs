using almacen_samplag.Models;
using almacen_samplag.Services.Interfaces;
using ApiCore.Data;
using Microsoft.EntityFrameworkCore;

namespace almacen_samplag.Services.Implementantions
{
    public class ProductoService : IProductoService
    {
        private readonly AppDbContext _context;
        public ProductoService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Producto>> GetProductosAsync()
        {
            try
            {
                return await _context.Producto.ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<Producto> InsertProductoAsync(Producto producto)
        {
            try
            {
                _context.Producto.Add(producto);
                await _context.SaveChangesAsync();
                return producto;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<bool> UpdateProductoAsync(Producto productoUpdated)
        {
            try
            {
                var producto = await _context.Producto.FindAsync(productoUpdated.idProducto);
                if (producto == null)
                {
                    return false;
                }

                producto.nombreProducto = productoUpdated.nombreProducto;
                producto.idPresentacion = productoUpdated.idPresentacion;
                producto.retornable = productoUpdated.retornable;

                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<bool> DeleteProductoAsync(int id)
        {
            try
            {
                var producto = await _context.Producto.FindAsync(id);
                if (producto == null)
                {
                    return false;
                }

                _context.Producto.Remove(producto);
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
