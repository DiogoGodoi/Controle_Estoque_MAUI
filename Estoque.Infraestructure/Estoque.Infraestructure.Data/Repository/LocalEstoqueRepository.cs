using AutoMapper;
using Estoque.Application.Interfaces;
using Estoque.Infraestructure.Data.Context;
using Estoque.Infraestructure.Data.ModelosEF;
using Estoque.Domain.Modelos;
using Microsoft.EntityFrameworkCore;

namespace Estoque.Infraestructure.Data.Repository
{
    public class LocalEstoqueRepository : IRepository<LocalEstoque>
    {
        private readonly IMapper mapper;

        private readonly EstoqueContext estoqueContext;
        public LocalEstoqueRepository(IMapper mapper, EstoqueContext estoqueContext)
        {
            this.mapper = mapper;
            this.estoqueContext = estoqueContext;
        }
        public async Task Atualizar(string id, LocalEstoque objeto)
        {
            try
            {
                var LocalEstoqueMapping = mapper.Map<LocalEstoqueEF>(objeto);

                var LocalEstoqueEF = await estoqueContext.locaisEstoque.FirstOrDefaultAsync(x => x.id == Guid.Parse(id));

                if (LocalEstoqueEF == null)
                    throw new Exception("Local de estoque não encontrada");

                LocalEstoqueEF.nome = LocalEstoqueMapping.nome;

                estoqueContext.locaisEstoque.Update(LocalEstoqueEF);

                await estoqueContext.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("Já existe uma Local estoque com esse nome");
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<LocalEstoque> Buscar(string nome)
        {
            try
            {
                var LocalEstoque = await estoqueContext.locaisEstoque.FirstOrDefaultAsync(x => x.nome == nome);

                if (LocalEstoque == null)
                    throw new Exception("Local estoque não localizada");

                var usuarioMappingDomain = mapper.Map<LocalEstoque>(LocalEstoque);

                return usuarioMappingDomain;

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
                var LocalEstoqueEf = await estoqueContext.locaisEstoque.FirstOrDefaultAsync(x => x.nome == objeto.nome);
                if (LocalEstoqueEf != null) throw new Exception("LocalEstoque já cadastrada");

                var LocalEstoque = mapper.Map<LocalEstoqueEF>(objeto);

                estoqueContext.locaisEstoque.Add(LocalEstoque);

                await estoqueContext.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task Deletar(string nome)
        {
            try
            {
                var LocalEstoqueEF = await estoqueContext.locaisEstoque.FirstOrDefaultAsync(x => x.nome == nome);
                if (LocalEstoqueEF == null)
                    throw new Exception("LocalEstoque não encontrada");

                estoqueContext.locaisEstoque.Remove(LocalEstoqueEF);

                await estoqueContext.SaveChangesAsync();
            }
            catch(DbUpdateException ex)
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
                var usuarios = await estoqueContext.locaisEstoque.ToListAsync();

                var usuarioMappingDomain = mapper.Map<IEnumerable<LocalEstoque>>(usuarios);

                return usuarioMappingDomain.ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
