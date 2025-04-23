using Estoque.Application.Interfaces;
using Estoque.Domain.Modelos;
using Estoque.Infraestructure.Data.Context;
using Estoque.Infraestructure.Data.Extend;
using Estoque.Infraestructure.Data.ModelosEF;
using Microsoft.EntityFrameworkCore;

namespace Estoque.Infraestructure.Data.Repository
{
    public class CategoriaRepository : IRepository<Categoria>
    {
        private readonly ContextSqlServer ContextSqlServer;
        public CategoriaRepository(ContextSqlServer ContextSqlServer)
        {
            this.ContextSqlServer = ContextSqlServer;
        }
        public async Task Atualizar(string id, Categoria objeto)
        {
            try
            {
                var CategoriaMapping = objeto.toCategoriaEF();

                var CategoriaEF = await ContextSqlServer.categorias.FirstOrDefaultAsync(x => x.id == Guid.Parse(id));

                if (CategoriaEF == null)
                    throw new Exception("Categoria não encontrada");

                if (CategoriaEF.nome == objeto.nome)
                    throw new Exception("Já existe uma categoria com esse nome");

                CategoriaEF.fk_Usuario_id = CategoriaMapping.fk_Usuario_id;
                CategoriaEF.nome = CategoriaMapping.nome;

                ContextSqlServer.categorias.Update(CategoriaEF);

                await ContextSqlServer.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                throw new DbUpdateException("Já existe uma categoria com esse nome");
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<Categoria> Buscar(string id)
        {

            try
            {
                var categoria = await ContextSqlServer.categorias
                                     .Include(x => x.produto)
                                     .Include(x => x.usuario)
                                     .FirstOrDefaultAsync(x => x.id == Guid.Parse(id));

                if (categoria == null)
                    throw new Exception("Categoria não localizada");

                var usuarioMappingDomain = categoria.toCategoria();

                return usuarioMappingDomain;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task Cadastrar(Categoria objeto)
        {
            try
            {
                var categoriaEf = await ContextSqlServer.categorias.FirstOrDefaultAsync(x => x.nome == objeto.nome);
                if (categoriaEf != null) throw new Exception("Categoria já cadastrada");

                var usuarioEF = await ContextSqlServer.usuarios.FirstOrDefaultAsync(x => x.id == objeto.usuario.id);
                if (usuarioEF == null) throw new Exception("Usuário não encontrado");

                var categoria = objeto.toCategoriaEF();

                categoria.usuario = usuarioEF;

                ContextSqlServer.categorias.Add(categoria);

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
                var CategoriaEF = await ContextSqlServer.categorias.FirstOrDefaultAsync(x => x.id == Guid.Parse(id));

                if (CategoriaEF == null)
                    throw new Exception("Categoria não encontrada");

                ContextSqlServer.categorias.Remove(CategoriaEF);

                await ContextSqlServer.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                throw new DbUpdateException("Existem produtos referenciados com esta categoria");
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<IEnumerable<Categoria>> Listar()
        {
            try
            {
                var categorias = await ContextSqlServer.categorias
                                     .Include(x => x.produto)
                                     .Include(x => x.usuario).ToListAsync();

                var usuarioMappingDomain = categorias.toCategorias();

                return usuarioMappingDomain.ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
