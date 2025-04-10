using AutoMapper;
using Estoque.Domain.Modelos;
using Estoque.Application.Comand.Modelos;

namespace Estoque.Application.Comand.Response
{
    public class ProdutoResponseSaidaProfile : Profile
    {
        public ProdutoResponseSaidaProfile()
        {
            CreateMap<ProdutoSaidaDTO, ProdutoSaida>()
               .ForMember(dest => dest.saida, map => map.MapFrom(src => src.saida))
               .ForMember(dest => dest.produto, map => map.MapFrom(src => src.produto));
        }
    }
}
