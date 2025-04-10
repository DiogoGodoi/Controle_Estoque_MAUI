using AutoMapper;
using Estoque.Application.Comand.Modelos;
using Estoque.Application.Interfaces;
using Estoque.Domain.Modelos;
using Estoque.Infraestructure.Api.Service.Interface;

namespace Estoque.Infraestructure.Api.Service
{
    public class UsuarioService : IService<Usuario>, IServiceDTO<UsuarioDTO>
    {
        private readonly IRepository<Usuario> _repositoryUsuario;
        private readonly IMapper _mapper;
        public UsuarioService(IRepository<Usuario> repositoryUsuario, IMapper mapper)
        {
            _repositoryUsuario = repositoryUsuario;
            _mapper = mapper;
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
        public async Task<UsuarioDTO> Buscar(string id)
        {
            try
            {
                var usuario = await _repositoryUsuario.Buscar(id);

                var usuarioMap = _mapper.Map<UsuarioDTO>(usuario);

                return usuarioMap;
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
        public async Task<IEnumerable<UsuarioDTO>> Listar()
        {
            try
            {
                var usuarios = await _repositoryUsuario.Listar();

                var usuariosMap = _mapper.Map<IEnumerable<UsuarioDTO>>(usuarios);

                return usuariosMap;
            }
            catch
            {
                throw;
            }
        }
    }
}
