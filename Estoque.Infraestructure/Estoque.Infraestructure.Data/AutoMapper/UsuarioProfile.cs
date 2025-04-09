using AutoMapper;
using Estoque.Infraestructure.Data.ModelosEF;
using Estoque.Domain.Modelos;

namespace Estoque.Infraestructure.Data.AutoMapper
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile()
        {
            CreateMap<Usuario, UsuarioEF>()
                 .ForMember(dest => dest.id, map => map.MapFrom(src => src.id))
                 .ForMember(dest => dest.email, map => map.MapFrom(src => src.email))
                 .ForMember(dest => dest.senha, map => map.MapFrom(src => src.senha))
                 .ForMember(dest => dest.fk_Perfil_id, map => map.MapFrom(src => src.fk_Perfil_id))
                 .ForMember(dest => dest.perfil, map => map.MapFrom(src =>
                    new PerfilEF { id = src.fk_Perfil_id }));

            CreateMap<UsuarioEF, Usuario>()
                .ForMember(dest => dest.email, map => map.MapFrom(src => src.email))
                .ForMember(dest => dest.fk_Perfil_id, map => map.MapFrom(src => src.fk_Perfil_id));
        }
    }
}
