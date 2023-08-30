using AutoMapper;
using Core;
using MaisTransporteWeb.Models;

namespace MaisTransporteWeb.Mappers
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile()
        {
            CreateMap<UsuarioViewModel, Passageiro>().ReverseMap();
        }
    }
}