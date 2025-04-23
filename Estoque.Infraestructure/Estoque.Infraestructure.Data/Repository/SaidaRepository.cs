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
        private readonly ContextSqlServer ContextSqlServer;
        public SaidaRepository(ContextSqlServer ContextSqlServer)
        {
            this.ContextSqlServer = ContextSqlServer;
        }
        public async Task Atualizar(string id, Saida objeto)
        {
            try
            {
                var SaidaMapping = objeto.toSaidaEF();

                var SaidaEF = await ContextSqlServer.saidas.FirstOrDefaultAsync(x => x.id == Guid.Parse(id));

                if (SaidaEF == null)
                    throw new Exception("Saida não encontrada");

                SaidaEF.dataSaida = SaidaMapping.dataSaida;
                SaidaEF.quantidade = SaidaMapping.quantidade;
                SaidaEF.fk_Usuario_id = objeto.usuario.id;

                ContextSqlServer.saidas.Update(SaidaEF);

                await ContextSqlServer.SaveChangesAsync();

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
                var saida = await ContextSqlServer.saidas
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
                var SaidaEF = await ContextSqlServer.saidas.FirstOrDefaultAsync(x => x.id == objeto.id);
                if (SaidaEF != null)
                    throw new Exception("Saida já cadastrada");

                var usuarioEf = await ContextSqlServer.usuarios.FirstOrDefaultAsync(x => x.id == objeto.usuario.id);
                if (usuarioEf == null)
                    throw new Exception("Usuário não encontrado");

                var SaidaProdutoEf = ContextSqlServer.produtoSaida.Where(x => x.fk_Saida_id == objeto.id).ToList();

                var Saida = objeto.toSaidaEF();

                Saida.produtoSaida = SaidaProdutoEf;
                Saida.usuario = usuarioEf;

                ContextSqlServer.saidas.Add(Saida);

                await ContextSqlServer.SaveChangesAsync();

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
                var SaidaEF = await ContextSqlServer.saidas.FirstOrDefaultAsync(x => x.id == Guid.Parse(id));

                if (SaidaEF == null)
                    throw new Exception("Saida não encontrada");

                ContextSqlServer.saidas.Remove(SaidaEF);

                await ContextSqlServer.SaveChangesAsync();
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
                var saidas = await ContextSqlServer.saidas
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
