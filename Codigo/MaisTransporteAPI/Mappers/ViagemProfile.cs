using AutoMapper;
using Core;
using MaisTransporteWeb.Models;

namespace MaisTransporteWeb.Mappers
{
    public class ViagemProfile : Profile
    {
        public ViagemProfile()
        {
            CreateMap<ViagemViewModel, Viagem>().ReverseMap();
        }
    }
}