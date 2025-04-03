using almacen_samplag.Models;
using almacen_samplag.Models.Request;
using almacen_samplag.Models.Response;
using almacen_samplag.Services.Implementantions;
using almacen_samplag.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace almacen_samplag.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovimientoController : ControllerBase
    {
        private ResponseDTO? _responseDTO;
        private readonly IMovimientoService _movimientoService;

        public MovimientoController(IMovimientoService movimientoService)
        {
            _movimientoService = movimientoService;
        }

        [HttpPost]
        [Route("ingreso")]
        public async Task<ActionResult<bool>> AddIngreso([FromBody] List<Movimiento> movimientoList)
        {
            _responseDTO = new ResponseDTO();

            try
            {
                var resultService = await _movimientoService.AddIngreso(movimientoList);
                var response = _responseDTO.Success(_responseDTO, resultService);
                return Ok(response);
            }
            catch (Exception ex)
            {
                var response = _responseDTO.Failed(_responseDTO, ex);
                return BadRequest(response);
            }
        }

        [HttpPost]
        [Route("salida")]
        public async Task<ActionResult<bool>> AddSalida([FromBody] List<Movimiento> movimientoList)
        {
            _responseDTO = new ResponseDTO();

            try
            {
                var resultService = await _movimientoService.AddSalida(movimientoList);
                var response = _responseDTO.Success(_responseDTO, resultService);
                return Ok(response);
            }
            catch (Exception ex)
            {
                var response = _responseDTO.Failed(_responseDTO, ex);
                return BadRequest(response);
            }
        }

        [HttpPost]
        [Route("retorno")]
        public async Task<ActionResult<bool>> AddRetorno([FromBody] List<Movimiento> movimientoList)
        {
            _responseDTO = new ResponseDTO();

            try
            {
                var resultService = await _movimientoService.AddRetorno(movimientoList);
                var response = _responseDTO.Success(_responseDTO, resultService);
                return Ok(response);
            }
            catch (Exception ex)
            {
                var response = _responseDTO.Failed(_responseDTO, ex);
                return BadRequest(response);
            }
        }
    }
}
