﻿using Estoque.Application.Interfaces;
using Estoque.Domain.Modelos;
using Estoque.Infraestructure.Data.Context;
using Estoque.Infraestructure.Data.Extend;
using Estoque.Infraestructure.Data.ModelosEF;
using Microsoft.EntityFrameworkCore;

namespace Estoque.Infraestructure.Data.Repository
{
    public class ProdutoEntradaRepository : IRepository<ProdutoEntrada>
    {
        private readonly EstoqueContext estoqueContext;
        public ProdutoEntradaRepository(EstoqueContext estoqueContext)
        {
            this.estoqueContext = estoqueContext;
        }
        public async Task Atualizar(string id, ProdutoEntrada objeto)
        {
            try
            {
                var ProdutoEntradaMapping = objeto.toProdutoEntradaEF();

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
                throw;
            }
        }
        public async Task<ProdutoEntrada> Buscar(string idEntrada)
        {
            try
            {
                var ProdutoEntrada = await estoqueContext.produtoEntrada
                                           .Include(x => x.entrada)
                                           .ThenInclude(x => x.usuario)
                                           .Include(x => x.produto)
                                           .FirstOrDefaultAsync(x => x.fk_Entrada_id == Guid.Parse(idEntrada));

                if (ProdutoEntrada == null)
                    throw new Exception("Entrada não localizada");

                var usuarioMappingDomain = ProdutoEntrada.toProdutoEntrada();

                return usuarioMappingDomain;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task Cadastrar(ProdutoEntrada objeto)
        {
            try
            {
                var ProdutoEntradaEf = await estoqueContext.produtoEntrada.FirstOrDefaultAsync(x => x.fk_Entrada_id == objeto.entrada.id);
                if (ProdutoEntradaEf != null)
                    throw new Exception("Entrada já cadastrada");

                var produtoEf = await estoqueContext.produtos.FirstOrDefaultAsync(x => x.id == objeto.produto.id);
                if (produtoEf == null)
                    throw new Exception("Produto não localizado");

                var entradaEf = await estoqueContext.entradas.FirstOrDefaultAsync(x => x.id == objeto.entrada.id);
                if (entradaEf == null)
                    throw new Exception("Entrada não localizada");

                var produtoEntrada = objeto.toProdutoEntradaEF();

                produtoEntrada.produto = produtoEf;
                produtoEntrada.entrada = entradaEf;

                estoqueContext.produtoEntrada.Add(produtoEntrada);



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
                var ProdutoEntradaEF = await estoqueContext.produtoEntrada.FirstOrDefaultAsync(x => x.fk_Entrada_id == Guid.Parse(id));

                if (ProdutoEntradaEF == null)
                    throw new Exception("ProdutoEntrada não encontrado");

                estoqueContext.produtoEntrada.Remove(ProdutoEntradaEF);

                await estoqueContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<IEnumerable<ProdutoEntrada>> Listar()
        {
            try
            {
                var usuarios = await estoqueContext.produtoEntrada
                                    .Include(x => x.entrada)
                                     .ThenInclude(x => x.usuario)
                                    .Include(x => x.produto)
                                    .ToListAsync();

                var usuarioMappingDomain = usuarios.toProdutosEntrada();

                return usuarioMappingDomain.ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
