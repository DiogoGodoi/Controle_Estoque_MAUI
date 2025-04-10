using AutoMapper;
using Estoque.Domain.Modelos;
using Estoque.Application.Comand.Modelos;

namespace Estoque.Application.Comand.Request
{
    public class ProdutoRequestEntradaProfile : Profile
    {
        public ProdutoRequestEntradaProfile()
        {
            CreateMap<ProdutoEntrada, ProdutoEntradaDTO>()
               .ForMember(dest => dest.fk_Produto_id, map => map.MapFrom(src => src.produto.id))
               .ForMember(dest => dest.fk_Entrada_id, map => map.MapFrom(src => src.entrada.id))
               .ForMember(dest => dest.entrada, map => map.MapFrom(src => src.entrada))
               .ForMember(dest => dest.produto, map => map.MapFrom(src => src.produto));
        }
    }
}
