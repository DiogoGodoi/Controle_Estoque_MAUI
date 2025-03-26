using AutoMapper;
using Estoque.Infraestructure.Data.ModelosEF;
using Estoque.Domain.Modelos;

namespace Estoque.Infraestructure.Data.Mapper
{
    public class LocalEstoqueProfile : Profile
    {
        public LocalEstoqueProfile()
        {
            CreateMap<LocalEstoque, LocalEstoqueEF>()
               .ForMember(dest => dest.id, map => map.MapFrom(src => src.id))
               .ForMember(dest => dest.nome, map => map.MapFrom(src => src.nome))
               .ReverseMap();
        }
    }
}
