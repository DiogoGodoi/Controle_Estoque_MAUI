using AutoMapper;
using Estoque.Application.Comand.Modelos;
using Estoque.Application.Interfaces;
using Estoque.Domain.Modelos;
using Estoque.Infraestructure.Api.Service.Interface;

namespace Estoque.Infraestructure.Api.Service
{
    public class PerfilService : IService<Perfil>, IServiceDTO<PerfilDTO>
    {
        private readonly IRepository<Perfil> _repositoryPerfil;
        private readonly IMapper _mapper;
        public PerfilService(IRepository<Perfil> repositoryPerfil, IMapper mapper)
        {
            _repositoryPerfil = repositoryPerfil;
            _mapper = mapper;
        }
        public async Task Atualizar(string id, Perfil objeto)
        {
            try
            {
                await _repositoryPerfil.Atualizar(id, objeto);
            }
            catch
            {
                throw;
            }
        }
        public async Task<PerfilDTO> Buscar(string id)
        {
            try
            {
                var perfil = await _repositoryPerfil.Buscar(id);

                var perfilMap = _mapper.Map<PerfilDTO>(perfil);

                return perfilMap;
            }
            catch
            {
                throw;
            }
        }
        public async Task Cadastrar(string id, Perfil objeto)
        {
            try
            {
                await _repositoryPerfil.Cadastrar(objeto);
            }
            catch
            {
                throw;
            }
        }
        public async Task Deletar(string id)
        {
            try
            {
                await _repositoryPerfil.Deletar(id);
            }
            catch
            {
                throw;
            }
        }
        public async Task<IEnumerable<PerfilDTO>> Listar()
        {
            try
            {
                var perfis = await _repositoryPerfil.Listar();

                var perfisMap = _mapper.Map<IEnumerable<PerfilDTO>>(perfis);

                return perfisMap;
            }
            catch
            {
                throw;
            }
        }
    }
}
