using AutoMapper;
using Estoque.Domain.Modelos;
using Estoque.Application.Comand.Modelos;

namespace Estoque.Application.Comand.Request
{
    public class EntradaRequestProfile : Profile
    {
        public EntradaRequestProfile()
        {
            CreateMap<Entrada, EntradaDTO>()
               .ForMember(dest => dest.id, map => map.MapFrom(src => src.id))
               .ForMember(dest => dest.dataEntrada, map => map.MapFrom(src => src.dataEntrada))
               .ForMember(dest => dest.fk_Usuario_id, map => map.MapFrom(src => src.usuario.id))
               .ForMember(dest => dest.quantidade, map => map.MapFrom(src => src.quantidade))
               .ForMember(dest => dest.usuario, map => map.MapFrom(src => src.usuario));
        }
    }
}
