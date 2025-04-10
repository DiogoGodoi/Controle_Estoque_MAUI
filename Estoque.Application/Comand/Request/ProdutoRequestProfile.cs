using AutoMapper;
using Estoque.Domain.Modelos;
using Estoque.Application.Comand.Modelos;

namespace Estoque.Application.Comand.Request
{
    public class ProdutoRequestProfile : Profile
    {
        public ProdutoRequestProfile()
        {
            CreateMap<Produto, ProdutoDTO>()
               .ForMember(dest => dest.id, map => map.MapFrom(src => src.id))
               .ForMember(dest => dest.descricao, map => map.MapFrom(src => src.descricao))
               .ForMember(dest => dest.unidade, map => map.MapFrom(src => src.unidade))
               .ForMember(dest => dest.quantidade, map => map.MapFrom(src => src.quantidade))
               .ForMember(dest => dest.preco1, map => map.MapFrom(src => src.preco1))
               .ForMember(dest => dest.preco2, map => map.MapFrom(src => src.preco2))
               .ForMember(dest => dest.preco3, map => map.MapFrom(src => src.preco3))
               .ForMember(dest => dest.precoMedio, map => map.MapFrom(src => src.precoMedio))
               .ForMember(dest => dest.estoqueMin, map => map.MapFrom(src => src.estoqueMin))
               .ForMember(dest => dest.fk_LocalEstoque_id, map => map.MapFrom(src => src.localEstoque.id))
               .ForMember(dest => dest.fk_Usuario_id, map => map.MapFrom(src => src.usuario.id))
               .ForMember(dest => dest.fk_Categoria_id, map => map.MapFrom(src => src.categoria.id))
               .ForMember(dest => dest.localEstoque, map => map.MapFrom(src => new LocalEstoqueDTO()))
               .ForMember(dest => dest.usuario, map => map.MapFrom(src => src.usuario))
               .ForMember(dest => dest.categoria, map => map.MapFrom(src => src.categoria));
        }
    }
}
