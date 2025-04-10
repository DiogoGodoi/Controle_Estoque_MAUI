using AutoMapper;
using Estoque.Domain.Modelos;
using Estoque.Application.Comand.Modelos;

namespace Estoque.Application.Comand.Request
{
    public class UsuarioRequestProfile : Profile
    {
        public UsuarioRequestProfile()
        {
            CreateMap<Usuario, UsuarioDTO>()
                 .ForMember(dest => dest.id, map => map.MapFrom(src => src.id))
                 .ForMember(dest => dest.email, map => map.MapFrom(src => src.email))
                 .ForMember(dest => dest.senha, map => map.MapFrom(src => src.senha))
                 .ForMember(dest => dest.fk_Perfil_id, map => map.MapFrom(src => src.perfil.id))
                 .ForMember(dest => dest.perfil, map => map.MapFrom(src => new PerfilDTO()));
        }
    }
}
