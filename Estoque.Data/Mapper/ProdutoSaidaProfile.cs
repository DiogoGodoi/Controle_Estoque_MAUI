﻿using AutoMapper;
using Estoque.Data.ModelosEF;
using Estoque.Domain.Modelos;

namespace Estoque.Data.Mapper
{
    public class ProdutoSaidaProfile : Profile
    {
        public ProdutoSaidaProfile()
        {
            CreateMap<ProdutoSaida, ProdutoSaidaEF>()
               .ForMember(dest => dest.fk_Produto_id, map => map.MapFrom(src => src.fk_Produto_id))
               .ForMember(dest => dest.fk_Saida_id, map => map.MapFrom(src => src.fk_Saida_id))
               .ForMember(dest => dest.saida, map => map.MapFrom(src => 
                    new Saida(src.fk_Saida_id)))
               .ForMember(dest => dest.produto, map => map.MapFrom(src =>
                    new Entrada(src.fk_Produto_id)))
               .ReverseMap();
        }
    }
}
