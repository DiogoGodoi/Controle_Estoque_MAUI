using AutoMapper;
using Estoque.Domain.Modelos;
using Estoque.Infraestructure.Data.ModelosEF;

namespace Estoque.Infraestructure.Data.AutoMapper
{
    public class LocalEstoqueProfile : Profile
    {
        public LocalEstoqueProfile()
        {
            CreateMap<LocalEstoque, LocalEstoqueEF>()
               .ForMember(dest => dest.id, map => map.MapFrom(src => src.id))
               .ForMember(dest => dest.nome, map => map.MapFrom(src => src.nome)).ReverseMap();
        }
    }
}
