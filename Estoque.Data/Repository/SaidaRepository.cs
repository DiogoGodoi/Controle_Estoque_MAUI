using AutoMapper;
using Estoque.Application.Interfaces;
using Estoque.Data.Context;
using Estoque.Data.ModelosEF;
using Estoque.Domain.Modelos;
using Microsoft.EntityFrameworkCore;

namespace Estoque.Data.Repository
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
                throw new Exception(ex.Message);
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
                throw new Exception(ex.Message);
            }
        }
        public async Task Cadastrar(Saida objeto)
        {
            try
            {
                var SaidaEF = await estoqueContext.saidas.FirstOrDefaultAsync(x => x.id == objeto.id);

                if (SaidaEF != null)
                    throw new Exception("Saida já cadastrada");

                var Saida = mapper.Map<SaidaEF>(objeto);

                Saida.usuario = new UsuarioEF { id = Guid.Empty, email = "", senha = "" };

                estoqueContext.saidas.Add(Saida);

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
                var SaidaEF = await estoqueContext.saidas.FirstOrDefaultAsync(x => x.id == Guid.Parse(id));

                if (SaidaEF == null)
                    throw new Exception("Saida não encontrada");

                estoqueContext.saidas.Remove(SaidaEF);

                await estoqueContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<IEnumerable<Saida>> Listar()
        {
            try
            {
                var Saidas = await estoqueContext.saidas.ToListAsync();

                var SaidaMappingDomain = mapper.Map<IEnumerable<Saida>>(Saidas);

                return SaidaMappingDomain.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
