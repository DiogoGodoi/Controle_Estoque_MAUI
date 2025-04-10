using AutoMapper;
using Estoque.Domain.Modelos;
using Estoque.Application.Comand.Modelos;

namespace Estoque.Application.Comand.Response
{
    public class UsuarioResponseProfile : Profile
    {
        public UsuarioResponseProfile()
        {
            CreateMap<UsuarioDTO, Usuario>()
                 .ForMember(dest => dest.id, map => map.MapFrom(src => src.id))
                 .ForMember(dest => dest.email, map => map.MapFrom(src => src.email))
                 .ForMember(dest => dest.perfil, map => map.MapFrom(src => new Perfil()));
        }
    }
}
