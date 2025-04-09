using AutoMapper;
using Estoque.Infraestructure.Data.ModelosEF;
using Estoque.Domain.Modelos;

namespace Estoque.Infraestructure.Data.AutoMapper
{
    public class PerfilProfile : Profile
    {
        public PerfilProfile()
        {
            CreateMap<Perfil, PerfilEF>()
               .ForMember(dest => dest.id, map => map.MapFrom(src => src.id))
               .ForMember(dest => dest.nome, map => map.MapFrom(src => src.nome))
               .ReverseMap();
        }
    }
}
