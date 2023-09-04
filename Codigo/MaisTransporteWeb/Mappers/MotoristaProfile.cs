using AutoMapper;
using Core;
using MaisTransporteWeb.Models;

namespace MaisTransporteWeb.Mappers
{
    public class MotoristaProfile : Profile
    {
        public MotoristaProfile()
        {
            CreateMap<MotoristaViewModel, Passageiro>().ReverseMap();
        }
    }
}
