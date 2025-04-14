using AutoMapper;
using Estoque.Domain.Modelos;
using Estoque.Infraestructure.Data.ModelosEF;

namespace Estoque.Infraestructure.Data.AutoMapper
{
    public class EntradaProfile : Profile
    {
        public EntradaProfile()
        {
            CreateMap<Entrada, EntradaEF>()
               .ForMember(dest => dest.fk_Usuario_id, map => map.MapFrom(src => src.usuario.id)).ReverseMap();

            CreateMap<UsuarioEF, Usuario>().ReverseMap();
        }
    }
}
