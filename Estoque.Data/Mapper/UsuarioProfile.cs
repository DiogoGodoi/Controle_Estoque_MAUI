using AutoMapper;
using Estoque.Data.ModelosEF;
using Estoque.Domain.Modelos;

namespace Estoque.Data.Mapper
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile()
        {
            CreateMap<Usuario, UsuarioEF>()
                 .ForMember(dest => dest.id, map => map.MapFrom(src => src.id))
                 .ForMember(dest => dest.email, map => map.MapFrom(src => src.email))
                 .ForMember(dest => dest.senha, map => map.MapFrom(src => src.senha))
                 .ReverseMap();
        }
    }
}
