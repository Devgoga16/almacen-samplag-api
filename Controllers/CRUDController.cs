using almacen_samplag.Models;
using almacen_samplag.Models.Response;
using almacen_samplag.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace almacen_samplag.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CRUDController : ControllerBase
    {
        private ResponseDTO? _responseDTO;
        private readonly IProductoService _productoService;
        private readonly IColaboradorService _colaboradorService;
        private readonly IClienteService _clienteService;
        private readonly IPresentacionService _presentacionService;
        private readonly ISedeService _sedeService;

        public CRUDController(
                IProductoService productoService, 
                IColaboradorService colaboradorService,
                IClienteService clienteService,
                IPresentacionService presentacionService,
                ISedeService sedeService)
        {
            _productoService = productoService;
            _colaboradorService = colaboradorService;
            _clienteService = clienteService;
            _presentacionService = presentacionService;
            _sedeService = sedeService;
        }
        [HttpGet]
        [Route("producto")]
        public async Task<ActionResult<IEnumerable<Producto>>> GetProductosAsync()
        {
            _responseDTO = new ResponseDTO();

            try
            {
                var resultService = await _productoService.GetProductosAsync();
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
        [Route("producto")]
        public async Task<ActionResult<IEnumerable<Producto>>> InsertProductoAsync([FromBody] Producto producto)
        {
            _responseDTO = new ResponseDTO();

            try
            {
                var resultService = await _productoService.InsertProductoAsync(producto);
                var response = _responseDTO.Success(_responseDTO, resultService);
                return Ok(response);
            }
            catch (Exception ex)
            {
                var response = _responseDTO.Failed(_responseDTO, ex);
                return BadRequest(response);
            }
        }

        [HttpPut]
        [Route("producto")]
        public async Task<ActionResult<bool>> UpdateProductoAsync([FromBody] Producto producto)
        {
            _responseDTO = new ResponseDTO();

            try
            {
                var resultService = await _productoService.UpdateProductoAsync(producto);
                var response = _responseDTO.Success(_responseDTO, resultService);
                return Ok(response);
            }
            catch (Exception ex)
            {
                var response = _responseDTO.Failed(_responseDTO, ex);
                return BadRequest(response);
            }
        }

        [HttpDelete]
        [Route("producto/{id}")]

        public async Task<IActionResult> DeleteProductoAsync(int id)
        {
            _responseDTO = new ResponseDTO();

            try
            {
                var resultService = await _productoService.DeleteProductoAsync(id);
                var response = _responseDTO.Success(_responseDTO, resultService);
                return Ok(response);
            }
            catch (Exception ex)
            {
                var response = _responseDTO.Failed(_responseDTO, ex);
                return BadRequest(response);
            }
        }
        [HttpGet]
        [Route("colaborador")]
        public async Task<ActionResult<IEnumerable<Colaborador>>> GetColaboradoresAsync()
        {
            _responseDTO = new ResponseDTO();

            try
            {
                var resultService = await _colaboradorService.GetColaboradoresAsync();
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
        [Route("colaborador")]
        public async Task<ActionResult<IEnumerable<Colaborador>>> InsertColaboradorAsync([FromBody] Colaborador colaborador)
        {
            _responseDTO = new ResponseDTO();

            try
            {
                var resultService = await _colaboradorService.InsertColaboradorAsync(colaborador);
                var response = _responseDTO.Success(_responseDTO, resultService);
                return Ok(response);
            }
            catch (Exception ex)
            {
                var response = _responseDTO.Failed(_responseDTO, ex);
                return BadRequest(response);
            }
        }

        [HttpPut]
        [Route("colaborador")]
        public async Task<ActionResult<bool>> UpdateColaboradorAsync([FromBody] Colaborador colaborador)
        {
            _responseDTO = new ResponseDTO();

            try
            {
                var resultService = await _colaboradorService.UpdateColaboradorAsync(colaborador);
                var response = _responseDTO.Success(_responseDTO, resultService);
                return Ok(response);
            }
            catch (Exception ex)
            {
                var response = _responseDTO.Failed(_responseDTO, ex);
                return BadRequest(response);
            }
        }

        [HttpDelete]
        [Route("colaborador/{id}")]
        public async Task<IActionResult> DeleteColaboradorAsync(int id)
        {
            _responseDTO = new ResponseDTO();

            try
            {
                var resultService = await _colaboradorService.DeleteColaboradorAsync(id);
                var response = _responseDTO.Success(_responseDTO, resultService);
                return Ok(response);
            }
            catch (Exception ex)
            {
                var response = _responseDTO.Failed(_responseDTO, ex);
                return BadRequest(response);
            }
        }
        [HttpGet]
        [Route("cliente")]
        public async Task<ActionResult<IEnumerable<Colaborador>>> GetClienteesAsync()
        {
            _responseDTO = new ResponseDTO();

            try
            {
                var resultService = await _clienteService.GetClienteesAsync();
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
        [Route("cliente")]
        public async Task<ActionResult<IEnumerable<Cliente>>> InsertClienteAsync([FromBody] Cliente cliente)
        {
            _responseDTO = new ResponseDTO();

            try
            {
                var resultService = await _clienteService.InsertClienteAsync(cliente);
                var response = _responseDTO.Success(_responseDTO, resultService);
                return Ok(response);
            }
            catch (Exception ex)
            {
                var response = _responseDTO.Failed(_responseDTO, ex);
                return BadRequest(response);
            }
        }

        [HttpPut]
        [Route("cliente")]
        public async Task<ActionResult<bool>> UpdateClienteAsync([FromBody] Cliente cliente)
        {
            _responseDTO = new ResponseDTO();

            try
            {
                var resultService = await _clienteService.UpdateClienteAsync(cliente);
                var response = _responseDTO.Success(_responseDTO, resultService);
                return Ok(response);
            }
            catch (Exception ex)
            {
                var response = _responseDTO.Failed(_responseDTO, ex);
                return BadRequest(response);
            }
        }

        [HttpDelete]
        [Route("cliente/{id}")]
        public async Task<IActionResult> DeleteClienteAsync(int id)
        {
            _responseDTO = new ResponseDTO();

            try
            {
                var resultService = await _clienteService.DeleteClienteAsync(id);
                var response = _responseDTO.Success(_responseDTO, resultService);
                return Ok(response);
            }
            catch (Exception ex)
            {
                var response = _responseDTO.Failed(_responseDTO, ex);
                return BadRequest(response);
            }
        }
        [HttpGet]
        [Route("presentacion")]
        public async Task<ActionResult<IEnumerable<Colaborador>>> GetPresentacionesAsync()
        {
            _responseDTO = new ResponseDTO();

            try
            {
                var resultService = await _presentacionService.GetPresentacionesAsync();
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
        [Route("presentacion")]
        public async Task<ActionResult<IEnumerable<Colaborador>>> InsertPresentacionAsync([FromBody] Presentacion presentacion)
        {
            _responseDTO = new ResponseDTO();

            try
            {
                var resultService = await _presentacionService.InsertPresentacionAsync(presentacion);
                var response = _responseDTO.Success(_responseDTO, resultService);
                return Ok(response);
            }
            catch (Exception ex)
            {
                var response = _responseDTO.Failed(_responseDTO, ex);
                return BadRequest(response);
            }
        }

        [HttpPut]
        [Route("presentacion")]
        public async Task<ActionResult<bool>> UpdatePresentacionAsync([FromBody] Presentacion presentacion)
        {
            _responseDTO = new ResponseDTO();

            try
            {
                var resultService = await _presentacionService.UpdatePresentacionAsync(presentacion);
                var response = _responseDTO.Success(_responseDTO, resultService);
                return Ok(response);
            }
            catch (Exception ex)
            {
                var response = _responseDTO.Failed(_responseDTO, ex);
                return BadRequest(response);
            }
        }

        [HttpDelete]
        [Route("presentacion/{id}")]
        public async Task<IActionResult> DeletePresentacionAsync(int id)
        {
            _responseDTO = new ResponseDTO();

            try
            {
                var resultService = await _presentacionService.DeletePresentacionAsync(id);
                var response = _responseDTO.Success(_responseDTO, resultService);
                return Ok(response);
            }
            catch (Exception ex)
            {
                var response = _responseDTO.Failed(_responseDTO, ex);
                return BadRequest(response);
            }
        }

        [HttpGet]
        [Route("sede")]
        public async Task<ActionResult<IEnumerable<Sede>>> GetSedesAsync()
        {
            _responseDTO = new ResponseDTO();

            try
            {
                var resultService = await _sedeService.GetSedesAsync();
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
        [Route("sede")]
        public async Task<ActionResult<IEnumerable<Sede>>> InsertSedeAsync([FromBody] Sede sede)
        {
            _responseDTO = new ResponseDTO();

            try
            {
                var resultService = await _sedeService.InsertSedeAsync(sede);
                var response = _responseDTO.Success(_responseDTO, resultService);
                return Ok(response);
            }
            catch (Exception ex)
            {
                var response = _responseDTO.Failed(_responseDTO, ex);
                return BadRequest(response);
            }
        }

        [HttpPut]
        [Route("sede")]
        public async Task<ActionResult<bool>> UpdateSedeAsync([FromBody] Sede sede)
        {
            _responseDTO = new ResponseDTO();

            try
            {
                var resultService = await _sedeService.UpdateSedeAsync(sede);
                var response = _responseDTO.Success(_responseDTO, resultService);
                return Ok(response);
            }
            catch (Exception ex)
            {
                var response = _responseDTO.Failed(_responseDTO, ex);
                return BadRequest(response);
            }
        }

        [HttpDelete]
        [Route("sede/{id}")]
        public async Task<IActionResult> DeleteSedeAsync(int id)
        {
            _responseDTO = new ResponseDTO();

            try
            {
                var resultService = await _sedeService.DeleteSedeAsync(id);
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
