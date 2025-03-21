using AutoMapper;
using Estoque.Data.ModelosEF;
using Estoque.Domain.Modelos;

namespace Estoque.Data.Mapper
{
    public class ProdutoProfile : Profile
    {
        public ProdutoProfile()
        {
            CreateMap<Produto, ProdutoEF>()
               .ForMember(dest => dest.id, map => map.MapFrom(src => src.id))
               .ForMember(dest => dest.descricao, map => map.MapFrom(src => src.descricao))
               .ForMember(dest => dest.unidade, map => map.MapFrom(src => src.unidade))
               .ForMember(dest => dest.quantidade, map => map.MapFrom(src => src.quantidade))
               .ForMember(dest => dest.preco1, map => map.MapFrom(src => src.preco1))
               .ForMember(dest => dest.preco2, map => map.MapFrom(src => src.preco2))
               .ForMember(dest => dest.preco3, map => map.MapFrom(src => src.preco3))
               .ForMember(dest => dest.precoMedio, map => map.MapFrom(src => src.precoMedio))
               .ForMember(dest => dest.fk_Usuario_id, map => map.MapFrom(src => src.fk_Usuario_id))
               .ForMember(dest => dest.fk_Categoria_id, map => map.MapFrom(src => src.fk_Categoria_id))
               .ForMember(dest => dest.usuario, map => map.MapFrom(src =>
                    new Usuario(src.fk_Usuario_id)))
               .ForMember(dest => dest.categoria, map => map.MapFrom(src =>
                    new Usuario(src.fk_Categoria_id)))
               .ReverseMap();
        }
    }
}
