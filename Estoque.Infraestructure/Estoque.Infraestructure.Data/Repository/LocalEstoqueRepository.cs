using Estoque.Application.Interfaces;
using Estoque.Domain.Modelos;
using Estoque.Infraestructure.Data.Context;
using Estoque.Infraestructure.Data.Extend;
using Estoque.Infraestructure.Data.ModelosEF;
using Microsoft.EntityFrameworkCore;

namespace Estoque.Infraestructure.Data.Repository
{
    public class LocalEstoqueRepository : IRepository<LocalEstoque>
    {
        private readonly ContextSqlServer ContextSqlServer;
        public LocalEstoqueRepository(ContextSqlServer ContextSqlServer)
        {
            this.ContextSqlServer = ContextSqlServer;
        }
        public async Task Atualizar(string id, LocalEstoque objeto)
        {
            try
            {
                var LocalEstoqueMapping = objeto.toLocalEstoqueEF();

                var LocalEstoqueEF = await ContextSqlServer.locaisEstoque.FirstOrDefaultAsync(x => x.id == Guid.Parse(id));

                if (LocalEstoqueEF == null)
                    throw new Exception("Local de estoque não encontrada");

                if (LocalEstoqueEF.nome == objeto.nome)
                    throw new Exception("Já existe um local de estoque com esse nome");

                LocalEstoqueEF.nome = LocalEstoqueMapping.nome;

                ContextSqlServer.locaisEstoque.Update(LocalEstoqueEF);

                await ContextSqlServer.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<LocalEstoque> Buscar(string id)
        {
            try
            {
                var LocalEstoque = await ContextSqlServer.locaisEstoque
                                         .Include(x => x.produtos)
                                         .Include(x => x.usuario)
                                         .FirstOrDefaultAsync(x => x.id == Guid.Parse(id));

                if (LocalEstoque == null)
                    throw new Exception("Local estoque não localizada");

                var localMappingDomain = LocalEstoque.toLocalEstoque();

                return localMappingDomain;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task Cadastrar(LocalEstoque objeto)
        {
            try
            {
                var LocalEstoqueEf = await ContextSqlServer.locaisEstoque.FirstOrDefaultAsync(x => x.nome == objeto.nome);
                if (LocalEstoqueEf != null) throw new Exception("LocalEstoque já cadastrada");

                var LocalEstoque = objeto.toLocalEstoqueEF();

                ContextSqlServer.locaisEstoque.Add(LocalEstoque);

                await ContextSqlServer.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task Deletar(string id)
        {
            try
            {
                var LocalEstoqueEF = await ContextSqlServer.locaisEstoque.FirstOrDefaultAsync(x => x.id == Guid.Parse(id));
                if (LocalEstoqueEF == null)
                    throw new Exception("Local de estoque não encontrado");

                ContextSqlServer.locaisEstoque.Remove(LocalEstoqueEF);

                await ContextSqlServer.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                throw new DbUpdateException($"Existem produtos nesse local de estoque");
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<IEnumerable<LocalEstoque>> Listar()
        {
            try
            {
                var locais = await ContextSqlServer.locaisEstoque
                                   .Include(x => x.produtos)
                                   .Include(x => x.usuario)
                                   .ToListAsync();

                var locaisMappingDomain = locais.toLocalEstoques();

                return locaisMappingDomain.ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
