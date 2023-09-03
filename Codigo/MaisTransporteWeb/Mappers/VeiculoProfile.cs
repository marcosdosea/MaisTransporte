using AutoMapper;
using Core;
using MaisTransporteWeb.Models;

namespace MaisTransporteWeb.Mappers
{
    public class VeiculoProfile : Profile
    {
        public VeiculoProfile() 
        {
            CreateMap<VeiculoViewModel, Veiculo>().ReverseMap();
        }
    }
}
