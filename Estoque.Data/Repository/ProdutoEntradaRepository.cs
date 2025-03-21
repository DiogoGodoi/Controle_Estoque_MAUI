using AutoMapper;
using Estoque.Application.Interfaces;
using Estoque.Data.Context;
using Estoque.Data.ModelosEF;
using Estoque.Domain.Modelos;
using Microsoft.EntityFrameworkCore;

namespace Estoque.Data.Repository
{
    public class ProdutoEntradaEntradaRepository : IRepository<ProdutoEntrada>
    {
        private readonly IMapper mapper;

        private readonly EstoqueContext estoqueContext;
        public ProdutoEntradaEntradaRepository(IMapper mapper, EstoqueContext estoqueContext)
        {
            this.mapper = mapper;
            this.estoqueContext = estoqueContext;
        }
        public async Task Atualizar(string id, ProdutoEntrada objeto)
        {
            try
            {
                var ProdutoEntradaMapping = mapper.Map<ProdutoEntradaEF>(objeto);

                var ProdutoEntradaEF = await estoqueContext.produtoEntrada.FirstOrDefaultAsync(x => x.fk_Entrada_id == Guid.Parse(id));

                if (ProdutoEntradaEF == null)
                    throw new Exception("Entrada não encontrada");

                ProdutoEntradaEF.fk_Produto_id = ProdutoEntradaMapping.fk_Produto_id;

                estoqueContext.produtoEntrada.Update(ProdutoEntradaEF);

                await estoqueContext.SaveChangesAsync();

            }
            catch (DbUpdateException ex)
            {
                throw new Exception("Já existe uma ProdutoEntrada com esse nome");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<ProdutoEntrada> Buscar(string idEntrada)
        {
            try
            {
                var ProdutoEntrada = await estoqueContext.produtoEntrada.FirstOrDefaultAsync(x => x.fk_Entrada_id == Guid.Parse(idEntrada));

                if (ProdutoEntrada == null)
                    throw new Exception("Entrada não localizada");

                var usuarioMappingDomain = mapper.Map<ProdutoEntrada>(ProdutoEntrada);

                return usuarioMappingDomain;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task Cadastrar(ProdutoEntrada objeto)
        {
            try
            {
                var ProdutoEntradaEf = await estoqueContext.produtoEntrada.FirstOrDefaultAsync(x => x.fk_Entrada_id == objeto.fk_Entrada_id);

                if (ProdutoEntradaEf != null)
                    throw new Exception("Entrada já cadastrada");

                var ProdutoEntrada = mapper.Map<ProdutoEntradaEF>(objeto);

                estoqueContext.produtoEntrada.Add(ProdutoEntrada);

                await estoqueContext.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task Deletar(string id)
        {
            try
            {
                var ProdutoEntradaEF = await estoqueContext.produtoEntrada.FirstOrDefaultAsync(x => x.fk_Entrada_id == Guid.Parse(id));

                if (ProdutoEntradaEF == null)
                    throw new Exception("ProdutoEntrada não encontrado");

                estoqueContext.produtoEntrada.Remove(ProdutoEntradaEF);

                await estoqueContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<IEnumerable<ProdutoEntrada>> Listar()
        {
            try
            {
                var usuarios = await estoqueContext.produtoEntrada.ToListAsync();

                var usuarioMappingDomain = mapper.Map<IEnumerable<ProdutoEntrada>>(usuarios);

                return usuarioMappingDomain.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
