using AutoMapper;
using Estoque.Application.Interfaces;
using Estoque.Data.Context;
using Estoque.Data.ModelosEF;
using Estoque.Domain.Modelos;
using Microsoft.EntityFrameworkCore;

namespace Estoque.Data.Repository
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

        public Task Atualizar(string chave, Produto objeto)
        {
            throw new NotImplementedException();
        }

        public Task<Produto> Buscar(string chave)
        {
            throw new NotImplementedException();
        }

        public Task Cadastrar(Produto objeto)
        {
            throw new NotImplementedException();
        }

        public Task Deletar(string chave)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Produto>> Listar()
        {
            throw new NotImplementedException();
        }
        //public async Task Atualizar(string id, Produto objeto)
        //{
        //    try
        //    {
        //        var ProdutoMapping = mapper.Map<ProdutoEF>(objeto);

        //        var ProdutoEF = await estoqueContext.produtos.FirstOrDefaultAsync(x => x.id == Guid.Parse(id));

        //        if (ProdutoEF == null)
        //            throw new Exception("Produto não encontrado");

        //        ProdutoEF.descricao = ProdutoMapping.descricao;
        //        ProdutoEF.unidade = ProdutoMapping.unidade;
        //        ProdutoEF.quantidade = ProdutoMapping.quantidade;
        //        ProdutoEF.preco1 = ProdutoMapping.preco1;
        //        ProdutoEF.preco2 = ProdutoMapping.preco2;
        //        ProdutoEF.preco3 = ProdutoMapping.preco3;
        //        ProdutoEF.precoMedio = ProdutoMapping.precoMedio;
        //        ProdutoEF.fk_Categoria_id = ProdutoMapping.fk_Categoria_id;
        //        ProdutoEF.fk_Usuario_id = ProdutoMapping.fk_Usuario_id;

        //        estoqueContext.produtos.Update(ProdutoEF);

        //        await estoqueContext.SaveChangesAsync();

        //    }catch(DbUpdateException ex)
        //    {
        //        throw new Exception("Já existe uma Produto com esse nome");
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}
        //public async Task<Produto> Buscar(string descricao)
        //{
        //    try
        //    {
        //        var Produto = await estoqueContext.produtos.FirstOrDefaultAsync(x => x.descricao == descricao);

        //        if (Produto == null)
        //            throw new Exception("Produto não localizado");

        //        var usuarioMappingDomain = mapper.Map<Produto>(Produto);

        //        return usuarioMappingDomain;

        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}
        //public async Task Cadastrar(Produto objeto)
        //{
        //    try
        //    {
        //        var ProdutoEf = await estoqueContext.produtos.FirstOrDefaultAsync(x => x.descricao == objeto.descricao);

        //        if (ProdutoEf != null)
        //            throw new Exception("Produto já cadastrado");

        //        var Produto = mapper.Map<ProdutoEF>(objeto);

        //        Produto.usuario = new UsuarioEF { id = Guid.Empty, email = "", senha = "" };

        //        estoqueContext.produtos.Add(Produto);

        //        await estoqueContext.SaveChangesAsync();

        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}
        //public async Task Deletar(string id)
        //{
        //    try
        //    {
        //        var ProdutoEF = await estoqueContext.produtos.FirstOrDefaultAsync(x => x.id == Guid.Parse(id));

        //        if (ProdutoEF == null)
        //            throw new Exception("Produto não encontrado");

        //        estoqueContext.produtos.Remove(ProdutoEF);

        //        await estoqueContext.SaveChangesAsync();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}
        //public async Task<IEnumerable<Produto>> Listar()
        //{
        //    try
        //    {
        //        var usuarios = await estoqueContext.produtos.ToListAsync();

        //        var usuarioMappingDomain = mapper.Map<IEnumerable<Produto>>(usuarios);

        //        return usuarioMappingDomain.ToList();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}
    }
}
