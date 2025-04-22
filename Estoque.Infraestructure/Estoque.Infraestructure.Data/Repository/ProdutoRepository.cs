using Estoque.Application.Interfaces;
using Estoque.Domain.Modelos;
using Estoque.Infraestructure.Data.Context;
using Estoque.Infraestructure.Data.Extend;
using Estoque.Infraestructure.Data.ModelosEF;
using Microsoft.EntityFrameworkCore;

namespace Estoque.Infraestructure.Data.Repository
{
    public class ProdutoRepository : IRepository<Produto>
    {
        private readonly EstoqueContext estoqueContext;
        public ProdutoRepository(EstoqueContext estoqueContext)
        {
            this.estoqueContext = estoqueContext;
        }
        public async Task Atualizar(string id, Produto objeto)
        {
            try
            {
                var ProdutoMapping = objeto.toProdutoEF();

                var ProdutoEF = await estoqueContext.produtos.FirstOrDefaultAsync(x => x.id == Guid.Parse(id));

                if (ProdutoEF == null)
                    throw new Exception("Produto não encontrado");

                if (ProdutoEF.quantidade == objeto.quantidade)
                {
                    if (ProdutoEF.descricao == objeto.descricao)
                        throw new Exception("Já existe uma Produto com esse nome");
                }

                ProdutoEF.descricao = ProdutoMapping.descricao;
                ProdutoEF.unidade = ProdutoMapping.unidade;
                ProdutoEF.quantidade = ProdutoMapping.quantidade;
                ProdutoEF.preco1 = ProdutoMapping.preco1;
                ProdutoEF.preco2 = ProdutoMapping.preco2;
                ProdutoEF.preco3 = ProdutoMapping.preco3;
                ProdutoEF.precoMedio = ProdutoMapping.precoMedio;
                ProdutoEF.fk_Categoria_id = ProdutoMapping.fk_Categoria_id;
                ProdutoEF.fk_Usuario_id = ProdutoMapping.fk_Usuario_id;
                ProdutoEF.fk_LocalEstoque_id = ProdutoMapping.fk_LocalEstoque_id;

                estoqueContext.produtos.Update(ProdutoEF);

                await estoqueContext.SaveChangesAsync();

            }
            catch (DbUpdateException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<Produto> Buscar(string id)
        {
            try
            {
                var produto = await estoqueContext
                                    .produtos.Include(x => x.categoria)
                                    .Include(x => x.usuario)
                                        .ThenInclude(x => x.perfil)
                                    .Include(x => x.localEstoque)
                                    .FirstOrDefaultAsync(x => x.id == Guid.Parse(id));

                if (produto == null)
                    throw new Exception("Produto não localizado");

                var usuarioMappingDomain = produto.toProduto();

                return usuarioMappingDomain;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task Cadastrar(Produto objeto)
        {
            try
            {
                var ProdutoEf = await estoqueContext.produtos.FirstOrDefaultAsync(x => x.descricao == objeto.descricao);
                if (ProdutoEf != null) throw new Exception("Produto já cadastrado");

                var usuarioEf = await estoqueContext.usuarios.FirstOrDefaultAsync(x => x.id == objeto.usuario.id);
                if (usuarioEf == null) throw new Exception("Usuário não encontrado");

                var categoriaEf = await estoqueContext.categorias.FirstOrDefaultAsync(x => x.id == objeto.categoria.id);
                if (categoriaEf == null) throw new Exception("Categoria não encontrada");

                var localEstoqueEf = await estoqueContext.locaisEstoque.FirstOrDefaultAsync(x => x.id == objeto.localEstoque.id);
                if (localEstoqueEf == null) throw new Exception("Local de estoque encontrads");

                var Produto = objeto.toProdutoEF();

                Produto.usuario = usuarioEf;
                Produto.categoria = categoriaEf;
                Produto.localEstoque = localEstoqueEf;

                estoqueContext.produtos.Add(Produto);
                await estoqueContext.SaveChangesAsync();
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
                var ProdutoEF = await estoqueContext.produtos.FirstOrDefaultAsync(x => x.id == Guid.Parse(id));

                if (ProdutoEF == null)
                    throw new Exception("Produto não encontrado");

                estoqueContext.produtos.Remove(ProdutoEF);

                await estoqueContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<IEnumerable<Produto>> Listar()
        {
            try
            {
                var produtos = await estoqueContext.produtos
                                    .Include(x => x.categoria)
                                    .Include(x => x.localEstoque)
                                    .Include(x => x.usuario)
                                    .ThenInclude(x => x.perfil)
                                    .ToListAsync();

                var produtosMappingDomain = produtos.toProdutos();

                return produtosMappingDomain.ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
