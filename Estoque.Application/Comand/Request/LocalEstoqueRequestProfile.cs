using AutoMapper;
using Estoque.Domain.Modelos;
using Estoque.Application.Comand.Modelos;

namespace Estoque.Application.Comand.Request
{
    public class LocalEstoqueRequestProfile : Profile
    {
        public LocalEstoqueRequestProfile()
        {
            CreateMap<LocalEstoque, LocalEstoqueDTO>()
               .ForMember(dest => dest.id, map => map.MapFrom(src => src.id))
               .ForMember(dest => dest.nome, map => map.MapFrom(src => src.nome));
        }
    }
}
