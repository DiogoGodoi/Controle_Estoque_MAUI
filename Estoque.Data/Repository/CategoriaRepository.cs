using AutoMapper;
using Estoque.Application.Interfaces;
using Estoque.Data.Context;
using Estoque.Data.ModelosEF;
using Estoque.Domain.Modelos;
using Microsoft.EntityFrameworkCore;

namespace Estoque.Data.Repository
{
    public class CategoriaRepository : IRepository<Categoria>
    {
        private readonly IMapper mapper;

        private readonly EstoqueContext estoqueContext;
        public CategoriaRepository(IMapper mapper, EstoqueContext estoqueContext)
        {
            this.mapper = mapper;
            this.estoqueContext = estoqueContext;
        }
        public async Task Atualizar(string nome, Categoria objeto)
        {
            try
            {
                var CategoriaMapping = mapper.Map<CategoriaEF>(objeto);

                var CategoriaEF = await estoqueContext.categorias.FirstOrDefaultAsync(x => x.nome == nome);

                if (CategoriaEF == null)
                    throw new Exception("Categoria não encontrada");

                CategoriaEF.fk_Usuario_id = CategoriaMapping.fk_Usuario_id;
                CategoriaEF.nome = CategoriaMapping.nome;

                estoqueContext.categorias.Update(CategoriaEF);

                await estoqueContext.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("Já existe uma categoria com esse nome");
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<Categoria> Buscar(string nome)
        {

            try
            {
                var categoria = await estoqueContext.categorias.FirstOrDefaultAsync(x => x.nome == nome);

                if (categoria == null)
                    throw new Exception("Categoria não localizada");

                var usuarioMappingDomain = mapper.Map<Categoria>(categoria);

                return usuarioMappingDomain;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task Cadastrar(Categoria objeto)
        {
            try
            {
                var categoriaEf = await estoqueContext.categorias.FirstOrDefaultAsync(x => x.nome == objeto.nome);
                if (categoriaEf != null) throw new Exception("Categoria já cadastrada");

                var usuarioEF = await estoqueContext.usuarios.FirstOrDefaultAsync(x => x.id == objeto.fk_Usuario_id);
                if (usuarioEF == null) throw new Exception("Usuário não encontrado");

                
                var categoria = mapper.Map<CategoriaEF>(objeto);
                categoria.usuario = usuarioEF;

                estoqueContext.categorias.Add(categoria);

                await estoqueContext.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task Deletar(string nome)
        {
            try
            {
                var CategoriaEF = await estoqueContext.categorias.FirstOrDefaultAsync(x => x.nome == nome);

                if (CategoriaEF == null)
                    throw new Exception("Categoria não encontrada");

                estoqueContext.categorias.Remove(CategoriaEF);

                await estoqueContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<IEnumerable<Categoria>> Listar()
        {
            try
            {
                var usuarios = await estoqueContext.categorias.ToListAsync();

                var usuarioMappingDomain = mapper.Map<IEnumerable<Categoria>>(usuarios);

                return usuarioMappingDomain.ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
