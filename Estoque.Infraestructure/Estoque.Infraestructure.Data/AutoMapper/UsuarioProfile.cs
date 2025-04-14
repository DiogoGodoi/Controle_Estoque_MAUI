using AutoMapper;
using Estoque.Domain.Modelos;
using Estoque.Infraestructure.Data.ModelosEF;

namespace Estoque.Infraestructure.Data.AutoMapper
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile()
        {
            CreateMap<Usuario, UsuarioEF>()
                 .ForMember(dest => dest.fk_Perfil_id, map => map.MapFrom(src => src.perfil.id)).ReverseMap();

            CreateMap<PerfilEF, Perfil>().ReverseMap();
        }
    }
}
