using AutoMapper;
using Estoque.Domain.Modelos;
using Estoque.Infraestructure.Data.ModelosEF;

namespace Estoque.Infraestructure.Data.AutoMapper
{
    public class ProdutoProfile : Profile
    {
        public ProdutoProfile()
        {
            CreateMap<Produto, ProdutoEF>()
             .ForMember(dest => dest.fk_LocalEstoque_id, map => map.MapFrom(src => src.localEstoque.id))
             .ForMember(dest => dest.fk_Usuario_id, map => map.MapFrom(src => src.usuario.id))
             .ForMember(dest => dest.fk_Categoria_id, map => map.MapFrom(src => src.categoria.id))
             .ReverseMap();

            CreateMap<LocalEstoqueEF, LocalEstoque>().ReverseMap();
            CreateMap<UsuarioEF, Usuario>().ReverseMap();
            CreateMap<CategoriaEF, Categoria>().ReverseMap();
        }
    }
}
