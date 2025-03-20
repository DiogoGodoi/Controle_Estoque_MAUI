using AutoMapper;
using Estoque.Data.DTO;
using Estoque.Data.ModelosEF;
using Estoque.Domain.Modelos;

namespace Estoque.Data.Mapping
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

            CreateMap<Categoria, CategoriaEF>()
               .ForMember(dest => dest.id, map => map.MapFrom(src => src.id))
               .ForMember(dest => dest.nome, map => map.MapFrom(src => src.nome))
               .ForMember(dest => dest.fk_Usuario_id, map => map.MapFrom(src => src.fk_Usuario_id))
               .ReverseMap();
        }
    }
}
