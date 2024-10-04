using AutoMapper;
using MaisTransporteWeb.Models;
using Core;

namespace MaisTransporteWeb.Mappers
{
    public class SugestaoviagemProfile : Profile
    {
        public SugestaoviagemProfile()
        {
            CreateMap<SugestaoviagemViewModel, Sugestaoviagem>().ReverseMap();
        }
    }
}