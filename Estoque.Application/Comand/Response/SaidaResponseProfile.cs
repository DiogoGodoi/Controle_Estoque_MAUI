using AutoMapper;
using Estoque.Domain.Modelos;
using Estoque.Application.Comand.Modelos;

namespace Estoque.Application.Comand.Response
{
    public class SaidaResponseProfile : Profile
    {
        public SaidaResponseProfile()
        {
            CreateMap<SaidaDTO, Saida>()
               .ForMember(dest => dest.id, map => map.MapFrom(src => src.id))
               .ForMember(dest => dest.dataSaida, map => map.MapFrom(src => src.dataSaida))
               .ForMember(dest => dest.quantidade, map => map.MapFrom(src => src.quantidade))
               .ForMember(dest => dest.usuario, map => map.MapFrom(src => src.usuario));
        }
    }
}
