using AutoMapper;
using Estoque.Domain.Modelos;
using Estoque.Application.Comand.Modelos;

namespace Estoque.Application.Comand.Request
{
    public class ProdutoRequestSaidaProfile : Profile
    {
        public ProdutoRequestSaidaProfile()
        {
            CreateMap<ProdutoSaida, ProdutoSaidaDTO>()
               .ForMember(dest => dest.fk_Produto_id, map => map.MapFrom(src => src.produto.id))
               .ForMember(dest => dest.fk_Saida_id, map => map.MapFrom(src => src.saida.id))
               .ForMember(dest => dest.saida, map => map.MapFrom(src => src.saida))
               .ForMember(dest => dest.produto, map => map.MapFrom(src => src.produto));
        }
    }
}
