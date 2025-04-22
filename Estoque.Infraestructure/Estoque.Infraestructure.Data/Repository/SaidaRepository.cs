using Estoque.Application.Interfaces;
using Estoque.Domain.Modelos;
using Estoque.Infraestructure.Data.Context;
using Estoque.Infraestructure.Data.Extend;
using Estoque.Infraestructure.Data.ModelosEF;
using Microsoft.EntityFrameworkCore;

namespace Estoque.Infraestructure.Data.Repository
{
    public class SaidaRepository : IRepository<Saida>
    {
        private readonly EstoqueContext estoqueContext;
        public SaidaRepository(EstoqueContext estoqueContext)
        {
            this.estoqueContext = estoqueContext;
        }
        public async Task Atualizar(string id, Saida objeto)
        {
            try
            {
                var SaidaMapping = objeto.toSaidaEF();

                var SaidaEF = await estoqueContext.saidas.FirstOrDefaultAsync(x => x.id == Guid.Parse(id));

                if (SaidaEF == null)
                    throw new Exception("Saida não encontrada");

                SaidaEF.dataSaida = SaidaMapping.dataSaida;
                SaidaEF.quantidade = SaidaMapping.quantidade;
                SaidaEF.fk_Usuario_id = objeto.usuario.id;

                estoqueContext.saidas.Update(SaidaEF);

                await estoqueContext.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<Saida> Buscar(string id)
        {

            try
            {
                var saida = await estoqueContext.saidas
                                  .Include(x => x.produtoSaida)
                                  .Include(x => x.usuario)
                                  .FirstOrDefaultAsync(x => x.id == Guid.Parse(id));

                if (saida == null)
                    throw new Exception("Saida não localizada");

                var SaidaEF = saida.toSaida();

                return SaidaEF;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task Cadastrar(Saida objeto)
        {
            try
            {
                var SaidaEF = await estoqueContext.saidas.FirstOrDefaultAsync(x => x.id == objeto.id);
                if (SaidaEF != null)
                    throw new Exception("Saida já cadastrada");

                var usuarioEf = await estoqueContext.usuarios.FirstOrDefaultAsync(x => x.id == objeto.usuario.id);
                if (usuarioEf == null)
                    throw new Exception("Usuário não encontrado");

                var SaidaProdutoEf = estoqueContext.produtoSaida.Where(x => x.fk_Saida_id == objeto.id).ToList();

                var Saida = objeto.toSaidaEF();

                Saida.produtoSaida = SaidaProdutoEf;
                Saida.usuario = usuarioEf;

                estoqueContext.saidas.Add(Saida);

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
                var SaidaEF = await estoqueContext.saidas.FirstOrDefaultAsync(x => x.id == Guid.Parse(id));

                if (SaidaEF == null)
                    throw new Exception("Saida não encontrada");

                estoqueContext.saidas.Remove(SaidaEF);

                await estoqueContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<IEnumerable<Saida>> Listar()
        {
            try
            {
                var saidas = await estoqueContext.saidas
                                   .Include(x => x.produtoSaida)
                                   .Include(x => x.usuario)
                                   .ToListAsync();

                var SaidaMappingDomain = saidas.toSaidas();

                return SaidaMappingDomain.ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
