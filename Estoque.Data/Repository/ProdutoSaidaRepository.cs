using AutoMapper;
using Estoque.Application.Interfaces;
using Estoque.Data.Context;
using Estoque.Data.ModelosEF;
using Estoque.Domain.Modelos;
using Microsoft.EntityFrameworkCore;

namespace Estoque.Data.Repository
{
    public class ProdutoSaidaRepository : IRepository<ProdutoSaida>
    {
        private readonly IMapper mapper;

        private readonly EstoqueContext estoqueContext;
        public ProdutoSaidaRepository(IMapper mapper, EstoqueContext estoqueContext)
        {
            this.mapper = mapper;
            this.estoqueContext = estoqueContext;
        }
        public async Task Atualizar(string id, ProdutoSaida objeto)
        {
            try
            {
                var ProdutoSaidaMapping = mapper.Map<ProdutoSaidaEF>(objeto);

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
                var ProdutoSaida = await estoqueContext.produtoSaida.FirstOrDefaultAsync(x => x.fk_Saida_id == Guid.Parse(idSaida));

                if (ProdutoSaida == null)
                    throw new Exception("Saida não localizada");

                var usuarioMappingDomain = mapper.Map<ProdutoSaida>(ProdutoSaida);

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
                var ProdutoSaidaEf = await estoqueContext.produtoSaida.FirstOrDefaultAsync(x => x.fk_Saida_id == objeto.fk_Saida_id);
                if (ProdutoSaidaEf != null)
                    throw new Exception("Saida já cadastrada");

                var produtoEf = await estoqueContext.produtos.FirstOrDefaultAsync(x => x.id == objeto.fk_Produto_id);
                if (produtoEf == null)
                    throw new Exception("Produto não localizado");

                var SaidaEf = await estoqueContext.saidas.FirstOrDefaultAsync(x => x.id == objeto.fk_Saida_id);
                if (SaidaEf == null)
                    throw new Exception("Saida não localizada");

                var produtoSaida = mapper.Map<ProdutoSaidaEF>(objeto);

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
                var usuarios = await estoqueContext.produtoSaida.ToListAsync();

                var usuarioMappingDomain = mapper.Map<IEnumerable<ProdutoSaida>>(usuarios);

                return usuarioMappingDomain.ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
