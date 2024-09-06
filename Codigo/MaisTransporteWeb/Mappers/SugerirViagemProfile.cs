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

            // Mapeamento de Sugestaoviagem para Viagem
            CreateMap<Sugestaoviagem, Viagem>()
                .ForMember(dest => dest.Id, opt => opt.Ignore()); // Ignora o ID porque ele será gerado automaticamente
        }
    }
}