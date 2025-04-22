using Estoque.Application.Interfaces;
using Estoque.Domain.Modelos;
using Estoque.Infraestructure.Data.Context;
using Estoque.Infraestructure.Data.Extend;
using Estoque.Infraestructure.Data.ModelosEF;
using Microsoft.EntityFrameworkCore;

namespace Estoque.Infraestructure.Data.Repository
{
    public class EntradaRepository : IRepository<Entrada>
    {
        private readonly EstoqueContext estoqueContext;
        public EntradaRepository(EstoqueContext estoqueContext)
        {
            this.estoqueContext = estoqueContext;
        }
        public async Task Atualizar(string id, Entrada objeto)
        {
            try
            {
                var EntradaMapping = objeto.toEntradaEF();

                var EntradaEF = await estoqueContext.entradas.FirstOrDefaultAsync(x => x.id == Guid.Parse(id));

                if (EntradaEF == null)
                    throw new Exception("Entrada não encontrada");

                EntradaEF.dataEntrada = EntradaMapping.dataEntrada;
                EntradaEF.quantidade = EntradaMapping.quantidade;
                EntradaEF.fk_Usuario_id = objeto.usuario.id;

                estoqueContext.entradas.Update(EntradaEF);

                await estoqueContext.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<Entrada> Buscar(string id)
        {

            try
            {
                var entrada = await estoqueContext.entradas
                                    .Include(x => x.produtoEntrada)
                                    .Include(x => x.usuario)
                                    .FirstOrDefaultAsync(x => x.id == Guid.Parse(id));

                if (entrada == null)
                    throw new Exception("Entrada não localizada");

                var entradaEF = entrada.toEntrada();

                return entradaEF;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task Cadastrar(Entrada objeto)
        {
            try
            {
                var entradaEF = await estoqueContext.entradas.FirstOrDefaultAsync(x => x.id == objeto.id);
                if (entradaEF != null)
                    throw new Exception("Entrada já cadastrada");

                var usuarioEf = await estoqueContext.usuarios.FirstOrDefaultAsync(x => x.id == objeto.usuario.id);
                if (usuarioEf == null)
                    throw new Exception("Usuário não encontrado");

                var entradaProdutoEf = estoqueContext.produtoEntrada.Where(x => x.fk_Entrada_id == objeto.id).ToList();

                var entrada = objeto.toEntradaEF();

                entrada.produtoEntrada = entradaProdutoEf;
                entrada.usuario = usuarioEf;

                estoqueContext.entradas.Add(entrada);

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
                var EntradaEF = await estoqueContext.entradas.FirstOrDefaultAsync(x => x.id == Guid.Parse(id));

                if (EntradaEF == null)
                    throw new Exception("Entrada não encontrada");

                estoqueContext.entradas.Remove(EntradaEF);

                await estoqueContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<IEnumerable<Entrada>> Listar()
        {
            try
            {
                var entradas = await estoqueContext.entradas
                                    .Include(x => x.produtoEntrada)
                                    .Include(x => x.usuario)
                                    .ToListAsync();

                var entradaMappingDomain = entradas.toEntradas();

                return entradaMappingDomain.ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
