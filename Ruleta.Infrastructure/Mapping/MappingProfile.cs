using AutoMapper;
using Ruleta.Core.DTOs.Apuesta;
using Ruleta.Core.DTOs.JuegoRuleta;
using Ruleta.Core.Entities;

namespace Ruleta.Infrastructure.Mapping
{
    class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Entities To DTOs 
           
            CreateMap<JuegoRuleta, GetJuegoRuletaDto>();
            CreateMap<Apuesta, GetApuestaDto>();           


            // DTOs To Entities   
            CreateMap<SaveJuegoRuletaDto, JuegoRuleta>().ReverseMap();
            CreateMap<SaveApuestaDto, Apuesta>().ReverseMap();
        }
    }
}
