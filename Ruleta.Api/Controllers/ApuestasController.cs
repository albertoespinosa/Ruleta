using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ruleta.Api.Responses;
using Ruleta.Core.DTOs.Apuesta;
using Ruleta.Core.Entities;
using Ruleta.Core.Exceptions;
using Ruleta.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Ruleta.Api.Controllers
{
    [Route("apuestas")]
    [ApiController]
    public class ApuestasController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IApuestaService _ApuestasService;

        public ApuestasController(IMapper mapper, IApuestaService apuestasService)
        {
            this._ApuestasService = apuestasService;
            this._mapper = mapper;
        }
        
        // GET: /Apuestas
        
        [HttpGet]
        public async Task<IActionResult> GetAllApuestas()
        {
            var apuestas = await _ApuestasService.GetApuestas();
            var ApuestasDto = _mapper.Map<IEnumerable<GetApuestaDto>>(apuestas);

            var response = new ApiResponse<IEnumerable<GetApuestaDto>>(ApuestasDto);
            response.success = true;
            response.Message = "Listado de Apuestas";

            return Ok(response);
        }     

        //POST: Nueva Apuesta      

        [HttpPost("nueva")]
        public async Task<IActionResult> InsertApuesta([FromBody] SaveApuestaDto saveApuestaDto)
        {
            var apuesta = _mapper.Map<Apuesta>(saveApuestaDto);

            await _ApuestasService.InsertApuesta(apuesta);

            apuesta = await _ApuestasService.GetApuesta(apuesta.Id);

            var ApuestaDto = _mapper.Map<GetApuestaDto>(apuesta);

            var response = new ApiResponse<GetApuestaDto>(ApuestaDto);
            response.success = true;
            response.Message = "La Apuesta ha sido Aceptada";

            return Ok(response);
        }        
    }
}
