using AutoMapper;
using Estoque.Infraestructure.Data.ModelosEF;
using Estoque.Domain.Modelos;

namespace Estoque.Infraestructure.Data.Mapper
{
    public class ProdutoEntradaProfile : Profile
    {
        public ProdutoEntradaProfile()
        {
            CreateMap<ProdutoEntrada, ProdutoEntradaEF>()
               .ForMember(dest => dest.fk_Produto_id, map => map.MapFrom(src => src.fk_Produto_id))
               .ForMember(dest => dest.fk_Entrada_id, map => map.MapFrom(src => src.fk_Entrada_id))
               .ForMember(dest => dest.entrada, map => map.MapFrom(src => 
                    new Entrada(src.fk_Entrada_id)))
               .ForMember(dest => dest.produto, map => map.MapFrom(src =>
                    new Produto(src.fk_Produto_id)))
               .ReverseMap();
        }
    }
}
