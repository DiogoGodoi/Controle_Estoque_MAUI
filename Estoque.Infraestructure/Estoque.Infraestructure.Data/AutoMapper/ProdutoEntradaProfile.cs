using AutoMapper;
using Estoque.Domain.Modelos;
using Estoque.Infraestructure.Data.ModelosEF;

namespace Estoque.Infraestructure.Data.AutoMapper
{
    public class ProdutoEntradaProfile : Profile
    {
        public ProdutoEntradaProfile()
        {
            CreateMap<ProdutoEntrada, ProdutoEntradaEF>()
               .ForMember(dest => dest.fk_Produto_id, map => map.MapFrom(src => src.produto.id))
               .ForMember(dest => dest.fk_Entrada_id, map => map.MapFrom(src => src.entrada.id)).ReverseMap();

            CreateMap<EntradaEF, Entrada>().ReverseMap();
            CreateMap<ProdutoEF, Produto>().ReverseMap();
        }
    }
}
