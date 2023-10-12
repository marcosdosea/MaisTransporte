using AutoMapper;
using Core;
using MaisTransporteWeb.Models;

namespace MaisTransporteWeb.Mappers
{
    public class AvaliarViagemProfile : Profile
    {
        public AvaliarViagemProfile()
        {
            CreateMap<AvaliarViagemViewModel, Avaliacao>().ReverseMap();
        }
    }
}
