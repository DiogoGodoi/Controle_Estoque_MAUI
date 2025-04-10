using AutoMapper;
using Estoque.Domain.Modelos;
using Estoque.Application.Comand.Modelos;

namespace Estoque.Application.Comand.Response
{
    public class PerfilResponseProfile : Profile
    {
        public PerfilResponseProfile()
        {
            CreateMap<PerfilDTO, Perfil>()
               .ForMember(dest => dest.id, map => map.MapFrom(src => src.id))
               .ForMember(dest => dest.nome, map => map.MapFrom(src => src.nome));
        }
    }
}
