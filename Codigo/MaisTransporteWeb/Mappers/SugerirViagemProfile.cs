using AutoMapper;
using MaisTransporteWeb.Models;
using Core;

namespace MaisTransporteWeb.Mappers
{
    public class SugerirViagemProfile : Profile
    {
        public SugerirViagemProfile()
        {
            CreateMap<SugerirViagemViewModel, Sugestaoviagem>().ReverseMap();
        }
    }
}