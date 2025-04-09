using Estoque.Application.Interfaces;
using Estoque.Domain.Modelos;
using Estoque.Infraestructure.Api.Service.Abstraction;

namespace Estoque.Infraestructure.Api.Service
{
    public class UsuarioService : IService<Usuario>
    {
        private readonly IRepository<Usuario> _repositoryUsuario;
        public UsuarioService(IRepository<Usuario> repositoryUsuario)
        {
            _repositoryUsuario = repositoryUsuario;
        }
        public async Task Atualizar(string id, Usuario objeto)
        {
            try
            {
                await _repositoryUsuario.Atualizar(id, objeto);
            }
            catch
            {
                throw;
            }
        }
        public async Task<Usuario> Buscar(string id)
        {
            try
            {
                var usuario = await _repositoryUsuario.Buscar(id);

                return usuario;
            }
            catch
            {
                throw;
            }
        }
        public async Task Cadastrar(string id, Usuario objeto)
        {
            try
            {
                await _repositoryUsuario.Cadastrar(objeto);
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
                await _repositoryUsuario.Deletar(id);
            }
            catch
            {
                throw;
            }
        }
        public async Task<IEnumerable<Usuario>> Listar()
        {
            try
            {
                var usuarios = await _repositoryUsuario.Listar();

                return usuarios;
            }
            catch
            {
                throw;
            }
        }
    }
}
