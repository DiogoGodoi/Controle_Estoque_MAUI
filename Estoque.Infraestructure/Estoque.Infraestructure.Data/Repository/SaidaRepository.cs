using AutoMapper;
using Estoque.Application.Interfaces;
using Estoque.Infraestructure.Data.Context;
using Estoque.Infraestructure.Data.ModelosEF;
using Estoque.Domain.Modelos;
using Microsoft.EntityFrameworkCore;

namespace Estoque.Infraestructure.Data.Repository
{
    public class SaidaRepository : IRepository<Saida>
    {
        private readonly IMapper mapper;

        private readonly EstoqueContext estoqueContext;
        public SaidaRepository(IMapper mapper, EstoqueContext estoqueContext)
        {
            this.mapper = mapper;
            this.estoqueContext = estoqueContext;
        }
        public async Task Atualizar(string id, Saida objeto)
        {
            try
            {
                var SaidaMapping = mapper.Map<SaidaEF>(objeto);

                var SaidaEF = await estoqueContext.saidas.FirstOrDefaultAsync(x => x.id == Guid.Parse(id));

                if (SaidaEF == null)
                    throw new Exception("Saida não encontrada");

                SaidaEF.dataSaida = SaidaMapping.dataSaida;
                SaidaEF.quantidade = SaidaMapping.quantidade;
                SaidaEF.fk_Usuario_id = SaidaMapping.fk_Usuario_id;

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
                var Saida = await estoqueContext.saidas.FirstOrDefaultAsync(x => x.id == Guid.Parse(id));

                if (Saida == null)
                    throw new Exception("Saida não localizada");

                var SaidaEF = mapper.Map<Saida>(Saida);

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

                var usuarioEf = await estoqueContext.usuarios.FirstOrDefaultAsync(x => x.id == objeto.fk_Usuario_id);
                if (usuarioEf == null)
                    throw new Exception("Usuário não encontrado");

                var SaidaProdutoEf = estoqueContext.produtoSaida.Where(x => x.fk_Saida_id == objeto.id).ToList();

                var Saida = mapper.Map<SaidaEF>(objeto);

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
                var saidas = await estoqueContext.saidas.ToListAsync();

                var SaidaMappingDomain = mapper.Map<IEnumerable<Saida>>(saidas);

                return SaidaMappingDomain.ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
