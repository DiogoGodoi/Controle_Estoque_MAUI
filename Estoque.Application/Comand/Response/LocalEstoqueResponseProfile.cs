using AutoMapper;
using Estoque.Domain.Modelos;
using Estoque.Application.Comand.Modelos;

namespace Estoque.Application.Comand.Response
{
    public class LocalEstoqueResponseProfile : Profile
    {
        public LocalEstoqueResponseProfile()
        {
            CreateMap<LocalEstoqueDTO, LocalEstoque>()
               .ForMember(dest => dest.id, map => map.MapFrom(src => src.id))
               .ForMember(dest => dest.nome, map => map.MapFrom(src => src.nome));
        }
    }
}
