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

            // Mapeamento de Sugestaoviagem para Viagem
            CreateMap<Sugestaoviagem, Viagem>()
                .ForMember(dest => dest.Id, opt => opt.Ignore()); // Ignora o ID porque ele será gerado automaticamente
        }
    }
}