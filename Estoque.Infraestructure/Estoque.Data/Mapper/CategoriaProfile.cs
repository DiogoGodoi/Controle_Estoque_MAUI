using AutoMapper;
using Estoque.Data.ModelosEF;
using Estoque.Domain.Modelos;

namespace Estoque.Data.Mapper
{
    public class CategoriaProfile : Profile
    {
        public CategoriaProfile()
        {
            CreateMap<Categoria, CategoriaEF>()
               .ForMember(dest => dest.id, map => map.MapFrom(src => src.id))
               .ForMember(dest => dest.nome, map => map.MapFrom(src => src.nome))
               .ForMember(dest => dest.fk_Usuario_id, map => map.MapFrom(src => src.fk_Usuario_id))
               .ForMember(dest => dest.usuario, map => map.MapFrom(src =>
                    new Usuario(src.fk_Usuario_id)))
               .ReverseMap();
        }
    }
}
