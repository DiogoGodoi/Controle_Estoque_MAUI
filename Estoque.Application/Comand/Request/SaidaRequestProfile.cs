using AutoMapper;
using Estoque.Domain.Modelos;
using Estoque.Application.Comand.Modelos;

namespace Estoque.Application.Comand.Request
{
    public class SaidaRequestProfile : Profile
    {
        public SaidaRequestProfile()
        {
            CreateMap<Saida, SaidaDTO>()
               .ForMember(dest => dest.id, map => map.MapFrom(src => src.id))
               .ForMember(dest => dest.dataSaida, map => map.MapFrom(src => src.dataSaida))
               .ForMember(dest => dest.fk_Usuario_id, map => map.MapFrom(src => src.usuario.id))
               .ForMember(dest => dest.quantidade, map => map.MapFrom(src => src.quantidade))
               .ForMember(dest => dest.usuario, map => map.MapFrom(src => src.usuario));
        }
    }
}
