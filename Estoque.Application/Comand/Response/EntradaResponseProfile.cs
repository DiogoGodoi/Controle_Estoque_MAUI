using AutoMapper;
using Estoque.Domain.Modelos;
using Estoque.Application.Comand.Modelos;

namespace Estoque.Application.Comand.Response
{
    public class EntradaResponseProfile : Profile
    {
        public EntradaResponseProfile()
        {
            CreateMap<EntradaDTO, Entrada>()
               .ForMember(dest => dest.id, map => map.MapFrom(src => src.id))
               .ForMember(dest => dest.dataEntrada, map => map.MapFrom(src => src.dataEntrada))
               .ForMember(dest => dest.quantidade, map => map.MapFrom(src => src.quantidade))
               .ForMember(dest => dest.usuario, map => map.MapFrom(src => src.usuario));
        }
    }
}
