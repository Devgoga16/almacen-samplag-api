using almacen_samplag.Models;
using almacen_samplag.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace almacen_samplag.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CRUDController : ControllerBase
    {
        private readonly IProductoService _productoService;
        private readonly IColaboradorService _colaboradorService;
        public CRUDController(IProductoService productoService, IColaboradorService colaboradorService)
        {
            _productoService = productoService;
            _colaboradorService = colaboradorService;
        }
        [HttpGet]
        [Route("producto")]
        public async Task<ActionResult<IEnumerable<Producto>>> GetProductosAsync()
        {
            var productos = await _productoService.GetProductosAsync();
            return Ok(productos);
        }

        [HttpPost]
        [Route("producto")]
        public async Task<ActionResult<IEnumerable<Producto>>> InsertProductoAsync([FromBody] Producto producto)
        {
            var productos = await _productoService.InsertProductoAsync(producto);
            return Ok(productos);
        }

        [HttpPut]
        [Route("producto")]
        public async Task<ActionResult<bool>> UpdateProductoAsync([FromBody] Producto producto)
        {
            var productos = await _productoService.UpdateProductoAsync(producto);
            return Ok(productos);
        }

        [HttpDelete]
        [Route("producto/{id}")]

        public async Task<IActionResult> DeleteProductoAsync(int id)
        {
            var deleted = await _productoService.DeleteProductoAsync(id);
            return Ok(deleted);
        }
        [HttpGet]
        [Route("colaborador")]
        public async Task<ActionResult<IEnumerable<Colaborador>>> GetColaboradoresAsync()
        {
            var response = await _colaboradorService.GetColaboradoresAsync();
            return Ok(response);
        }

        [HttpPost]
        [Route("colaborador")]
        public async Task<ActionResult<IEnumerable<Colaborador>>> InsertColaboradorAsync([FromBody] Colaborador colaborador)
        {
            var response = await _colaboradorService.InsertColaboradorAsync(colaborador);
            return Ok(response);
        }

        [HttpPut]
        [Route("colaborador")]
        public async Task<ActionResult<bool>> UpdateColaboradorAsync([FromBody] Colaborador colaborador)
        {
            var response = await _colaboradorService.UpdateColaboradorAsync(colaborador);
            return Ok(response);
        }

        [HttpDelete]
        [Route("colaborador/{id}")]
        public async Task<IActionResult> DeleteColaboradorAsync(int id)
        {
            var response = await _colaboradorService.DeleteColaboradorAsync(id);
            return Ok(response);
        }
    }
}
