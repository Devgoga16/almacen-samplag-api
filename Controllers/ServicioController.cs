﻿using almacen_samplag.Models;
using almacen_samplag.Models.Request;
using almacen_samplag.Models.Response;
using almacen_samplag.Services.Implementantions;
using almacen_samplag.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace almacen_samplag.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicioController : ControllerBase
    {
        private ResponseDTO _responseDTO;
        private readonly IServicioService _servicioService;

        public ServicioController(IServicioService servicioService)
        {
            _servicioService = servicioService;
        }

        [HttpPost]
        public async Task<ActionResult<ServicioResponse>> InsertProductoAsync([FromBody] ServicioRequest servicio)
        {
            _responseDTO = new ResponseDTO();

            try
            {
                var resultService = await _servicioService.InsertServicioAsync(servicio);
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
