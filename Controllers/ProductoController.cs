using almacen_samplag.Models;
using almacen_samplag.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace almacen_samplag.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly IProductoService _productoService;
        public ProductoController(IProductoService productoService)
        {
            _productoService = productoService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Producto>>> GetProductosAsync()
        {
            var productos = await _productoService.GetProductosAsync();
            return Ok(productos);
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<Producto>>> InsertProductoAsync([FromBody] Producto producto)
        {
            var productos = await _productoService.InsertProductoAsync(producto);
            return Ok(productos);
        }

        [HttpPut]
        public async Task<ActionResult<bool>> UpdateProductoAsync([FromBody] Producto producto)
        {
            var productos = await _productoService.UpdateProductoAsync(producto);
            return Ok(productos);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductoAsync(int id)
        {
            var deleted = await _productoService.DeleteProductoAsync(id);
            return Ok(deleted);
        }
    }
}
