using AutoMapper;
using Estoque.Infraestructure.Data.ModelosEF;
using Estoque.Domain.Modelos;

namespace Estoque.Infraestructure.Data.AutoMapper
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
