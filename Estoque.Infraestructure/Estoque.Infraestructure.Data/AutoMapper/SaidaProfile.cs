using AutoMapper;
using Estoque.Domain.Modelos;
using Estoque.Infraestructure.Data.ModelosEF;

namespace Estoque.Infraestructure.Data.AutoMapper
{
    public class SaidaProfile : Profile
    {
        public SaidaProfile()
        {
            CreateMap<Saida, SaidaEF>()
               .ForMember(dest => dest.fk_Usuario_id, map => map.MapFrom(src => src.usuario.id)).ReverseMap();

            CreateMap<UsuarioEF, Usuario>().ReverseMap();
        }
    }
}
