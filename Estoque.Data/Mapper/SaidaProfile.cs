using AutoMapper;
using Estoque.Data.ModelosEF;
using Estoque.Domain.Modelos;

namespace Estoque.Data.Mapper
{
    public class SaidaProfile : Profile
    {
        public SaidaProfile()
        {
            CreateMap<Saida, SaidaEF>()
               .ForMember(dest => dest.id, map => map.MapFrom(src => src.id))
               .ForMember(dest => dest.dataSaida, map => map.MapFrom(src => src.dataSaida))
               .ForMember(dest => dest.fk_Usuario_id, map => map.MapFrom(src => src.fk_Usuario_id))
               .ForMember(dest => dest.quantidade, map => map.MapFrom(src => src.quantidade))
               .ForMember(dest => dest.usuario, map => map.MapFrom(src =>
                    new Usuario(src.fk_Usuario_id)))
               .ReverseMap();
        }
    }
}
