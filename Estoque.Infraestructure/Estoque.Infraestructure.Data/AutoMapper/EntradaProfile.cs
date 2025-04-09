using AutoMapper;
using Estoque.Infraestructure.Data.ModelosEF;
using Estoque.Domain.Modelos;

namespace Estoque.Infraestructure.Data.AutoMapper
{
    public class EntradaProfile : Profile
    {
        public EntradaProfile()
        {
            CreateMap<Entrada, EntradaEF>()
               .ForMember(dest => dest.id, map => map.MapFrom(src => src.id))
               .ForMember(dest => dest.dataEntrada, map => map.MapFrom(src => src.dataEntrada))
               .ForMember(dest => dest.fk_Usuario_id, map => map.MapFrom(src => src.fk_Usuario_id))
               .ForMember(dest => dest.quantidade, map => map.MapFrom(src => src.quantidade))
               .ForMember(dest => dest.usuario, map => map.MapFrom(src =>
                    new Usuario(src.fk_Usuario_id)))
               .ReverseMap();
        }
    }
}
