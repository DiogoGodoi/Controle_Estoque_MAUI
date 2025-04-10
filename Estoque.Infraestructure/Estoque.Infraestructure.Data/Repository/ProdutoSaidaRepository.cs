using AutoMapper;
using Estoque.Application.Interfaces;
using Estoque.Infraestructure.Data.Context;
using Estoque.Domain.Modelos;
using Microsoft.EntityFrameworkCore;
using Estoque.Application.Comand.Modelos;

namespace Estoque.Infraestructure.Data.Repository
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
                var ProdutoSaidaMapping = mapper.Map<ProdutoSaidaDTO>(objeto);

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
                var ProdutoSaidaEf = await estoqueContext.produtoSaida.FirstOrDefaultAsync(x => x.fk_Saida_id == objeto.saida.id);
                if (ProdutoSaidaEf != null)
                    throw new Exception("Saida já cadastrada");

                var produtoEf = await estoqueContext.produtos.FirstOrDefaultAsync(x => x.id == objeto.produto.id);
                if (produtoEf == null)
                    throw new Exception("Produto não localizado");

                var SaidaEf = await estoqueContext.saidas.FirstOrDefaultAsync(x => x.id == objeto.saida.id);
                if (SaidaEf == null)
                    throw new Exception("Saida não localizada");

                var produtoSaida = mapper.Map<ProdutoSaidaDTO>(objeto);

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
                var usuarios = await estoqueContext.produtoSaida
                                    .Include(x => x.saida)
                                    .Include(x => x.produto)
                                    .ToListAsync();

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
