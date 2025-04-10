using AutoMapper;
using Estoque.Domain.Modelos;
using Estoque.Application.Comand.Modelos;

namespace Estoque.Application.Comand.Request
{
    public class PerfilRequestProfile : Profile
    {
        public PerfilRequestProfile()
        {
            CreateMap<Perfil, PerfilDTO>()
               .ForMember(dest => dest.id, map => map.MapFrom(src => src.id))
               .ForMember(dest => dest.nome, map => map.MapFrom(src => src.nome));
        }
    }
}
