using AutoMapper;
using Estoque.Domain.Modelos;
using Estoque.Infraestructure.Data.ModelosEF;

namespace Estoque.Infraestructure.Data.AutoMapper
{
    public class ProdutoSaidaProfile : Profile
    {
        public ProdutoSaidaProfile()
        {
            CreateMap<ProdutoSaida, ProdutoSaidaEF>()
               .ForMember(dest => dest.fk_Produto_id, map => map.MapFrom(src => src.produto.id))
               .ForMember(dest => dest.fk_Saida_id, map => map.MapFrom(src => src.saida.id)).ReverseMap();

            CreateMap<SaidaEF, Saida>().ReverseMap();
            CreateMap<ProdutoEF, Produto>().ReverseMap();
        }
    }
}
