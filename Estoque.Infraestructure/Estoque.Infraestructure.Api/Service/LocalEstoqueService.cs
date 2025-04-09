using Estoque.Application.Interfaces;
using Estoque.Domain.Modelos;
using Estoque.Infraestructure.Api.Service.Abstraction;

namespace Estoque.Infraestructure.Api.Service
{
    public class LocalEstoqueService: IService<LocalEstoque>
    {
        private readonly IRepository<LocalEstoque> _LocalEstoqueRepository;
        public LocalEstoqueService(IRepository<LocalEstoque> LocalEstoqueRepository)
        {
            _LocalEstoqueRepository = LocalEstoqueRepository;
        }
        public async Task Atualizar(string id, LocalEstoque objeto)
        {
            try
            {
                await _LocalEstoqueRepository.Atualizar(id, objeto);
            }
            catch
            {
                throw;
            }
        }
        public async Task<LocalEstoque> Buscar(string id)
        {
            try
            {
                var LocalEstoque = await _LocalEstoqueRepository.Buscar(id);

                return LocalEstoque;
            }
            catch
            {
                throw;
            }
        }
        public async Task Cadastrar(string id, LocalEstoque objeto)
        {
            try
            {
                await _LocalEstoqueRepository.Cadastrar(objeto);
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
                await _LocalEstoqueRepository.Deletar(id);
            }
            catch
            {
                throw;
            }
        }
        public async Task<IEnumerable<LocalEstoque>> Listar()
        {
            try
            {
                var LocalEstoques = await _LocalEstoqueRepository.Listar();

                return LocalEstoques;
            }
            catch
            {
                throw;
            }
        }
    }
}
