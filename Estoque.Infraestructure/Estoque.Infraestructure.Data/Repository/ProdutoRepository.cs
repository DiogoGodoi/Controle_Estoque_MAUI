﻿using AutoMapper;
using Estoque.Application.Interfaces;
using Estoque.Infraestructure.Data.Context;
using Estoque.Domain.Modelos;
using Microsoft.EntityFrameworkCore;
using Estoque.Application.Comand.Modelos;

namespace Estoque.Infraestructure.Data.Repository
{
    public class ProdutoRepository : IRepository<Produto>
    {
        private readonly IMapper mapper;

        private readonly EstoqueContext estoqueContext;
        public ProdutoRepository(IMapper mapper, EstoqueContext estoqueContext)
        {
            this.mapper = mapper;
            this.estoqueContext = estoqueContext;
        }
        public async Task Atualizar(string id, Produto objeto)
        {
            try
            {
                
                var ProdutoMapping = mapper.Map<ProdutoDTO>(objeto);

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
                var Produto = await estoqueContext
                                    .produtos.Include(x => x.categoria)
                                    .Include(x => x.usuario)
                                    .Include(x => x.localEstoque)
                                    .FirstOrDefaultAsync(x => x.id == Guid.Parse(id));

                if (Produto == null)
                    throw new Exception("Produto não localizado");

                var usuarioMappingDomain = mapper.Map<Produto>(Produto);

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

                var Produto = mapper.Map<ProdutoDTO>(objeto);

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
                                    .ToListAsync();

                var produtosMappingDomain = mapper.Map<IEnumerable<Produto>>(produtos);

                return produtosMappingDomain.ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
