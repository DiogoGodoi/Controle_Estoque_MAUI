using AutoMapper;
using Estoque.Domain.Modelos;
using Estoque.Application.Comand.Modelos;

namespace Estoque.Application.Comand.Response
{
    public class ProdutoResponseEntradaProfile : Profile
    {
        public ProdutoResponseEntradaProfile()
        {
            CreateMap<ProdutoEntradaDTO, ProdutoEntrada>()
               .ForMember(dest => dest.entrada, map => map.MapFrom(src => src.entrada))
               .ForMember(dest => dest.produto, map => map.MapFrom(src => src.produto));
        }
    }
}
