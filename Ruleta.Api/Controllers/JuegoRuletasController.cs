using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ruleta.Api.Responses;
using Ruleta.Core.DTOs.Apuesta;
using Ruleta.Core.DTOs.JuegoRuleta;
using Ruleta.Core.Entities;
using Ruleta.Core.Exceptions;
using Ruleta.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Ruleta.Api.Controllers
{
    [Route("ruletas")]
    [ApiController]
    public class JuegoRuletasController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IJuegoRuletaService _JuegoRuletasService;

        public JuegoRuletasController(IMapper mapper, IJuegoRuletaService juegoRuletasService)
        {
            this._JuegoRuletasService = juegoRuletasService;
            this._mapper = mapper;
        }
        
        // GET: /ruletas
        
        [HttpGet("jugar/{ruletaid}/{numeroganador}")]
        public async Task<IActionResult> GetJugarRuleta(int ruletaid, int numeroganador)
        {
            var ruletaApuestas = await _JuegoRuletasService.GetRuletaApuestas(ruletaid, numeroganador);
            var ruletaApuestasDto = _mapper.Map<IEnumerable<GetApuestaDto>>(ruletaApuestas);

            var response = new ApiResponse<IEnumerable<GetApuestaDto>>(ruletaApuestasDto);          
            response.success = true;
            response.Message = "Ruletas";

            return Ok(response);
        }

        // GET: /ruletas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetJuegoRuletaDto>> GetJuegoRuletaById(int id)
        {
            var juegoRuleta = await _JuegoRuletasService.GetJuegoRuleta(id);

            if (juegoRuleta == null)
            {
                throw new NotFoundException("No Existe la Ruleta: " + id);
            }

            var juegoRuletaDto = _mapper.Map<GetJuegoRuletaDto>(juegoRuleta);
            var response = new ApiResponse<GetJuegoRuletaDto>(juegoRuletaDto);
            response.success = true;
            return Ok(response);
        }

        //POST: juegoRuletas       

        [HttpPost("nueva")]
        public async Task<IActionResult> InsertJuegoRuleta()
        {
            JuegoRuleta NuevoJuego = new JuegoRuleta();
            await _JuegoRuletasService.InsertJuegoRuleta(NuevoJuego);

            NuevoJuego = await _JuegoRuletasService.GetJuegoRuleta(NuevoJuego.Id);

            var JuegoRuletaDto = _mapper.Map<GetJuegoRuletaDto>(NuevoJuego);

            var response = new ApiResponse<GetJuegoRuletaDto>(JuegoRuletaDto);
            response.success = true;
            response.Message = "La ruleta ha sido creada";

            return Ok(response);
        }    

        //PUT: ruletas/5

        [HttpPut("activar/{id}")]
        public async Task<IActionResult> ActivateClosedJuegoRuleta(int id)
        {
            var juegoRuleta = await _JuegoRuletasService.GetJuegoRuleta(id);

            if (juegoRuleta == null)
                throw new NotFoundException("No Existe la Ruleta que Quiere Activarse");

            if (juegoRuleta.Estado != "Creada")
                throw new BusinessException("Esta Ruleta ya se encuentra Activada");
            
            juegoRuleta.Estado = "Activada";

            await _JuegoRuletasService.UpdateJuegoRuleta(juegoRuleta);

            var result = _mapper.Map<SaveJuegoRuletaDto>(juegoRuleta);

            var response = new ApiResponse<SaveJuegoRuletaDto>(result);
            response.success = true;
            response.Message = "La Ruleta Ha Sido Activada";

            return Ok(response);
        }       
    }
}
