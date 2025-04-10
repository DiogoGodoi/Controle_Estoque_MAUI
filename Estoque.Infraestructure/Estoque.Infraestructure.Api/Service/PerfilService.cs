using Estoque.Application.Interfaces;
using Estoque.Domain.Modelos;
using Estoque.Infraestructure.Api.Service.Abstraction;

namespace Estoque.Infraestructure.Api.Service
{
    public class PerfilService : IService<Perfil>
    {
        private readonly IRepository<Perfil> _repositoryPerfil;
        public PerfilService(IRepository<Perfil> repositoryPerfil)
        {
            _repositoryPerfil = repositoryPerfil;
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
        public async Task<Perfil> Buscar(string id)
        {
            try
            {
                var perfil = await _repositoryPerfil.Buscar(id);

                return perfil;
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
        public async Task<IEnumerable<Perfil>> Listar()
        {
            try
            {
                var perfis = await _repositoryPerfil.Listar();

                return perfis;
            }
            catch
            {
                throw;
            }
        }
    }
}
