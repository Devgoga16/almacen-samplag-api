using almacen_samplag.Models;
using almacen_samplag.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace almacen_samplag.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColaboradorController : ControllerBase
    {
        private readonly IColaboradorService _colaboradorService;
        public ColaboradorController(IColaboradorService colaboradorService)
        {
            _colaboradorService = colaboradorService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Colaborador>>> GetColaboradoresAsync()
        {
            var response = await _colaboradorService.GetColaboradoresAsync();
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<Colaborador>>> InsertColaboradorAsync([FromBody] Colaborador colaborador)
        {
            var response = await _colaboradorService.InsertColaboradorAsync(colaborador);
            return Ok(response);
        }

        [HttpPut]
        public async Task<ActionResult<bool>> UpdateColaboradorAsync([FromBody] Colaborador colaborador)
        {
            var response = await _colaboradorService.UpdateColaboradorAsync(colaborador);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteColaboradorAsync(int id)
        {
            var response = await _colaboradorService.DeleteColaboradorAsync(id);
            return Ok(response);
        }
    }
}
