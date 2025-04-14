using AutoMapper;
using Estoque.Domain.Modelos;
using Estoque.Infraestructure.Data.ModelosEF;

namespace Estoque.Infraestructure.Data.AutoMapper
{
    public class CategoriaProfile : Profile
    {
        public CategoriaProfile()
        {
            CreateMap<Categoria, CategoriaEF>()
               .ForMember(dest => dest.fk_Usuario_id, map => map.MapFrom(src => src.usuario.id)).ReverseMap();

            CreateMap<UsuarioEF, Usuario>().ReverseMap();
        }
    }
}
