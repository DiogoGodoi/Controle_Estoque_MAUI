using AutoMapper;
using Estoque.Application.Interfaces;
using Estoque.Data.Context;
using Estoque.Data.ModelosEF;
using Estoque.Domain.Modelos;
using Microsoft.EntityFrameworkCore;

namespace Estoque.Data.Repository
{
    public class EntradaRepository : IRepository<Entrada>
    {
        private readonly IMapper mapper;

        private readonly EstoqueContext estoqueContext;
        public EntradaRepository(IMapper mapper, EstoqueContext estoqueContext)
        {
            this.mapper = mapper;
            this.estoqueContext = estoqueContext;
        }
        public async Task Atualizar(string id, Entrada objeto)
        {
            try
            {
                var EntradaMapping = mapper.Map<EntradaEF>(objeto);

                var EntradaEF = await estoqueContext.entradas.FirstOrDefaultAsync(x => x.id == Guid.Parse(id));

                if (EntradaEF == null)
                    throw new Exception("Entrada não encontrada");

                EntradaEF.dataEntrada = EntradaMapping.dataEntrada;
                EntradaEF.quantidade = EntradaMapping.quantidade;
                EntradaEF.fk_Usuario_id = EntradaMapping.fk_Usuario_id;

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
                var entrada = await estoqueContext.entradas.FirstOrDefaultAsync(x => x.id == Guid.Parse(id));

                if (entrada == null)
                    throw new Exception("Entrada não localizada");

                var entradaEF = mapper.Map<Entrada>(entrada);

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

                var usuarioEf = await estoqueContext.usuarios.FirstOrDefaultAsync(x => x.id == objeto.fk_Usuario_id);
                if (usuarioEf == null)
                    throw new Exception("Usuário não encontrado");

                var entradaProdutoEf = estoqueContext.produtoEntrada.Where(x => x.fk_Entrada_id == objeto.id).ToList();

                var entrada = mapper.Map<EntradaEF>(objeto);

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
                var entradas = await estoqueContext.entradas.ToListAsync();

                var entradaMappingDomain = mapper.Map<IEnumerable<Entrada>>(entradas);

                return entradaMappingDomain.ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
