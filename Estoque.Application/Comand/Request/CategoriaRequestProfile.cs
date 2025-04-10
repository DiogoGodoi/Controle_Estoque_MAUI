using AutoMapper;
using Estoque.Domain.Modelos;
using Estoque.Application.Comand.Modelos;

namespace Estoque.Application.Comand.Request
{
    public class CategoriaRequestProfile : Profile
    {
        public CategoriaRequestProfile()
        {
            CreateMap<Categoria, CategoriaDTO>()
               .ForMember(dest => dest.id, map => map.MapFrom(src => src.id))
               .ForMember(dest => dest.nome, map => map.MapFrom(src => src.nome))
               .ForMember(dest => dest.fk_Usuario_id, map => map.MapFrom(src => src.usuario.id))
               .ForMember(dest => dest.usuario, map => map.MapFrom(src => src.usuario));
        }
    }
}
