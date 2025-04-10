using AutoMapper;
using Estoque.Domain.Modelos;
using Estoque.Application.Comand.Modelos;

namespace Estoque.Application.Comand.Response
{
    public class CategoriaResponseProfile : Profile
    {
        public CategoriaResponseProfile()
        {
            CreateMap<CategoriaDTO, Categoria>()
               .ForMember(dest => dest.id, map => map.MapFrom(src => src.id))
               .ForMember(dest => dest.nome, map => map.MapFrom(src => src.nome))
               .ForMember(dest => dest.usuario, map => map.MapFrom(src => src.usuario));
        }
    }
}
