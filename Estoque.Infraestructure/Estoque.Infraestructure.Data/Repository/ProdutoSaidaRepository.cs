using Estoque.Application.Interfaces;
using Estoque.Domain.Modelos;
using Estoque.Infraestructure.Data.Context;
using Estoque.Infraestructure.Data.Extend;
using Estoque.Infraestructure.Data.ModelosEF;
using Microsoft.EntityFrameworkCore;

namespace Estoque.Infraestructure.Data.Repository
{
    public class ProdutoSaidaRepository : IRepository<ProdutoSaida>
    {
        private readonly EstoqueContext estoqueContext;
        public ProdutoSaidaRepository(EstoqueContext estoqueContext)
        {
            this.estoqueContext = estoqueContext;
        }
        public async Task Atualizar(string id, ProdutoSaida objeto)
        {
            try
            {
                var ProdutoSaidaMapping = objeto.toProdutoSaidaEF();

                var ProdutoSaidaEF = await estoqueContext.produtoSaida.FirstOrDefaultAsync(x => x.fk_Saida_id == Guid.Parse(id));

                if (ProdutoSaidaEF == null)
                    throw new Exception("Saida não encontrada");

                ProdutoSaidaEF.fk_Produto_id = ProdutoSaidaMapping.fk_Produto_id;

                estoqueContext.produtoSaida.Update(ProdutoSaidaEF);

                await estoqueContext.SaveChangesAsync();

            }
            catch (DbUpdateException ex)
            {
                throw new Exception("Já existe uma ProdutoSaida com esse nome");
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<ProdutoSaida> Buscar(string idSaida)
        {
            try
            {
                var ProdutoSaida = await estoqueContext.produtoSaida
                                        .Include(x => x.saida)
                                        .Include(x => x.produto)
                                        .FirstOrDefaultAsync(x => x.fk_Saida_id == Guid.Parse(idSaida));

                if (ProdutoSaida == null)
                    throw new Exception("Saida não localizada");

                var usuarioMappingDomain = ProdutoSaida.toProdutoSaida();

                return usuarioMappingDomain;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task Cadastrar(ProdutoSaida objeto)
        {
            try
            {
                var ProdutoSaidaEf = await estoqueContext.produtoSaida.FirstOrDefaultAsync(x => x.fk_Saida_id == objeto.saida.id);
                if (ProdutoSaidaEf != null)
                    throw new Exception("Saida já cadastrada");

                var produtoEf = await estoqueContext.produtos.FirstOrDefaultAsync(x => x.id == objeto.produto.id);
                if (produtoEf == null)
                    throw new Exception("Produto não localizado");

                var SaidaEf = await estoqueContext.saidas.FirstOrDefaultAsync(x => x.id == objeto.saida.id);
                if (SaidaEf == null)
                    throw new Exception("Saida não localizada");

                var produtoSaida = objeto.toProdutoSaidaEF();

                produtoSaida.produto = produtoEf;
                produtoSaida.saida = SaidaEf;

                estoqueContext.produtoSaida.Add(produtoSaida);

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
                var ProdutoSaidaEF = await estoqueContext.produtoSaida.FirstOrDefaultAsync(x => x.fk_Saida_id == Guid.Parse(id));

                if (ProdutoSaidaEF == null)
                    throw new Exception("ProdutoSaida não encontrado");

                estoqueContext.produtoSaida.Remove(ProdutoSaidaEF);

                await estoqueContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<IEnumerable<ProdutoSaida>> Listar()
        {
            try
            {
                var produtosSaidas = await estoqueContext.produtoSaida
                                    .Include(x => x.saida)
                                    .Include(x => x.produto)
                                    .ToListAsync();

                var usuarioMappingDomain = produtosSaidas.toProdutoSaidas();

                return usuarioMappingDomain.ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
